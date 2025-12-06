using ServerLogConsole.Networking;
using System;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace ServerLogConsole
{
    public partial class Form1 : Form
    {
        private ServerSocket server;

        public Form1()
        {
            InitializeComponent();

            string ip = GetLocalIPAddress();
            txtIp.Text = ip;
        }

        // Hàm public để ghi log từ thread khác
        public void AddLog(string message, string type = "info")
        {
            if (rtbLog.InvokeRequired)
            {
                rtbLog.Invoke(new Action(() => WriteLog(message, type)));
            }
            else
            {
                WriteLog(message, type);
            }
        }

        // Ghi log theo màu + timestamp
        private void WriteLog(string message, string type)
        {
            Color color = Color.White;

            switch (type)
            {
                case "info": color = Color.White; break;
                case "warn": color = Color.Yellow; break;
                case "error": color = Color.Red; break;
                case "client": color = Color.Cyan; break;
                case "server": color = Color.Lime; break;
            }

            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            rtbLog.SelectionStart = rtbLog.TextLength;
            rtbLog.SelectionColor = color;
            rtbLog.AppendText($"[{timestamp}] {message}\n");
            rtbLog.ScrollToCaret();
        }

        // Nút Start
        private void btnStart_Click(object sender, EventArgs e)
        {
            int port = int.Parse(txtPort.Text);

            server = new ServerSocket();
            server.Log = (msg, type) => AddLog(msg, type);

            server.Start(port);

            AddLog("Server started!", "server");
        }
        private string GetLocalIPAddress()
        {
            string localIP = "127.0.0.1";
            var host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                    break;
                }
            }
            return localIP;
        }

        private void txtChat_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
