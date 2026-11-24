
using System;
using System.Collections.Generic;

namespace WeatherApp.Models {
    public class WeatherData {
        // 現在の天気情報

        // 現在の気温
        public double Temperature { get; set; }

        // 現在の天気コード
        public int WeatherCode { get; set; }

        // 現在の湿度
        public int Humidity { get; set; }

        // 現在の風速
        public double WindSpeed { get; set; }

        // 7日間の天気予報
        public List<DailyWeatherData> DailyForecast { get; set; }
            = new List<DailyWeatherData>();

        //時間天気
        public List<HourlyWeatherData> HourlyForecast { get; set; }
            = new List<HourlyWeatherData>();

    }

    // 1日分の天気予報を管理するクラス
    public class DailyWeatherData {
        // 日付
        public DateTime Date { get; set; }

        // 天気コード
        public int WeatherCode { get; set; }

        // 最高気温
        public double MaxTemperature { get; set; }

        // 最低気温
        public double MinTemperature { get; set; }

        // 降水確率
        public int PrecipitationProbability { get; set; }
    }

    public class HourlyWeatherData {
        public DateTime Time { get; set; }

        public double Temperature { get; set; }

        public int WeatherCode { get; set; }

        public int PrecipitationProbability { get; set; }
    }

}
