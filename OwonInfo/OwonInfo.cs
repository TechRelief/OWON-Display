using System.Data;
using System.IO.Ports;
using System.Runtime.ExceptionServices;
using System.Threading.Channels;

namespace OwonInfo
{
    /// <summary>Class OwonValue is used to store the values returned by the Owon XDM1041 multimeter.</summary>
    public class OwonValue
    {
        private bool isReady = false;           //True if there is valid data to process
        private string value = string.Empty;    //The measured value including its unit like: 1.0000 VDC
        private string mode = string.Empty;     //The mode like Voltage, Current etc.
        private string errorMsg = string.Empty; //If not empty will contain the last error message encountered

        public void Reset()
        {
            isReady = false;
            Value = string.Empty;
            mode = string.Empty;
            errorMsg = string.Empty;
        }

        public OwonValue()
        {
            Reset();
        }

        public bool HasError { get => !string.IsNullOrEmpty(ErrorMsg); }
        public bool IsReady { get => isReady; set => isReady = value; }
        public string Mode { get => mode; set => mode = value; }
        public string ErrorMsg { get => errorMsg; set => errorMsg = value; }
        public string Value { get => value; set => this.value = value; }
    }

    /// <summary>Class OwonData provides the means to commonicate with the mutimeter and retrieve its readings..</summary>
    public class OwonData
    {
        static byte preFix = 0;

        /// <summary>Enum DataType
        /// is used to convey the type of SCPI data requested, either the Value or the Mode like: Voltage, Resistance etc.</summary>
        private enum DataType
        {
            Value,
            Mode
        }

        /// <summary>
        /// Decodes the byte and adds it to the referenced string if appropriate.  
        /// Special characters like Ohm and Micro are decoded and added when found.
        /// Any characters with ASCII code less than 20H are ignored except for 10H (EOL) 
        /// which will not be appended but will cause a return value of true to mark the end of line.
        /// </summary>
        /// <param name="b">The byte to decode.</param>
        /// <param name="s">The referenced string that will have any decoded characters added when needed.</param>
        /// <returns>
        ///   <c>true</c> if the EOL (10H) ASCII character has been received., <c>false</c> otherwise.</returns>
        static bool DecodeByte(byte b, ref string s)
        {
            //var s = "Ωμ°";
            bool eol = false;

            if (b == 0xA6 || b == 0xA1 || b == 0xA8)
                preFix = b;
            else if (b == 0xB8 && preFix == 0xA6)
            {
                preFix = 0x00;
                s += "Ω";
            }
            else if (b == 0xCC && preFix == 0xA6)
            {
                preFix = 0x00;
                s += "μ";
            }
            else if (b == 0xE6 && preFix == 0xA1)
            {
                preFix = 0x00;
                s += "°C";
            }
            else if (b == 0x48 && preFix == 0xA8)
            {
                preFix = 0x00;
                s += "°F";
            }
            else if (b == 10)
            {
                return true;
            }
            else if (b >= 0x20)
                s += Convert.ToString(Convert.ToChar(b));
            return eol;
        }

        /// <summary>
        /// Formats the value returned by the OWON firmware.  
        /// The values returned are inconsistent sometimes they include a space before 
        /// the unit like 12.3 VDC but not always like 20.1VDC.
        /// Also sometimes it has a leading 0 like 029.00 this gets removed.
        /// Therefore this method will check for that and format the value accordingly.
        /// </summary>
        /// <param name="s">The value string to format.</param>
        /// <returns>Formatted value string.</returns>
        public static string FormatValue(string? s)
        {
            string fs = string.Empty;
            string delim = " ";
            bool isLeadingDigit = true;

            if (string.IsNullOrEmpty(s))
                return string.Empty;

            // Check for leading 0 and for space before unit
            bool hasDelim = s.Contains(' ');
            char c, nextc;
            int scanLen = s.Length-1;
            int lastChar = scanLen-1;

            for (int i = 0; i < scanLen; i++)
            {
                c = s[i]; nextc = s[i+1]; 
                if (!( isLeadingDigit && c == '0' && char.IsDigit(nextc) ))
                {
                    if (c != '-' && (c > '0' || c == '.'))
                        isLeadingDigit = false;

                    // Check for numeric digit or decimal place
                    if (char.IsDigit(c) || c == '.' || c == '-')
                        fs += c;
                    else // Make sure the unit has a space before it as a delimiter
                    {
                        if (hasDelim)
                            fs += c;
                        else
                            fs += delim + c;
                        delim = string.Empty;
                    }
                }
                if (i >= lastChar)
                    fs += delim + nextc;
            }
            return fs;
        }

        private const string ScpiMeasCmd = "MEAS:SHOW?"; //The Owon SCPI command to retrieve its current reading value
        private const string ScpiModeCmd = "FUNC?";  //The Owon SCPI command to retrieve the mode like Voltage, Current, Resistance etc.
        private SerialPort comPort;
        private string comPortName = "COM10"; //The virtual com port to use (will be set later from the settings file)
        private OwonValue measurement = new();
        private const int cmdDelay = 100; //The default delay after sending a SCPI command before checking for a response

        /// <summary>Gets the name of the COM port.</summary>
        /// <value>The name of the COM port like "COM10" etc..</value>
        public string ComPortName { get => comPortName; private set => comPortName = value; }
        public OwonValue Measurement { get => measurement; set => measurement = value; }

