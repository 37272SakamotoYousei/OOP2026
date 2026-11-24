
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Services {
    public class CityService {
        private readonly HttpClient _httpClient = new HttpClient {
            Timeout = TimeSpan.FromSeconds(20)
        };

        public List<string> GetPrefectures() {
            return new List<string>
            {
                "北海道",
                "青森県", "岩手県", "宮城県", "秋田県",
                "山形県", "福島県",
                "茨城県", "栃木県", "群馬県", "埼玉県",
                "千葉県", "東京都", "神奈川県",
                "新潟県", "富山県", "石川県", "福井県",
                "山梨県", "長野県", "岐阜県", "静岡県", "愛知県",
                "三重県", "滋賀県", "京都府", "大阪府",
                "兵庫県", "奈良県", "和歌山県",
                "鳥取県", "島根県", "岡山県", "広島県", "山口県",
                "徳島県", "香川県", "愛媛県", "高知県",
                "福岡県", "佐賀県", "長崎県", "熊本県",
                "大分県", "宮崎県", "鹿児島県", "沖縄県"
            };
        }

        public List<City> GetCities() {
            return new List<City>
            {
                new City("東京", 35.6762, 139.6503),
                new City("大阪", 34.6937, 135.5023),
                new City("名古屋", 35.1815, 136.9066),
                new City("札幌", 43.0618, 141.3545),
                new City("福岡", 33.5902, 130.4017),
                new City("横浜", 35.4437, 139.6380),
                new City("京都", 35.0116, 135.7681),
                new City("神戸", 34.6901, 135.1955),
                new City("仙台", 38.2682, 140.8694),
                new City("広島", 34.3853, 132.4553),
                new City("那覇", 26.2124, 127.6809),
                new City("金沢", 36.5613, 136.6562),
                new City("新潟", 37.9161, 139.0364),
                new City("静岡", 34.9756, 138.3828),
                new City("宇都宮", 36.5551, 139.8828),
                new City("前橋", 36.3895, 139.0634),
                new City("足利", 36.3402, 139.4497)
            };
        }

        public async Task<List<City>> SearchCitiesAsync(
            string cityName,
            string prefectureName) {
            string encodedName = Uri.EscapeDataString(cityName);

            string url =
                "https://geocoding-api.open-meteo.com/v1/search" +
                $"?name={encodedName}" +
                "&count=100" +
                "&language=ja" +
                "&format=json" +
                "&countryCode=JP";

            using HttpResponseMessage response =
                await _httpClient.GetAsync(url);

            response.EnsureSuccessStatusCode();

            string json =
                await response.Content.ReadAsStringAsync();

            using JsonDocument document =
                JsonDocument.Parse(json);

            List<City> cities = new List<City>();

            if (!document.RootElement.TryGetProperty(
                "results", out JsonElement results)) {
                return cities;
            }

            foreach (JsonElement result in results.EnumerateArray()) {
                string name = ReadString(result, "name");
                string prefecture = ReadString(result, "admin1");

                if (string.IsNullOrWhiteSpace(name))
                    continue;

                if (!IsSamePrefecture(prefecture, prefectureName))
                    continue;

                double latitude =
                    result.GetProperty("latitude").GetDouble();

                double longitude =
                    result.GetProperty("longitude").GetDouble();

                cities.Add(new City(
                    name,
                    latitude,
                    longitude,
                    prefectureName));
            }

            return cities
                .GroupBy(city => new {
                    city.Name,
                    city.Latitude,
                    city.Longitude
                })
                .Select(group => group.First())
                .ToList();
        }

        private string ReadString(
            JsonElement element,
            string propertyName) {
            if (element.TryGetProperty(
                propertyName, out JsonElement value)) {
                return value.GetString() ?? "";
            }

            return "";
        }

        private bool IsSamePrefecture(
            string apiPrefecture,
            string selectedPrefecture) {
            string api = NormalizePrefecture(apiPrefecture);
            string selected = NormalizePrefecture(selectedPrefecture);

            return api == selected;
        }

        private string NormalizePrefecture(string name) {
            return name
                .Replace("都", "")
                .Replace("道", "")
                .Replace("府", "")
                .Replace("県", "")
                .Trim();
        }
    }
}
