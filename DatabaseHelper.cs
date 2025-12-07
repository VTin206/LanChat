using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

public class DatabaseHelper
{
    private string connectionString =
        @"Server=.\SQLEXPRESS;Database=LanChatDB;Trusted_Connection=True;";


    public DatabaseHelper()
    {
        InitializeDatabase();
    }

    private void InitializeDatabase()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string sql = @"
                IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Users' AND xtype='U')
                CREATE TABLE Users (
                    Id INT IDENTITY(1,1) PRIMARY KEY,
                    Username NVARCHAR(50) UNIQUE NOT NULL,
                    Password NVARCHAR(256) NOT NULL,
                    Email NVARCHAR(100)
                )";

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }

    private string HashPassword(string password)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

            StringBuilder builder = new StringBuilder();
            foreach (var b in bytes)
                builder.Append(b.ToString("x2"));

            return builder.ToString();
        }
    }

    public bool RegisterUser(string username, string password, string email)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string checkSql = "SELECT COUNT(*) FROM Users WHERE Username = @u";
            using (SqlCommand checkCmd = new SqlCommand(checkSql, connection))
            {
                checkCmd.Parameters.AddWithValue("@u", username);
                int count = (int)checkCmd.ExecuteScalar();
                if (count > 0) return false;
            }

            string sql = "INSERT INTO Users (Username, Password, Email) VALUES (@u, @p, @e)";
            using (SqlCommand cmd = new SqlCommand(sql, connection))
            {
                cmd.Parameters.AddWithValue("@u", username);
                cmd.Parameters.AddWithValue("@p", HashPassword(password));
                cmd.Parameters.AddWithValue("@e", email);
                cmd.ExecuteNonQuery();
            }
        }

        return true;
    }

    public bool LoginUser(string username, string password)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string sql = "SELECT Password FROM Users WHERE Username = @u";
            using (SqlCommand cmd = new SqlCommand(sql, connection))
            {
                cmd.Parameters.AddWithValue("@u", username);
                var result = cmd.ExecuteScalar();

                if (result != null)
                {
                    string dbHash = result.ToString();
                    string inputHash = HashPassword(password);
                    return dbHash == inputHash;
                }
            }
        }

        return false;
    }
}
