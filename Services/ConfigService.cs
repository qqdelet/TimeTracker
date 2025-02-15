using System;
using System.IO;
using System.Text;

namespace TimeTracker.Services
{
    public class ConfigService
    {
        private readonly string _configPath = "config.ini";

        public bool AutoUpdate { get; private set; }
        public bool DarkMode { get; private set; }

        public ConfigService()
        {
            LoadSettings();
        }

        private void LoadSettings()
        {
            if (!File.Exists(_configPath))
            {
                SaveSettings(false, false);
                return;
            }

            foreach (var line in File.ReadAllLines(_configPath))
            {
                if (line.StartsWith("AutoUpdate="))
                    AutoUpdate = line.Split('=')[1].Trim().ToLower() == "true";

                if (line.StartsWith("DarkMode="))
                    DarkMode = line.Split('=')[1].Trim().ToLower() == "true";
            }
        }

        public void SaveSettings(bool autoUpdate, bool darkMode)
        {
            AutoUpdate = autoUpdate;
            DarkMode = darkMode;

            StringBuilder config = new StringBuilder();
            config.AppendLine($"AutoUpdate={AutoUpdate.ToString().ToLower()}");
            config.AppendLine($"DarkMode={DarkMode.ToString().ToLower()}");

            File.WriteAllText(_configPath, config.ToString());
        }
    }
}
