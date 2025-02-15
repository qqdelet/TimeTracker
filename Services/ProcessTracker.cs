using System.Diagnostics;
using System.Timers;
using TimeTracker.Models;
using TimeTracker.Services;

namespace TimeTracker
{
    public class ProcessTracker
    {
        private readonly DatabaseService _dbService;
        private readonly Dictionary<int, (string AppName, DateTime StartTime)> _runningProcesses = new();
        private readonly System.Timers.Timer _timer;

        public ProcessTracker()
        {
            _dbService = new DatabaseService();
            _timer = new System.Timers.Timer(5000); // Проверять процессы каждые 5 секунд
            _timer.Elapsed += CheckProcesses;
        }
        public void StartTracking()
        {
            _runningProcesses.Clear();
            var processes = Process.GetProcesses()
                                   .Where(p => !string.IsNullOrEmpty(p.ProcessName))
                                   .Select(p => new { p.Id, p.ProcessName })
                                   .ToList();

            foreach (var process in processes)
            {
                if (!_runningProcesses.ContainsKey(process.Id))
                {
                    _runningProcesses[process.Id] = (process.ProcessName, DateTime.Now);
                    Console.WriteLine($"Процесс уже работал: {process.ProcessName} (ID: {process.Id})");
                }
            }

            _timer.Start();
        }

        public void StopTracking()
        {
            _timer.Stop();
            Console.WriteLine("Трекер процессов остановлен.");
        }

        private void CheckProcesses(object sender, ElapsedEventArgs e)
        {
            var processes = Process.GetProcesses()
                                   .Where(p => !string.IsNullOrEmpty(p.ProcessName))
                                   .Select(p => new { p.Id, p.ProcessName })
                                   .ToList();

            // Фиксируем запущенные процессы
            foreach (var process in processes)
            {
                if (!_runningProcesses.ContainsKey(process.Id))
                {
                    _runningProcesses[process.Id] = (process.ProcessName, DateTime.Now);
                    Console.WriteLine($"Запуск: {process.ProcessName}");
                }
            }

            // Определяем закрытые процессы
            var closedProcesses = _runningProcesses.Keys.Except(processes.Select(p => p.Id)).ToList();
            foreach (var pid in closedProcesses)
            {

                (string appName, DateTime startTime) = _runningProcesses[pid];
                DateTime stopTime = DateTime.Now;
                TimeSpan duration = stopTime - startTime;

                _dbService.SaveProcessUsage(new ProcessUsage
                {
                    AppName = appName,  // ✅ Теперь имя процесса будет правильным
                    LastStart = startTime,
                    LastStop = stopTime,
                    TotalTime = duration,
                    Streak = 1
                });
                Console.WriteLine($"Закрыто: {_runningProcesses[pid]}, время работы: {duration}");
                _runningProcesses.Remove(pid);
            }
        }
    }
}
