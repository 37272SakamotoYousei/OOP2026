
using System;
using System.Globalization;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Services {
    public class WeatherService {
        private readonly HttpClient _httpClient = new HttpClient {
            Timeout = TimeSpan.FromSeconds(15)
        };

        public Task<WeatherData> GetCurrentWeatherAsync() {
            return GetCurrentWeatherAsync(
                new City("東京", 35.6762, 139.6503));
        }

        public async Task<WeatherData> GetCurrentWeatherAsync(City city) {
            string latitude =
                city.Latitude.ToString(CultureInfo.InvariantCulture);

            string longitude =
                city.Longitude.ToString(CultureInfo.InvariantCulture);

            string url =
                "https://api.open-meteo.com/v1/forecast" +
                $"?latitude={latitude}" +
                $"&longitude={longitude}" +
                "&current=temperature_2m,relative_humidity_2m,weather_code,wind_speed_10m" +
                "&hourly=temperature_2m,weather_code,precipitation_probability" +
                "&daily=weather_code,temperature_2m_max,temperature_2m_min,precipitation_probability_max" +
                "&forecast_days=7" +
                "&forecast_hours=24" +
                "&timezone=auto";

            using HttpResponseMessage response =
                await _httpClient.GetAsync(url);

            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();

            using JsonDocument document = JsonDocument.Parse(json);

            JsonElement root = document.RootElement;
            JsonElement current = root.GetProperty("current");

            DateTime currentTime = DateTime.Parse(
                current.GetProperty("time").GetString()!,
                CultureInfo.InvariantCulture);

            WeatherData weather = new WeatherData {
                Temperature =
                    current.GetProperty("temperature_2m").GetDouble(),

                Humidity =
                    current.GetProperty("relative_humidity_2m").GetInt32(),

                WeatherCode =
                    current.GetProperty("weather_code").GetInt32(),

                WindSpeed =
                    current.GetProperty("wind_speed_10m").GetDouble()
            };

            // 7日間の予報
            JsonElement daily = root.GetProperty("daily");

            JsonElement dates = daily.GetProperty("time");
            JsonElement weatherCodes = daily.GetProperty("weather_code");
            JsonElement maxTemperatures =
                daily.GetProperty("temperature_2m_max");

            JsonElement minTemperatures =
                daily.GetProperty("temperature_2m_min");

            JsonElement probabilities =
                daily.GetProperty("precipitation_probability_max");

            for (int i = 0; i < dates.GetArrayLength(); i++) {
                int probability = 0;
                probabilities[i].TryGetInt32(out probability);

                weather.DailyForecast.Add(new DailyWeatherData {
                    Date = DateTime.Parse(
                        dates[i].GetString()!,
                        CultureInfo.InvariantCulture),

                    WeatherCode = weatherCodes[i].GetInt32(),
                    MaxTemperature = maxTemperatures[i].GetDouble(),
                    MinTemperature = minTemperatures[i].GetDouble(),
                    PrecipitationProbability = probability
                });
            }

            // 現在時刻から24時間分の予報
            JsonElement hourly = root.GetProperty("hourly");

            JsonElement hourlyTimes = hourly.GetProperty("time");
            JsonElement hourlyTemperatures =
                hourly.GetProperty("temperature_2m");

            JsonElement hourlyCodes =
                hourly.GetProperty("weather_code");

            JsonElement hourlyProbabilities =
                hourly.GetProperty("precipitation_probability");

            DateTime endTime = currentTime.AddHours(24);

            for (int i = 0; i < hourlyTimes.GetArrayLength(); i++) {
                DateTime forecastTime = DateTime.Parse(
                    hourlyTimes[i].GetString()!,
                    CultureInfo.InvariantCulture);

                if (forecastTime < currentTime || forecastTime >= endTime)
                    continue;

                int probability = 0;
                hourlyProbabilities[i].TryGetInt32(out probability);

                weather.HourlyForecast.Add(new HourlyWeatherData {
                    Time = forecastTime,
                    Temperature = hourlyTemperatures[i].GetDouble(),
                    WeatherCode = hourlyCodes[i].GetInt32(),
                    PrecipitationProbability = probability
                });
            }

            return weather;
        }
    }
}
