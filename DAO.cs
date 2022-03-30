using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

namespace LoginComponent
{
    public class DAO
    {
        private SqliteConnection _connection;
        public DAO()
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder();
            connectionStringBuilder.Mode = SqliteOpenMode.ReadWriteCreate;
            connectionStringBuilder.DataSource = "../../../database/users.db";

            _connection = new SqliteConnection(connectionStringBuilder.ConnectionString);
            _connection.Open();

            Execute("DROP TABLE IF EXISTS LoginCredentials");
            Execute("CREATE TABLE LoginCredentials(email VARCHAR(255), hashedPassword VARCHAR(255), salt VARCHAR(255))");
        }

        private void Execute(string sql)
        {
            var cmd = _connection.CreateCommand();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }

        public bool Login(string email, string password)
        {
            return true;
        }

        public bool CreateLogin(string email, string password)
        {
            var insertCmd = new SqliteCommand("INSERT INTO LoginCredentials(email, password) VALUES(@email, @password)");
            insertCmd.Connection = _connection;

            var pEmail = new SqliteParameter("email", email);
            insertCmd.Parameters.Add(pEmail);
            var pPassword = new SqliteParameter("password", password);
            insertCmd.Parameters.Add(pPassword);
            insertCmd.ExecuteNonQuery();

            return true;
        }

        public bool UpdateLogin(string email, string newPassword, string oldPassword)
        {
            var insertCmd = new SqliteCommand("UPDATE LoginCredentials SET password = @newPassword WHERE email = @email AND password = @oldPassword)");
            insertCmd.Connection = _connection;

            var pEmail = new SqliteParameter("email", email);
            insertCmd.Parameters.Add(pEmail);
            var pPassword = new SqliteParameter("password", newPassword);
            insertCmd.Parameters.Add(pPassword);
            insertCmd.ExecuteNonQuery();

            return true;
        }


    }
}