        /// <summary>Gets the current reading and mode from the Owon multimeter using the SCPI commands.</summary>
        /// <param name="delay">The delay, defaults to 100 micro seconds but can be overridden here.</param>
        /// <returns>
        ///   <c>true</c> if a valid reading was made, <c>false</c> otherwise.</returns>
        public bool GetScpiData(int delay = cmdDelay)
        {
            comPort.DiscardInBuffer();
            comPort.WriteLine(ScpiModeCmd);
            Thread.Sleep(delay);
            bool newData = ReadMeasurement(DataType.Mode);
            comPort.DiscardInBuffer();
            comPort.WriteLine(ScpiMeasCmd);
            Thread.Sleep(delay);
            newData |= ReadMeasurement(DataType.Value);
            return newData;
        }

        /// <summary>Opens the specified COM port for communications.</summary>
        /// <param name="comPortName">Name of the COM port.</param>
        /// <param name="baud">The baud rate, defaults to 115200.</param>
        /// <param name="parity">The parity defaults to None.</param>
        /// <param name="wordLen">Length of the word in bits, defaults to 8.</param>
        /// <param name="stopBits">The stop bit mode, defaults to one.</param>
        /// <exception cref="System.Exception">Com Port could not be opened.</exception>
        public void Open(string comPortName, int baud = 115200, Parity parity = Parity.None, int wordLen = 8, StopBits stopBits = StopBits.One)
        {
            comPort = new SerialPort(comPortName, baud, parity, wordLen, stopBits)
            {
                Handshake = Handshake.None,
                DiscardNull = true,
                ReadTimeout = 333,
                WriteTimeout = 333
                //ReadTimeout = -1, //Wait forever
                //WriteTimeout = -1
            };
            comPort.Open();
            measurement.Reset();
            if (comPort == null || !comPort.IsOpen) { throw new Exception($"{comPortName} could not be opened."); }
        }

        public OwonData(string comPortName, int baud = 115200, Parity parity = Parity.None, int wordLen = 8, StopBits stopBits = StopBits.One)
        {
            if (string.IsNullOrEmpty(comPortName))
                throw new ArgumentException($"Com Port Name was not specified.", paramName: nameof(comPortName));
            Open(comPortName, baud, parity, wordLen, stopBits);
        }

        /// <summary>Depending on the DataType specified will read the measurement or it will read the mode.
        /// If there was an error the ErrorMsg field will be set.</summary>
        /// <param name="type">Value or Mode</param>
        /// <returns>
        ///   <c>true</c> if successful, <c>false</c> otherwise.</returns>
        /// <exception cref="System.InvalidOperationException">COMxx port is not open, and measurement cannot be read.</exception>
        private bool ReadMeasurement(DataType type)
        {
            bool ReadMode()
            { 
                if (comPort.BytesToRead > 0)
                {
                    string m = comPort.ReadLine();
                    m = m.Trim().Trim('"');
                   switch (m)
                    {
                        case "VOLT":
                            measurement.Mode = "DC Voltage";
                            break;

                        case "VOLT AC":
                            measurement.Mode = "AC Voltage";
                            break;

                        case "CURR AC":
                            measurement.Mode = "AC Current";
                            break;

                        case "CURR":
                            measurement.Mode = "DC Current";
                            break;

                        case "FREQ":
                            measurement.Mode = "Frequency";
                            break;

                        case "PER":
                            measurement.Mode = "Period";
                            break;

                        case "CAP":
                            measurement.Mode = "Capacitance";
                            break;

                        case "CONT":
                            measurement.Mode = "Diode Mode";
                            break;

                        case "DIOD":
                            measurement.Mode = "Continuity";
                            break;

                        case "RES":
                            measurement.Mode = "Resistance";
                            break;

                        case "TEMP":
                            measurement.Mode = "Temperature";
                            break;

                        default:
                            measurement.Mode = string.Empty;
                            break;
                    }
                    return true;
                }
                measurement.Mode = string.Empty;
                return false;
            }

            bool ReadValue()
            {
                string newValue = string.Empty;
                while (comPort.BytesToRead > 0)
                {
                    byte b = (byte)comPort.ReadByte();
                    if (!DecodeByte(b, ref newValue))
                        continue;
                    measurement.IsReady = true;
                    measurement.Value = FormatValue(newValue);
                    break;
                }
                return measurement.IsReady;
            }

            try
            {
                if (!comPort.IsOpen)
                {
                    measurement.Reset();
                    throw new InvalidOperationException($"{ComPortName} port is not open, and measurement cannot be read.");
                }

                return type switch
                {
                    DataType.Value => ReadValue(),
                    DataType.Mode => ReadMode(),
                    _ => throw new InvalidOperationException(),
                };
            }
            catch (Exception ex)
            {
                measurement.ErrorMsg = ex.ToString();
                return false;
            }
        }

        /// <summary>Closes the COM port.</summary>
        public void Close()
        {
            if (comPort != null && comPort.IsOpen)
            {
                comPort.Close();
            }
        }

        /// <summary>Finalizes an instance of the <see cref="T:Owon.OwonCtrl" /> class and closes the COM Port.</summary>
        ~OwonData()
        {
            Close();
        }
    }
}