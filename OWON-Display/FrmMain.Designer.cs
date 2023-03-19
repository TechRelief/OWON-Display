namespace OWON_Display
{
    partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            UpdateTimer = new System.Windows.Forms.Timer(components);
            TxtMode = new Label();
            TxtValue = new Label();
            PnlMain = new Panel();
            MnuPopup = new ContextMenuStrip(components);
            ItmStartStop = new ToolStripMenuItem();
            ItmComPort = new ToolStripMenuItem();
            ItmExit = new ToolStripMenuItem();
            LblHandle = new Label();
            BtnStart = new Label();
            PnlMain.SuspendLayout();
            MnuPopup.SuspendLayout();
            SuspendLayout();
            // 
            // UpdateTimer
            // 
            UpdateTimer.Interval = 250;
            UpdateTimer.Tick += UpdateTimer_Tick;
            // 
            // TxtMode
            // 
            TxtMode.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            TxtMode.ForeColor = Color.LimeGreen;
            TxtMode.Location = new Point(263, 9);
            TxtMode.Name = "TxtMode";
            TxtMode.Size = new Size(270, 60);
            TxtMode.TabIndex = 4;
            TxtMode.Text = "Capacitance";
            // 
            // TxtValue
            // 
            TxtValue.CausesValidation = false;
            TxtValue.Font = new Font("Segoe UI", 72F, FontStyle.Regular, GraphicsUnit.Point);
            TxtValue.Location = new Point(2, 53);
            TxtValue.Name = "TxtValue";
            TxtValue.Size = new Size(688, 158);
            TxtValue.TabIndex = 1;
            TxtValue.Text = "- 99.999 kO";
            TxtValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // PnlMain
            // 
            PnlMain.BackColor = Color.Transparent;
            PnlMain.CausesValidation = false;
            PnlMain.ContextMenuStrip = MnuPopup;
            PnlMain.Controls.Add(LblHandle);
            PnlMain.Controls.Add(BtnStart);
            PnlMain.Controls.Add(TxtValue);
            PnlMain.Controls.Add(TxtMode);
            PnlMain.Dock = DockStyle.Fill;
            PnlMain.Location = new Point(0, 0);
            PnlMain.Name = "PnlMain";
            PnlMain.Size = new Size(695, 218);
            PnlMain.TabIndex = 9;
            PnlMain.MouseDown += PnlMain_MouseDown;
            PnlMain.MouseMove += PnlMain_MouseMove;
            PnlMain.MouseUp += PnlMain_MouseUp;
            // 
            // MnuPopup
            // 
            MnuPopup.Items.AddRange(new ToolStripItem[] { ItmStartStop, ItmComPort, ItmExit });
            MnuPopup.Name = "MnuPopup";
            MnuPopup.Size = new Size(177, 70);
            // 
            // ItmStartStop
            // 
            ItmStartStop.Name = "ItmStartStop";
            ItmStartStop.Size = new Size(176, 22);
            ItmStartStop.Text = "&Start / Stop";
            ItmStartStop.ToolTipText = "Start or Stop the OWON display.";
            ItmStartStop.Click += ItmStartStop_Click_1;
            // 
            // ItmComPort
            // 
            ItmComPort.Name = "ItmComPort";
            ItmComPort.Size = new Size(176, 22);
            ItmComPort.Text = "&About && COM Port";
            ItmComPort.Click += ItmComPort_Click;
            // 
            // ItmExit
            // 
            ItmExit.Name = "ItmExit";
            ItmExit.Size = new Size(176, 22);
            ItmExit.Text = "&Exit";
            ItmExit.ToolTipText = "Exit the application.";
            ItmExit.Click += ItmExit_Click;
            // 
            // LblHandle
            // 
            LblHandle.AutoSize = true;
            LblHandle.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            LblHandle.ForeColor = Color.White;
            LblHandle.Location = new Point(661, 184);
            LblHandle.Name = "LblHandle";
            LblHandle.Size = new Size(29, 25);
            LblHandle.TabIndex = 10;
            LblHandle.Text = "◢";
            LblHandle.MouseDown += LblHandle_MouseDown;
            LblHandle.MouseMove += LblHandle_MouseMove;
            LblHandle.MouseUp += LblHandle_MouseUp;
            // 
            // BtnStart
            // 
            BtnStart.AutoSize = true;
            BtnStart.CausesValidation = false;
            BtnStart.Font = new Font("Segoe UI Black", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            BtnStart.ForeColor = Color.Orange;
            BtnStart.Location = new Point(654, 4);
            BtnStart.Name = "BtnStart";
            BtnStart.Size = new Size(36, 37);
            BtnStart.TabIndex = 9;
            BtnStart.Text = "≡";
            BtnStart.Click += BtnStart_Click;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            CausesValidation = false;
            ClientSize = new Size(695, 218);
            ControlBox = false;
            Controls.Add(PnlMain);
            Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = Color.Yellow;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmMain";
            ShowIcon = false;
            Text = "OWON XDM1041";
            Load += FrmMain_Load;
            PnlMain.ResumeLayout(false);
            PnlMain.PerformLayout();
            MnuPopup.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Timer UpdateTimer;
        private System.Windows.Forms.Label TxtMode;
        private System.Windows.Forms.Label TxtValue;
        private System.Windows.Forms.Panel PnlMain;
        private System.Windows.Forms.ContextMenuStrip MnuPopup;
        private System.Windows.Forms.ToolStripMenuItem ItmStartStop;
        private System.Windows.Forms.ToolStripMenuItem ItmComPort;
        private System.Windows.Forms.Label BtnStart;
        private System.Windows.Forms.ToolStripMenuItem ItmExit;
        private System.Windows.Forms.Label LblHandle;
    }
}