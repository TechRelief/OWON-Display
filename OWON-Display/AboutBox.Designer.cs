namespace OWON_Display
{
    partial class AboutBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutBox));
            tableLayoutPanel = new TableLayoutPanel();
            logoPictureBox = new PictureBox();
            labelProductName = new Label();
            labelVersion = new Label();
            labelCopyright = new Label();
            labelCompanyName = new Label();
            okButton = new Button();
            panel1 = new Panel();
            CboComPort = new ComboBox();
            TextHelp = new Label();
            LblAboutCom = new Label();
            TxtDescription = new Label();
            tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 2;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 67F));
            tableLayoutPanel.Controls.Add(logoPictureBox, 0, 0);
            tableLayoutPanel.Controls.Add(labelProductName, 1, 0);
            tableLayoutPanel.Controls.Add(labelVersion, 1, 1);
            tableLayoutPanel.Controls.Add(labelCopyright, 1, 2);
            tableLayoutPanel.Controls.Add(labelCompanyName, 1, 3);
            tableLayoutPanel.Controls.Add(okButton, 1, 6);
            tableLayoutPanel.Controls.Add(panel1, 1, 5);
            tableLayoutPanel.Controls.Add(TxtDescription, 1, 4);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Location = new Point(10, 10);
            tableLayoutPanel.Margin = new Padding(4, 3, 4, 3);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 8;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 9.847666F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 9.847666F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 9.847666F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 9.847666F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20.52934F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20.38467F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 19.69533F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel.Size = new Size(487, 307);
            tableLayoutPanel.TabIndex = 0;
            // 
            // logoPictureBox
            // 
            logoPictureBox.Dock = DockStyle.Fill;
            logoPictureBox.Image = (Image)resources.GetObject("logoPictureBox.Image");
            logoPictureBox.Location = new Point(4, 3);
            logoPictureBox.Margin = new Padding(4, 3, 4, 3);
            logoPictureBox.Name = "logoPictureBox";
            tableLayoutPanel.SetRowSpan(logoPictureBox, 7);
            logoPictureBox.Size = new Size(152, 278);
            logoPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            logoPictureBox.TabIndex = 12;
            logoPictureBox.TabStop = false;
            // 
            // labelProductName
            // 
            labelProductName.Dock = DockStyle.Fill;
            labelProductName.Location = new Point(167, 0);
            labelProductName.Margin = new Padding(7, 0, 4, 0);
            labelProductName.MaximumSize = new Size(0, 20);
            labelProductName.Name = "labelProductName";
            labelProductName.Size = new Size(316, 20);
            labelProductName.TabIndex = 19;
            labelProductName.Text = "OWON Multimeter Display";
            labelProductName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelVersion
            // 
            labelVersion.Dock = DockStyle.Fill;
            labelVersion.Location = new Point(167, 28);
            labelVersion.Margin = new Padding(7, 0, 4, 0);
            labelVersion.MaximumSize = new Size(0, 20);
            labelVersion.Name = "labelVersion";
            labelVersion.Size = new Size(316, 20);
            labelVersion.TabIndex = 0;
            labelVersion.Text = "Version 1.0";
            labelVersion.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelCopyright
            // 
            labelCopyright.Dock = DockStyle.Fill;
            labelCopyright.Location = new Point(167, 56);
            labelCopyright.Margin = new Padding(7, 0, 4, 0);
            labelCopyright.MaximumSize = new Size(0, 20);
            labelCopyright.Name = "labelCopyright";
            labelCopyright.Size = new Size(316, 20);
            labelCopyright.TabIndex = 21;
            labelCopyright.Text = "Copyright 2023";
            labelCopyright.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelCompanyName
            // 
            labelCompanyName.Dock = DockStyle.Fill;
            labelCompanyName.Location = new Point(167, 84);
            labelCompanyName.Margin = new Padding(7, 0, 4, 0);
            labelCompanyName.MaximumSize = new Size(0, 20);
            labelCompanyName.Name = "labelCompanyName";
            labelCompanyName.Size = new Size(316, 20);
            labelCompanyName.TabIndex = 22;
            labelCompanyName.Text = "Tech-Relief LLC";
            labelCompanyName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // okButton
            // 
            okButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            okButton.DialogResult = DialogResult.Cancel;
            okButton.Location = new Point(395, 254);
            okButton.Margin = new Padding(4, 3, 4, 3);
            okButton.Name = "okButton";
            okButton.Size = new Size(88, 27);
            okButton.TabIndex = 24;
            okButton.Text = "&OK";
            okButton.Click += okButton_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(CboComPort);
            panel1.Controls.Add(TextHelp);
            panel1.Controls.Add(LblAboutCom);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(163, 173);
            panel1.Name = "panel1";
            panel1.Size = new Size(321, 52);
            panel1.TabIndex = 25;
            // 
            // CboComPort
            // 
            CboComPort.FormattingEnabled = true;
            CboComPort.Items.AddRange(new object[] { "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8", "COM9", "COM10" });
            CboComPort.Location = new Point(67, 13);
            CboComPort.Name = "CboComPort";
            CboComPort.Size = new Size(69, 23);
            CboComPort.TabIndex = 3;
            CboComPort.Text = "COM10";
            // 
            // TextHelp
            // 
            TextHelp.Location = new Point(142, 0);
            TextHelp.Name = "TextHelp";
            TextHelp.Size = new Size(176, 52);
            TextHelp.TabIndex = 2;
            TextHelp.Text = "Select the COM serial port to communicate with the OWON Multimeter.";
            // 
            // LblAboutCom
            // 
            LblAboutCom.AutoSize = true;
            LblAboutCom.Location = new Point(4, 16);
            LblAboutCom.Name = "LblAboutCom";
            LblAboutCom.Size = new Size(63, 15);
            LblAboutCom.TabIndex = 0;
            LblAboutCom.Text = "COM Port:";
            // 
            // TxtDescription
            // 
            TxtDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TxtDescription.Location = new Point(163, 112);
            TxtDescription.Name = "TxtDescription";
            TxtDescription.Size = new Size(321, 58);
            TxtDescription.TabIndex = 26;
            TxtDescription.Text = "Provides a Windows Measurement Display for the OWON XDM1041 Multimeter via a COM Serial Port.\r\n";
            TxtDescription.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // AboutBox
            // 
            AcceptButton = okButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(507, 327);
            Controls.Add(tableLayoutPanel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AboutBox";
            Padding = new Padding(10);
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "About & Settings";
            Load += AboutBox_Load;
            tableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.Label labelProductName;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label labelCopyright;
        private System.Windows.Forms.Label labelCompanyName;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label TextHelp;
        private System.Windows.Forms.Label LblAboutCom;
        private System.Windows.Forms.ComboBox CboComPort;
        private Label TxtDescription;
    }
}
