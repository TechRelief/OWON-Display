using System;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;
using OwonInfo;
namespace OWON_Display
{
    public partial class FrmMain : Form
    {
        /// <summary>The owon
        /// object provides access to the methods to access the Owon multimeter via the virtual com port.</summary>
        private OwonData? owon;
        private bool started = false; //To keep track if the display is currrently active or not.
        public FrmMain()
        {
            InitializeComponent();
        }
        private void BtnStart_Click(object sender, EventArgs e)
        {
            MnuPopup.Show(BtnStart, 0, 0);
        }
        private void ItmStartStop_Click(object sender, EventArgs e)
        {
            BtnStart_Click(sender, e);
        }
        private void ResetDisplay()
        {
            TxtValue.Text = "-----";
            TxtMode.Text = string.Empty;
        }
        private void UpdateDisplay()
        {
            TxtValue.Text = owon.Measurement.Value;
            TxtMode.Text = owon.Measurement.Mode;
        }
        private void FrmMain_Load(object sender, EventArgs e)
        {
            ResetDisplay();
            try
            {
                string comPortName = Settings.Default.ComPort; //Get the comport to use like COM10 etc.  This value is edited using the About box field.
                owon = new(comPortName);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        private void ItmExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //These methods provide a means to allow a window without a border to be moved on screen.
        private bool mouseDown;
        private Point lastLocation;
        private void PnlMain_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }
        private void PnlMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);
                this.Update();
            }
        }
        private void PnlMain_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
        private void Stop(bool Reset = false)
        {
            started = false;
            UpdateTimer.Stop();
            if (Reset)
                ResetDisplay();
        }
        private void Start()
        {
            started = true;
            UpdateTimer.Start();
        }
        private void ItmStartStop_Click_1(object sender, EventArgs e)
        {
            if (started)
            {
                Stop(Reset: true);
            }
            else
            {
                Start();
            }
        }
        private void LblHandle_MouseDown(object sender, MouseEventArgs e)
        {
            PnlMain_MouseDown(sender, e);
        }
        private void LblHandle_MouseMove(object sender, MouseEventArgs e)
        {
            PnlMain_MouseMove(sender, e);
        }
        private void LblHandle_MouseUp(object sender, MouseEventArgs e)
        {
            PnlMain_MouseUp(sender, e);
        }
        private void ItmComPort_Click(object sender, EventArgs e)
        {
            try
            {
                using AboutBox box = new();
                string oldComPortName = Settings.Default.ComPort;
                box.ShowDialog(this);
                string newComPortName = Settings.Default.ComPort;
                if (oldComPortName != newComPortName)
                {
                    if (owon != null)
                    {
                        owon.Close();
                        owon.Open(newComPortName);
                    }
                }
            }
            catch (Exception ex)
            {
                Stop(Reset: true);
                MessageBox.Show(ex.Message);
            }
        }
        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            if (owon != null && owon.GetScpiData())
            {
                UpdateDisplay();
            }
        }
    }
}