// See https://aka.ms/new-console-template for more information
using System.IO.Ports;
using static System.Console;
using OwonInfo;

/// <summary>This is a test console used to test SCPI commands and responces to the OWON XDM1041 multimeter.</summary>
internal class Program
{
    private static readonly OwonData owon = new("COM10", 115200, Parity.None, 8, StopBits.One);
    private static ConsoleKeyInfo? keyCode;
    private static string lastValue = string.Empty;
    private static string lastMode = string.Empty;

    /// <summary>Defines the entry point of the application.
    /// This console app is used to send SCPI commands to an OWON multimeter via the USB Virtual ComPort and to see the information returned.</summary>
    /// <param name="args">The arguments (not used).</param>
    private static void Main(string[] args)
    {

        WriteLine("OWON XDM1041 Test. (X to Exit)");

        while (keyCode == null)
        {
            if (Console.KeyAvailable)
            {
                keyCode = ReadKey();
                if (keyCode.HasValue && keyCode.Value.KeyChar != 'X')
                {
                    keyCode = null;
                    //break;
                }
            }
            if (owon.GetScpiData())
            {
                if (owon.Measurement.Value != lastValue || owon.Measurement.Mode != lastMode)
                {
                    if (!string.IsNullOrEmpty(owon.Measurement.Value))
                    {
                        WriteLine(owon.Measurement.Value);
                        WriteLine(owon.Measurement.Mode);
                        lastMode = owon.Measurement.Mode;
                        lastValue = owon.Measurement.Value;
                    }
                }
                if (owon.Measurement.HasError)
                {
                    WriteLine($"Error: {owon.Measurement.ErrorMsg}");
                    owon.Measurement.Reset();
                }
            }
        }
    }
}