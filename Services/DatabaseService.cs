using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using TimeTracker.Models;

namespace TimeTracker.Services
{
    public class DatabaseService
    {
        private readonly string _dbPath;

        public DatabaseService()
        {
            _dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "time_tracker.db");
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            using var connection = new SqliteConnection($"Data Source={_dbPath}");
            connection.Open();

            string createTableQuery = @"
                CREATE TABLE IF NOT EXISTS ProcessUsage (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    AppName TEXT NOT NULL,
                    LastStart DATETIME NOT NULL,
                    LastStop DATETIME,
                    TotalTime TEXT NOT NULL,
                    Streak INTEGER NOT NULL
                );";

            using var command = new SqliteCommand(createTableQuery, connection);
            command.ExecuteNonQuery();
        }

        public void SaveProcessUsage(ProcessUsage process)
        {
            using var connection = new SqliteConnection($"Data Source={_dbPath}");
            connection.Open();

            string query = @"
                INSERT INTO ProcessUsage (AppName, LastStart, LastStop, TotalTime, Streak)
                VALUES (@AppName, @LastStart, @LastStop, @TotalTime, @Streak)";

            using var command = new SqliteCommand(query, connection);
            command.Parameters.AddWithValue("@AppName", process.AppName);
            command.Parameters.AddWithValue("@LastStart", process.LastStart);
            command.Parameters.AddWithValue("@LastStop", process.LastStop ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@TotalTime", process.TotalTime.ToString());
            command.Parameters.AddWithValue("@Streak", process.Streak);
            command.ExecuteNonQuery();
        }

        public List<ProcessUsage> GetProcessUsages()
        {
            var processes = new List<ProcessUsage>();

            using var connection = new SqliteConnection($"Data Source={_dbPath}");
            connection.Open();

            string query = "SELECT * FROM ProcessUsage";
            using var command = new SqliteCommand(query, connection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                processes.Add(new ProcessUsage
                {
                    Id = reader.GetInt32(0),
                    AppName = reader.GetString(1),
                    LastStart = reader.GetDateTime(2),
                    LastStop = reader.IsDBNull(3) ? (DateTime?)null : reader.GetDateTime(3),
                    TotalTime = TimeSpan.Parse(reader.GetString(4)),
                    Streak = reader.GetInt32(5)
                });
            }

            return processes;
        }
    }
}
