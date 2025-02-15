using System;
using System.IO;
namespace TimeTracker.Services
{
    public static class LogerServices
    {
        private static readonly string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log.txt");

        public static void Log(string message)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    writer.WriteLine($"{DateTime.Now}: {message}");
                }
            }
            catch (Exception ex)
            {
                // Обработка ошибок, если логирование не удалось
                Console.WriteLine($"Ошибка логирования: {ex.Message}");
            }
        }
    }
}