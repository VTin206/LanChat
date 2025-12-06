using System;
using System.Text.Json;

namespace ServerLogConsole.Networking
{
    public class Message
    {
        public string Type { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Text { get; set; }
        public string[] Users { get; set; }
        public string Timestamp { get; set; } = DateTime.UtcNow.ToString("o");

        public string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }

        public static Message FromJson(string json)
        {
            try
            {
                return JsonSerializer.Deserialize<Message>(json);
            }
            catch
            {
                return new Message
                {
                    Type = "system",
                    Text = "Invalid JSON received."
                };
            }
        }

        public static Message System(string text)
        {
            return new Message { Type = "system", Text = text };
        }

        public static Message Chat(string from, string text)
        {
            return new Message { Type = "message", From = from, Text = text };
        }

        public static Message Private(string from, string to, string text)
        {
            return new Message { Type = "private", From = from, To = to, Text = text };
        }

        public static Message Online(string[] users)
        {
            return new Message { Type = "online", Users = users };
        }
    }
}
