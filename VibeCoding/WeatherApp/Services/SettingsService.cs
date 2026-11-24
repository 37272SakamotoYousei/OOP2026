
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using WeatherApp.Models;

namespace WeatherApp.Services {
    public class AppSettings {
        public List<City> Favorites { get; set; } = new List<City>();
        public bool IsDarkMode { get; set; }
    }

    public class SettingsService {
        private readonly string _filePath;

        public SettingsService() {
            string folder = Path.Combine(
                Environment.GetFolderPath(
                    Environment.SpecialFolder.ApplicationData),
                "WeatherApp");

            Directory.CreateDirectory(folder);

            _filePath = Path.Combine(folder, "settings.json");
        }

        public AppSettings Load() {
            try {
                if (!File.Exists(_filePath))
                    return new AppSettings();

                string json = File.ReadAllText(_filePath);

                return JsonSerializer.Deserialize<AppSettings>(json)
                    ?? new AppSettings();
            }
            catch {
                return new AppSettings();
            }
        }

        public void Save(AppSettings settings) {
            string json = JsonSerializer.Serialize(
                settings,
                new JsonSerializerOptions {
                    WriteIndented = true
                });

            File.WriteAllText(_filePath, json);
        }
    }
}
