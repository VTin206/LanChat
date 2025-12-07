using System;
using System.Data.SQLite;
using System.IO;
using System.Security.Cryptography; //Dùng để mã hoá mật khẩu
using System.Text;

public class DatabaseHelper
{
    private const string DatabaseName = "LanChatUser.db";
    private string connectionString = $"Data Source={DatabaseName};Version=3;";

    public DatabaseHelper()
    {
        InitializeDatabase();
    }

    private void InitializeDatabase()
    {
        if (!File.Exists(DatabaseName))
        {
            SQLiteConnection.CreateFile(DatabaseName);
        }

        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            string sql = @"
                CREATE TABLE IF NOT EXISTS Users (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Username TEXT UNIQUE NOT NULL,
                    Password TEXT NOT NULL,
                    Email TEXT
                )";

            using (var command = new SQLiteCommand(sql, connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }

    // Hàm băm mật khẩu sử dụng SHA256
    private string HashPassword(string password)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            // Chuyển chuỗi thành mảng byte
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

            // Chuyển mảng byte ngược lại thành chuỗi Hex để lưu vào DB
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }

    public bool RegisterUser(string username, string password, string email)
    {
        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();

            string checkSql = "SELECT COUNT(*) FROM Users WHERE Username = @u";
            using (var checkCmd = new SQLiteCommand(checkSql, connection))
            {
                checkCmd.Parameters.AddWithValue("@u", username);
                int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                if (count > 0) return false;
            }

            string sql = "INSERT INTO Users (Username, Password, Email) VALUES (@u, @p, @e)";
            using (var command = new SQLiteCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@u", username);

                string encryptedPass = HashPassword(password);
                command.Parameters.AddWithValue("@p", encryptedPass);

                command.Parameters.AddWithValue("@e", email);
                command.ExecuteNonQuery();
            }
        }
        return true;
    }

    public bool LoginUser(string username, string password)
    {
        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            string sql = "SELECT Password FROM Users WHERE Username = @u";

            using (var command = new SQLiteCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@u", username);
                var result = command.ExecuteScalar();

                if (result != null)
                {
                    string dbPasswordHash = result.ToString();
                    string inputPasswordHash = HashPassword(password);

                    // So sánh 2 chuỗi đã băm với nhau
                    return dbPasswordHash == inputPasswordHash;
                }
            }
        }
        return false;
    }
}