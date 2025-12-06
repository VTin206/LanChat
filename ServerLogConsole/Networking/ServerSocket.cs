using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ServerLogConsole.Networking
{
    internal class ServerSocket
    {
        private TcpListener server;
        private Dictionary<string, TcpClient> clients = new();

        public bool IsRunning { get; private set; } = false;

        // Delegate log về form
        public Action<string, string>? Log;

        // Start server
        public void Start(int port)
        {
            server = new TcpListener(IPAddress.Any, port);
            server.Start();
            IsRunning = true;

            Log?.Invoke($"Server started on port {port}", "server");
            Log?.Invoke("Database initialized.", "info");

            Thread listenThread = new Thread(ListenForClients);
            listenThread.Start();
        }

        private void ListenForClients()
        {
            Log?.Invoke("Waiting for clients...", "info");

            while (IsRunning)
            {
                TcpClient client = server.AcceptTcpClient();
                Thread clientThread = new Thread(() => HandleClient(client));
                clientThread.Start();
            }
        }

        private void HandleClient(TcpClient client)
        {
            string nickname = "";
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[2048];

            try
            {
                // Nhận nickname
                int byteCount = stream.Read(buffer, 0, buffer.Length);
                nickname = Encoding.UTF8.GetString(buffer, 0, byteCount).Trim();

                lock (clients)
                {
                    clients[nickname] = client;
                }

                Log?.Invoke($"Client connected: {nickname}", "client");
                BroadcastOnlineList();

                while (true)
                {
                    byteCount = stream.Read(buffer, 0, buffer.Length);
                    if (byteCount == 0)
                    {
                        Log?.Invoke($"{nickname} disconnected.", "warn");
                        break;
                    }

                    string json = Encoding.UTF8.GetString(buffer, 0, byteCount);
                    Log?.Invoke($"[{nickname}] {json}", "client");
                }
            }
            catch (Exception ex)
            {
                Log?.Invoke("Client error: " + ex.Message, "error");
            }
            finally
            {
                lock (clients)
                {
                    if (nickname != "")
                        clients.Remove(nickname);
                }

                BroadcastOnlineList();
                client.Close();
            }
        }

        private void BroadcastOnlineList()
        {
            lock (clients)
            {
                Log?.Invoke("Online list updated.", "info");
            }
        }
    }
}
