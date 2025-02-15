using System;

namespace TimeTracker.Models
{
    public class ProcessUsage
    {
        public int Id { get; set; }
        public string AppName { get; set; }
        public DateTime LastStart { get; set; }
        public DateTime? LastStop { get; set; }
        public TimeSpan TotalTime { get; set; }
        public int Streak { get; set; } // Дни подряд
    }
}
