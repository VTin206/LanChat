using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace BasicChat
{
    public partial class Form1 : Form
    {
        private TcpListener _listener;
        private TcpClient _client;
        private NetworkStream _stream;
        private CancellationTokenSource _cts = new CancellationTokenSource();
        private readonly object _streamLock = new object();
        private string _currentUser;

        // Sửa lại hàm khởi tạo để nhận tham số username
        public Form1(string username)
        {
            InitializeComponent();

            // 1. Lưu tên người dùng lại để dùng sau này
            _currentUser = username;

            // 2. Hiển thị tên lên tiêu đề cửa sổ cho đẹp
            this.Text = "LanChat - Xin chào: " + _currentUser;

            // 3. Các thiết lập mặc định cũ của bạn (giữ nguyên)
            rdServer.Checked = true;
            txtIp.Text = "127.0.0.1";
            txtPort.Text = "9000";
            UpdateUIForMode();

            rdServer.CheckedChanged += (s, e) => UpdateUIForMode();
            rdClient.CheckedChanged += (s, e) => UpdateUIForMode();
        }

        private void UpdateUIForMode()
        {
            // Server không cần IP, Client cần IP của server
            bool isClient = rdClient.Checked;
            txtIp.Visible = isClient;
            lblIp.Visible = isClient;
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtPort.Text, out int port))
            {
                MessageBox.Show("Port không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnStart.Enabled = false;
            if (rdServer.Checked)
            {
                StartServer(port);
            }
            else
            {
                await ConnectAsClient(txtIp.Text.Trim(), port);
            }
        }

        private void StartServer(int port)
        {
            try
            {
                _listener = new TcpListener(IPAddress.Any, port);
                _listener.Start();
                AppendChat("Đang lắng nghe ...");
                lblStatus.Text = "Server đang chờ kết nối";
                _ = AcceptClientAsync(_cts.Token);
            }
            catch (Exception ex)
            {
                AppendChat("Lỗi: " + ex.Message);
                btnStart.Enabled = true;
            }
        }

        private async Task AcceptClientAsync(CancellationToken token)
        {
            try
            {
                _client = await _listener.AcceptTcpClientAsync();
                _stream = _client.GetStream();
                UpdateStatus("Client đã kết nối");
                StartReceiveLoop(token);
            }
            catch (ObjectDisposedException)
            {
                // Đã đóng
            }
            catch (Exception ex)
            {
                AppendChat("Lỗi: " + ex.Message);
                SafeEnableStart();
            }
        }

        private async Task ConnectAsClient(string ip, int port)
        {
            try
            {
                _client = new TcpClient();
                await _client.ConnectAsync(IPAddress.Parse(ip), port);
                _stream = _client.GetStream();
                UpdateStatus("Đã kết nối server");
                StartReceiveLoop(_cts.Token);
            }
            catch (Exception ex)
            {
                AppendChat("Không kết nối được: " + ex.Message);
                btnStart.Enabled = true;
            }
        }

        private void StartReceiveLoop(CancellationToken token)
        {
            Task.Run(async () =>
            {
                var buffer = new byte[1024];
                try
                {
                    while (!token.IsCancellationRequested)
                    {
                        int len = await _stream.ReadAsync(buffer, 0, buffer.Length, token);
                        if (len <= 0) break;
                        string text = Encoding.UTF8.GetString(buffer, 0, len);
                        AppendChat("Peer: " + text);
                    }
                }
                catch (Exception ex)
                {
                    AppendChat("Ngắt kết nối: " + ex.Message);
                }
                finally
                {
                    UpdateStatus("Đã ngắt");
                    SafeEnableStart();
                }
            }, token);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string msg = txtMessage.Text.Trim();
            if (string.IsNullOrEmpty(msg)) return;

            lock (_streamLock)
            {
                if (_stream == null || !_stream.CanWrite)
                {
                    AppendChat("Chưa sẵn sàng gửi.");
                    return;
                }

                byte[] data = Encoding.UTF8.GetBytes(msg);
                _stream.Write(data, 0, data.Length);
            }

            AppendChat(_currentUser + ": " + msg);
            txtMessage.Clear();
        }

        private void AppendChat(string text)
        {
            if (txtChat.InvokeRequired)
            {
                txtChat.Invoke(new Action<string>(AppendChat), text);
                return;
            }

            txtChat.AppendText(text + Environment.NewLine);
        }

        private void UpdateStatus(string text)
        {
            if (lblStatus.InvokeRequired)
            {
                lblStatus.Invoke(new Action<string>(UpdateStatus), text);
                return;
            }
            lblStatus.Text = text;
        }

        private void SafeEnableStart()
        {
            if (btnStart.InvokeRequired)
            {
                btnStart.Invoke(new Action(SafeEnableStart));
                return;
            }
            btnStart.Enabled = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _cts.Cancel();
            try { _stream?.Close(); } catch { }
            try { _client?.Close(); } catch { }
            try { _listener?.Stop(); } catch { }
        }
    }
}
