namespace BasicChat
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpConnection = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.txtIp = new System.Windows.Forms.TextBox();
            this.lblIp = new System.Windows.Forms.Label();
            this.rdClient = new System.Windows.Forms.RadioButton();
            this.rdServer = new System.Windows.Forms.RadioButton();
            this.txtChat = new System.Windows.Forms.TextBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.grpConnection.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpConnection
            // 
            this.grpConnection.Controls.Add(this.lblStatus);
            this.grpConnection.Controls.Add(this.btnStart);
            this.grpConnection.Controls.Add(this.txtPort);
            this.grpConnection.Controls.Add(this.lblPort);
            this.grpConnection.Controls.Add(this.txtIp);
            this.grpConnection.Controls.Add(this.lblIp);
            this.grpConnection.Controls.Add(this.rdClient);
            this.grpConnection.Controls.Add(this.rdServer);
            this.grpConnection.Location = new System.Drawing.Point(16, 15);
            this.grpConnection.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpConnection.Name = "grpConnection";
            this.grpConnection.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpConnection.Size = new System.Drawing.Size(611, 121);
            this.grpConnection.TabIndex = 0;
            this.grpConnection.TabStop = false;
            this.grpConnection.Text = "Kết nối";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.ForeColor = System.Drawing.Color.Green;
            this.lblStatus.Location = new System.Drawing.Point(21, 85);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(89, 16);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.Text = "Chưa kết nối...";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(473, 27);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(115, 68);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Bắt đầu";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(340, 65);
            this.txtPort.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(105, 22);
            this.txtPort.TabIndex = 5;
            this.txtPort.Text = "9000";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(271, 69);
            this.lblPort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(37, 16);
            this.lblPort.TabIndex = 4;
            this.lblPort.Text = "Port: ";
            // 
            // txtIp
            // 
            this.txtIp.Location = new System.Drawing.Point(340, 33);
            this.txtIp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(105, 22);
            this.txtIp.TabIndex = 3;
            this.txtIp.Text = "127.0.0.1";
            // 
            // lblIp
            // 
            this.lblIp.AutoSize = true;
            this.lblIp.Location = new System.Drawing.Point(271, 37);
            this.lblIp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIp.Name = "lblIp";
            this.lblIp.Size = new System.Drawing.Size(53, 16);
            this.lblIp.TabIndex = 2;
            this.lblIp.Text = "Server: ";
            // 
            // rdClient
            // 
            this.rdClient.AutoSize = true;
            this.rdClient.Location = new System.Drawing.Point(129, 33);
            this.rdClient.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdClient.Name = "rdClient";
            this.rdClient.Size = new System.Drawing.Size(61, 20);
            this.rdClient.TabIndex = 1;
            this.rdClient.Text = "Client";
            this.rdClient.UseVisualStyleBackColor = true;
            // 
            // rdServer
            // 
            this.rdServer.AutoSize = true;
            this.rdServer.Checked = true;
            this.rdServer.Location = new System.Drawing.Point(25, 33);
            this.rdServer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdServer.Name = "rdServer";
            this.rdServer.Size = new System.Drawing.Size(68, 20);
            this.rdServer.TabIndex = 0;
            this.rdServer.TabStop = true;
            this.rdServer.Text = "Server";
            this.rdServer.UseVisualStyleBackColor = true;
            // 
            // txtChat
            // 
            this.txtChat.Location = new System.Drawing.Point(16, 143);
            this.txtChat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtChat.Multiline = true;
            this.txtChat.Name = "txtChat";
            this.txtChat.ReadOnly = true;
            this.txtChat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtChat.Size = new System.Drawing.Size(609, 262);
            this.txtChat.TabIndex = 1;
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(16, 422);
            this.txtMessage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(488, 22);
            this.txtMessage.TabIndex = 2;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(513, 420);
            this.btnSend.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(113, 28);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "Gửi";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.btnSend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 469);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.txtChat);
            this.Controls.Add(this.grpConnection);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LanChat - Siêu cơ bản";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.grpConnection.ResumeLayout(false);
            this.grpConnection.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpConnection;
        private System.Windows.Forms.RadioButton rdClient;
        private System.Windows.Forms.RadioButton rdServer;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox txtIp;
        private System.Windows.Forms.Label lblIp;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtChat;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label lblStatus;
    }
}
