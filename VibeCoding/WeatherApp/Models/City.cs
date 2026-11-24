
namespace WeatherApp.Models {
    public class City {
        public string Name { get; set; } = "";
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Prefecture { get; set; } = "";

        public City() {
        }

        public City(
            string name,
            double latitude,
            double longitude) {
            Name = name;
            Latitude = latitude;
            Longitude = longitude;
        }

        public City(
            string name,
            double latitude,
            double longitude,
            string prefecture) {
            Name = name;
            Latitude = latitude;
            Longitude = longitude;
            Prefecture = prefecture;
        }
    }
}
