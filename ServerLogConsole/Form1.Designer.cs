namespace ServerLogConsole
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            grpConnection = new GroupBox();
            lblStatus = new Label();
            btnStart = new Button();
            txtPort = new TextBox();
            lblPort = new Label();
            txtIp = new TextBox();
            lblIp = new Label();
            rdServer = new RadioButton();
            rtbLog = new RichTextBox();
            txtMessage = new TextBox();
            btnSend = new Button();
            grpConnection.SuspendLayout();
            SuspendLayout();
            // 
            // grpConnection
            // 
            grpConnection.Controls.Add(lblStatus);
            grpConnection.Controls.Add(btnStart);
            grpConnection.Controls.Add(txtPort);
            grpConnection.Controls.Add(lblPort);
            grpConnection.Controls.Add(txtIp);
            grpConnection.Controls.Add(lblIp);
            grpConnection.Controls.Add(rdServer);
            grpConnection.Location = new Point(16, 19);
            grpConnection.Name = "grpConnection";
            grpConnection.Size = new Size(611, 151);
            grpConnection.TabIndex = 0;
            grpConnection.TabStop = false;
            grpConnection.Text = "Kết nối";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.ForeColor = Color.Green;
            lblStatus.Location = new Point(21, 106);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(101, 20);
            lblStatus.TabIndex = 7;
            lblStatus.Text = "Chưa kết nối...";
            // 
            // btnStart
            // 
            btnStart.Location = new Point(473, 34);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(115, 85);
            btnStart.TabIndex = 6;
            btnStart.Text = "Bắt đầu";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // txtPort
            // 
            txtPort.Location = new Point(340, 81);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(105, 27);
            txtPort.TabIndex = 5;
            txtPort.Text = "9000";
            // 
            // lblPort
            // 
            lblPort.AutoSize = true;
            lblPort.Location = new Point(271, 86);
            lblPort.Name = "lblPort";
            lblPort.Size = new Size(42, 20);
            lblPort.TabIndex = 4;
            lblPort.Text = "Port: ";
            // 
            // txtIp
            // 
            txtIp.Location = new Point(340, 41);
            txtIp.Name = "txtIp";
            txtIp.Size = new Size(105, 27);
            txtIp.TabIndex = 3;
            txtIp.Text = "127.0.0.1";
            // 
            // lblIp
            // 
            lblIp.AutoSize = true;
            lblIp.Location = new Point(271, 46);
            lblIp.Name = "lblIp";
            lblIp.Size = new Size(57, 20);
            lblIp.TabIndex = 2;
            lblIp.Text = "Server: ";
            // 
            // rdServer
            // 
            rdServer.AutoSize = true;
            rdServer.Checked = true;
            rdServer.Location = new Point(25, 41);
            rdServer.Name = "rdServer";
            rdServer.Size = new Size(71, 24);
            rdServer.TabIndex = 0;
            rdServer.TabStop = true;
            rdServer.Text = "Server";
            rdServer.UseVisualStyleBackColor = true;
            // 
            // rtbLog
            // 
            rtbLog.BackColor = Color.White;
            rtbLog.ForeColor = Color.Black;
            rtbLog.Location = new Point(16, 179);
            rtbLog.Name = "rtbLog";
            rtbLog.ReadOnly = true;
            rtbLog.Size = new Size(609, 326);
            rtbLog.TabIndex = 1;
            rtbLog.Text = "";
            rtbLog.TextChanged += txtChat_TextChanged;
            // 
            // txtMessage
            // 
            txtMessage.Location = new Point(16, 528);
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(488, 27);
            txtMessage.TabIndex = 2;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(513, 525);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(113, 35);
            btnSend.TabIndex = 3;
            btnSend.Text = "Gửi";
            btnSend.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AcceptButton = btnSend;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(645, 586);
            Controls.Add(btnSend);
            Controls.Add(txtMessage);
            Controls.Add(rtbLog);
            Controls.Add(grpConnection);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Server Log Console";
            grpConnection.ResumeLayout(false);
            grpConnection.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grpConnection;
        private RadioButton rdClient;
        private RadioButton rdServer;
        private TextBox txtPort;
        private Label lblPort;
        private TextBox txtIp;
        private Label lblIp;
        private Button btnStart;
        private RichTextBox rtbLog;
        private TextBox txtMessage;
        private Button btnSend;
        private Label lblStatus;
    }
}
