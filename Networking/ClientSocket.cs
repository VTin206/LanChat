using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BasicChat.Networking
{
    internal class ClientSocket
    {
        private TcpClient client;
        private NetworkStream stream;
        private Thread listenThread;

        public string NickName { get; private set; }
        public bool IsConnected { get; private set; } = false;

        // Gửi event về UI
        public event Action<Message> OnMessageReceived;
        public event Action<string> OnDisconnected;

        // ================================
        // KẾT NỐI TỚI SERVER
        // ================================
        public void Connect(string ip, int port, string nickname)
        {
            try
            {
                client = new TcpClient();
                client.Connect(ip, port);

                stream = client.GetStream();
                IsConnected = true;

                NickName = nickname;

                // Gửi JSON nickname
                var hello = Message.System($"{nickname}");
                SendMessage(hello);

                // Bắt đầu lắng nghe
                listenThread = new Thread(ListenForMessages);
                listenThread.IsBackground = true;
                listenThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to connect: {ex.Message}");
            }
        }

        // ================================
        // GỬI MESSAGE JSON LÊN SERVER
        // ================================
        public void SendMessage(Message msg)
        {
            if (!IsConnected) return;
            if (msg == null) return;

            string json = msg.ToJson();
            byte[] buffer = Encoding.UTF8.GetBytes(json);

            try
            {
                stream.Write(buffer, 0, buffer.Length);
            }
            catch
            {
                Disconnect();
            }
        }

        // ================================
        // LUỒNG LẮNG NGHE SERVER
        // ================================
        private void ListenForMessages()
        {
            byte[] buffer = new byte[4096];

            while (IsConnected)
            {
                try
                {
                    int byteCount = stream.Read(buffer, 0, buffer.Length);

                    if (byteCount == 0)
                    {
                        Disconnect();
                        return;
                    }

                    string json = Encoding.UTF8.GetString(buffer, 0, byteCount);

                    Message msg = Message.FromJson(json);
                    OnMessageReceived?.Invoke(msg);
                }
                catch
                {
                    Disconnect();
                    return;
                }
            }
        }

        // ================================
        // NGẮT KẾT NỐI
        // ================================
        public void Disconnect()
        {
            if (!IsConnected) return;

            IsConnected = false;

            try { stream?.Close(); } catch { }
            try { client?.Close(); } catch { }

            OnDisconnected?.Invoke("Disconnected from server.");

            try { listenThread?.Join(); } catch { }
        }
    }
}
