
using System;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp {
    public partial class MainWindow : Window {
        private readonly WeatherService _weatherService;
        private readonly CityService _cityService;
        private readonly SettingsService _settingsService;

        private AppSettings _settings;
        private City _selectedCity;
        private bool _isLoading;

        public MainWindow() {
            InitializeComponent();

            _weatherService = new WeatherService();
            _cityService = new CityService();
            _settingsService = new SettingsService();

            _settings = _settingsService.Load();

            // 都道府県一覧
            PrefectureComboBox.ItemsSource =
                _cityService.GetPrefectures();

            PrefectureComboBox.SelectedItem = "栃木県";

            // 初期都市一覧
            CityComboBox.ItemsSource = _cityService.GetCities();
            CityComboBox.DisplayMemberPath = "Name";
            CityComboBox.SelectedIndex = 0;

            _selectedCity = (City)CityComboBox.SelectedItem;

            UpdateFavoriteList();
            ApplyTheme();

            // イベント登録
            CityComboBox.SelectionChanged +=
                CityComboBox_SelectionChanged;

            FavoriteComboBox.SelectionChanged +=
                FavoriteComboBox_SelectionChanged;

            SearchButton.Click += SearchButton_Click;
            RefreshButton.Click += RefreshButton_Click;
            AddFavoriteButton.Click += AddFavoriteButton_Click;
            RemoveFavoriteButton.Click += RemoveFavoriteButton_Click;
            ThemeButton.Click += ThemeButton_Click;

            Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(
            object sender, RoutedEventArgs e) {
            await GetWeatherAsync(_selectedCity);
        }

        // 都市選択
        private async void CityComboBox_SelectionChanged(
            object sender, SelectionChangedEventArgs e) {
            if (_isLoading || CityComboBox.SelectedItem == null)
                return;

            City city = (City)CityComboBox.SelectedItem;

            _selectedCity = city;

            await GetWeatherAsync(city);
        }

        // お気に入り選択
        private async void FavoriteComboBox_SelectionChanged(
            object sender, SelectionChangedEventArgs e) {
            if (_isLoading || FavoriteComboBox.SelectedItem == null)
                return;

            City city = (City)FavoriteComboBox.SelectedItem;

            _selectedCity = city;

            await GetWeatherAsync(city);
        }

        // お気に入り登録
        private void AddFavoriteButton_Click(
            object sender, RoutedEventArgs e) {
            if (_selectedCity == null)
                return;

            bool exists = _settings.Favorites.Any(city =>
                city.Name == _selectedCity.Name &&
                city.Latitude == _selectedCity.Latitude &&
                city.Longitude == _selectedCity.Longitude);

            if (exists) {
                MessageBox.Show("この地域はすでに登録されています。");
                return;
            }

            _settings.Favorites.Add(new City(
                _selectedCity.Name,
                _selectedCity.Latitude,
                _selectedCity.Longitude));

            SaveSettings();
            UpdateFavoriteList();

            MessageBox.Show("お気に入りに登録しました。");
        }

        // お気に入り削除
        private void RemoveFavoriteButton_Click(
            object sender, RoutedEventArgs e) {
            if (FavoriteComboBox.SelectedItem == null) {
                MessageBox.Show("削除する地域を選択してください。");
                return;
            }

            City city = (City)FavoriteComboBox.SelectedItem;

            _settings.Favorites.RemoveAll(item =>
                item.Name == city.Name &&
                item.Latitude == city.Latitude &&
                item.Longitude == city.Longitude);

            SaveSettings();
            UpdateFavoriteList();
        }

        private void UpdateFavoriteList() {
            FavoriteComboBox.ItemsSource = null;
            FavoriteComboBox.ItemsSource = _settings.Favorites;
            FavoriteComboBox.DisplayMemberPath = "Name";
            FavoriteComboBox.SelectedIndex = -1;
        }

        private void SaveSettings() {
            try {
                _settingsService.Save(_settings);
            }
            catch (Exception ex) {
                MessageBox.Show(
                    "設定を保存できませんでした。\n" + ex.Message);
            }
        }

        // ライト・ダーク切り替え
        private void ThemeButton_Click(
            object sender, RoutedEventArgs e) {
            _settings.IsDarkMode = !_settings.IsDarkMode;

            ApplyTheme();
            SaveSettings();
        }

        private void ApplyTheme() {
            if (_settings.IsDarkMode) {
                Resources["AppBackground"] =
                    new SolidColorBrush(Color.FromRgb(16, 24, 39));

                Resources["Surface"] =
                    new SolidColorBrush(Color.FromRgb(29, 43, 66));

                Resources["PrimaryText"] =
                    new SolidColorBrush(Colors.White);

                Resources["MutedText"] =
                    new SolidColorBrush(Color.FromRgb(183, 200, 232));

                Resources["Accent"] =
                    new SolidColorBrush(Color.FromRgb(67, 139, 255));

                Resources["HeroBackground"] =
                    new SolidColorBrush(Color.FromRgb(29, 53, 87));

                Resources["SoftBackground"] =
                    new SolidColorBrush(Color.FromRgb(23, 36, 58));

                ThemeButton.Content = "☀ ライトモード";
            } else {
                Resources["AppBackground"] =
                    new SolidColorBrush(Color.FromRgb(242, 245, 250));

                Resources["Surface"] =
                    new SolidColorBrush(Colors.White);

                Resources["PrimaryText"] =
                    new SolidColorBrush(Color.FromRgb(37, 54, 83));

                Resources["MutedText"] =
                    new SolidColorBrush(Color.FromRgb(123, 135, 155));

                Resources["Accent"] =
                    new SolidColorBrush(Color.FromRgb(53, 105, 183));

                Resources["HeroBackground"] =
                    new SolidColorBrush(Color.FromRgb(220, 235, 255));

                Resources["SoftBackground"] =
                    new SolidColorBrush(Color.FromRgb(244, 247, 252));

                ThemeButton.Content = "🌙 ダークモード";
            }

            TemperatureChart.Background =
                (Brush)Resources["Surface"];

            CurrentWeatherCard.Background =
                (Brush)Resources["HeroBackground"];
        }

        // 市区町村検索
        private async void SearchButton_Click(
            object sender, RoutedEventArgs e) {
            string name = CitySearchTextBox.Text.Trim();

            string prefecture =
                PrefectureComboBox.SelectedItem as string ?? "";

            if (string.IsNullOrWhiteSpace(prefecture)) {
                MessageBox.Show("都道府県を選択してください。");
                return;
            }

            if (string.IsNullOrWhiteSpace(name)) {
                MessageBox.Show("市区町村名を入力してください。");
                return;
            }

            SearchButton.IsEnabled = false;
            SearchButton.Content = "検索中...";

            try {
                var cities = await _cityService.SearchCitiesAsync(
                    name, prefecture);

                if (cities.Count == 0) {
                    MessageBox.Show(
                        $"{prefecture}で「{name}」が見つかりませんでした。\n別の地名で検索してください。");
                    return;
                }

                CityComboBox.ItemsSource = cities;
                CityComboBox.DisplayMemberPath = "Name";
                CityComboBox.SelectedIndex = 0;

                CitySearchTextBox.Clear();
            }
            catch (TaskCanceledException) {
                MessageBox.Show("検索がタイムアウトしました。");
            }
            catch (HttpRequestException) {
                MessageBox.Show("インターネット接続を確認してください。");
            }
            catch (Exception ex) {
                MessageBox.Show("検索エラー：" + ex.Message);
            }
            finally {
                SearchButton.IsEnabled = true;
                SearchButton.Content = "検索";
            }
        }

        // 天気更新
        private async void RefreshButton_Click(
            object sender, RoutedEventArgs e) {
            await GetWeatherAsync(_selectedCity);
        }

        // 天気取得
        private async Task GetWeatherAsync(City city) {
            if (_isLoading || city == null)
                return;

            _isLoading = true;

            try {
                RefreshButton.IsEnabled = false;
                CityComboBox.IsEnabled = false;
                FavoriteComboBox.IsEnabled = false;

                CityNameText.Text = city.Name + "の天気";
                WeatherText.Text = "⏳ 天気情報を取得中...";
                TemperatureText.Text = "-- ℃";
                HumidityText.Text = "-- %";
                WindSpeedText.Text = "-- m/s";

                WeatherData weather =
                    await _weatherService.GetCurrentWeatherAsync(city);

                TemperatureText.Text =
                    $"{weather.Temperature:0.#} ℃";

                HumidityText.Text =
                    $"{weather.Humidity} %";

                WindSpeedText.Text =
                    $"{weather.WindSpeed:0.#} m/s";

                WeatherText.Text =
                    $"{GetWeatherIcon(weather.WeatherCode)}  " +
                    GetWeatherDescription(weather.WeatherCode);

                DisplayHourlyForecast(weather);
                DisplayForecast(weather);
                DisplayTemperatureChart(weather);

                ApplyWeatherBackground(weather.WeatherCode);
            }
            catch (TaskCanceledException) {
                WeatherText.Text = "通信がタイムアウトしました";
                MessageBox.Show("通信に時間がかかっています。再度お試しください。");
            }
            catch (HttpRequestException) {
                WeatherText.Text = "通信エラー";
                MessageBox.Show("インターネット接続を確認してください。");
            }
            catch (Exception ex) {
                WeatherText.Text = "天気情報を取得できませんでした";
                MessageBox.Show("エラー：" + ex.Message);
            }
            finally {
                RefreshButton.IsEnabled = true;
                CityComboBox.IsEnabled = true;
                FavoriteComboBox.IsEnabled = true;

                _isLoading = false;
            }
        }

        // 天気に合わせた背景
        private void ApplyWeatherBackground(int code) {
            if (_settings.IsDarkMode) {
                CurrentWeatherCard.Background =
                    new SolidColorBrush(Color.FromRgb(43, 65, 94));

                return;
            }

            if (code <= 1)
                CurrentWeatherCard.Background =
                    new SolidColorBrush(Color.FromRgb(255, 239, 204));

            else if (code <= 3)
                CurrentWeatherCard.Background =
                    new SolidColorBrush(Color.FromRgb(220, 230, 242));

            else if (code >= 51 && code <= 82)
                CurrentWeatherCard.Background =
                    new SolidColorBrush(Color.FromRgb(205, 225, 245));

            else if (code >= 95)
                CurrentWeatherCard.Background =
                    new SolidColorBrush(Color.FromRgb(215, 210, 235));

            else
                CurrentWeatherCard.Background =
                    new SolidColorBrush(Color.FromRgb(225, 235, 248));
        }

        // 24時間予報
        private void DisplayHourlyForecast(WeatherData weather) {
            HourlyForecastPanel.Children.Clear();

            foreach (HourlyWeatherData hourly in weather.HourlyForecast) {
                Border card = new Border {
                    Background = (Brush)Resources["SoftBackground"],
                    CornerRadius = new CornerRadius(14),
                    Padding = new Thickness(15),
                    Margin = new Thickness(0, 0, 10, 0),
                    Width = 125
                };

                StackPanel panel = new StackPanel {
                    HorizontalAlignment = HorizontalAlignment.Center
                };

                panel.Children.Add(new TextBlock {
                    Text = hourly.Time.ToString("H:mm"),
                    FontSize = 16,
                    FontWeight = FontWeights.Bold,
                    HorizontalAlignment = HorizontalAlignment.Center
                });

                panel.Children.Add(new TextBlock {
                    Text = GetWeatherIcon(hourly.WeatherCode),
                    FontSize = 29,
                    Margin = new Thickness(0, 10, 0, 10),
                    HorizontalAlignment = HorizontalAlignment.Center
                });

                panel.Children.Add(new TextBlock {
                    Text = $"{hourly.Temperature:0.#} ℃",
                    FontSize = 17,
                    FontWeight = FontWeights.Bold,
                    HorizontalAlignment = HorizontalAlignment.Center
                });

                panel.Children.Add(new TextBlock {
                    Text = $"降水 {hourly.PrecipitationProbability} %",
                    FontSize = 12,
                    Foreground = (Brush)Resources["MutedText"],
                    Margin = new Thickness(0, 8, 0, 0),
                    HorizontalAlignment = HorizontalAlignment.Center
                });

                card.Child = panel;
                HourlyForecastPanel.Children.Add(card);
            }
        }

        // 気温グラフ
        private void DisplayTemperatureChart(WeatherData weather) {
            TemperatureChart.Children.Clear();

            if (weather.DailyForecast.Count == 0)
                return;

            double width = TemperatureChart.Width;
            double height = TemperatureChart.Height;
            double padding = 38;

            double minTemp =
                weather.DailyForecast.Min(x => x.MinTemperature);

            double maxTemp =
                weather.DailyForecast.Max(x => x.MaxTemperature);

            double range = Math.Max(1, maxTemp - minTemp);

            minTemp -= range * 0.15;
            maxTemp += range * 0.15;

            double chartHeight = height - padding * 2;
            double chartWidth = width - padding * 2;

            Point GetPoint(int index, double temperature) {
                double x = padding + chartWidth * index /
                    Math.Max(1, weather.DailyForecast.Count - 1);

                double y = height - padding -
                    (temperature - minTemp) /
                    (maxTemp - minTemp) * chartHeight;

                return new Point(x, y);
            }

            for (int i = 0; i <= 4; i++) {
                double y = padding + chartHeight * i / 4;

                TemperatureChart.Children.Add(new Line {
                    X1 = padding,
                    X2 = width - padding,
                    Y1 = y,
                    Y2 = y,
                    Stroke = (Brush)Resources["MutedText"],
                    Opacity = 0.2,
                    StrokeThickness = 1
                });
            }

            Polyline maxLine = new Polyline {
                Stroke = Brushes.OrangeRed,
                StrokeThickness = 3
            };

            Polyline minLine = new Polyline {
                Stroke = Brushes.DodgerBlue,
                StrokeThickness = 3
            };

            for (int i = 0; i < weather.DailyForecast.Count; i++) {
                var day = weather.DailyForecast[i];

                Point maxPoint = GetPoint(i, day.MaxTemperature);
                Point minPoint = GetPoint(i, day.MinTemperature);

                maxLine.Points.Add(maxPoint);
                minLine.Points.Add(minPoint);

                AddChartPoint(maxPoint, day.MaxTemperature, Brushes.OrangeRed);
                AddChartPoint(minPoint, day.MinTemperature, Brushes.DodgerBlue);

                TextBlock date = new TextBlock {
                    Text = day.Date.ToString("M/d"),
                    FontSize = 12,
                    Foreground = (Brush)Resources["MutedText"]
                };

                Canvas.SetLeft(date, maxPoint.X - 12);
                Canvas.SetTop(date, height - padding + 10);

                TemperatureChart.Children.Add(date);
            }

            TemperatureChart.Children.Add(maxLine);
            TemperatureChart.Children.Add(minLine);
        }

        private void AddChartPoint(
            Point point, double temperature, Brush color) {
            Ellipse circle = new Ellipse {
                Width = 10,
                Height = 10,
                Fill = color
            };

            Canvas.SetLeft(circle, point.X - 5);
            Canvas.SetTop(circle, point.Y - 5);

            TemperatureChart.Children.Add(circle);

            TextBlock label = new TextBlock {
                Text = $"{temperature:0}°",
                FontSize = 12,
                FontWeight = FontWeights.Bold,
                Foreground = color
            };

            Canvas.SetLeft(label, point.X - 13);
            Canvas.SetTop(label, point.Y - 23);

            TemperatureChart.Children.Add(label);
        }

        // 7日間予報
        private void DisplayForecast(WeatherData weather) {
            ForecastPanel.Children.Clear();

            foreach (DailyWeatherData daily in weather.DailyForecast) {
                Border card = new Border {
                    Background = (Brush)Resources["SoftBackground"],
                    CornerRadius = new CornerRadius(14),
                    Padding = new Thickness(18),
                    Margin = new Thickness(0, 0, 0, 12)
                };

                Grid layout = new Grid();

                layout.ColumnDefinitions.Add(
                    new ColumnDefinition {
                        Width = new GridLength(1.2, GridUnitType.Star)
                    });

                layout.ColumnDefinitions.Add(
                    new ColumnDefinition {
                        Width = new GridLength(1.4, GridUnitType.Star)
                    });

                layout.ColumnDefinitions.Add(
                    new ColumnDefinition {
                        Width = new GridLength(1.5, GridUnitType.Star)
                    });

                layout.ColumnDefinitions.Add(
                    new ColumnDefinition {
                        Width = new GridLength(1, GridUnitType.Star)
                    });

                TextBlock date = new TextBlock {
                    Text = daily.Date.ToString(
                        "M月d日 (ddd)",
                        CultureInfo.GetCultureInfo("ja-JP")),
                    FontSize = 15,
                    FontWeight = FontWeights.Bold,
                    VerticalAlignment = VerticalAlignment.Center
                };

                TextBlock condition = new TextBlock {
                    Text = GetWeatherIcon(daily.WeatherCode) + "  " +
                           GetWeatherDescription(daily.WeatherCode),
                    FontSize = 15,
                    VerticalAlignment = VerticalAlignment.Center
                };

                TextBlock temperature = new TextBlock {
                    Text = $"最高 {daily.MaxTemperature:0.#}°\n最低 {daily.MinTemperature:0.#}°",
                    FontSize = 14,
                    FontWeight = FontWeights.SemiBold,
                    VerticalAlignment = VerticalAlignment.Center
                };

                TextBlock rain = new TextBlock {
                    Text = $"☂ {daily.PrecipitationProbability}%",
                    FontSize = 14,
                    Foreground = (Brush)Resources["MutedText"],
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Right
                };

                Grid.SetColumn(date, 0);
                Grid.SetColumn(condition, 1);
                Grid.SetColumn(temperature, 2);
                Grid.SetColumn(rain, 3);

                layout.Children.Add(date);
                layout.Children.Add(condition);
                layout.Children.Add(temperature);
                layout.Children.Add(rain);

                card.Child = layout;
                ForecastPanel.Children.Add(card);
            }
        }

        // 天気の説明
        private string GetWeatherDescription(int code) {
            if (code == 0) return "快晴";
            if (code == 1) return "主に晴れ";
            if (code == 2) return "一部曇り";
            if (code == 3) return "曇り";
            if (code == 45 || code == 48) return "霧";
            if (code >= 51 && code <= 67) return "雨";
            if (code >= 71 && code <= 77) return "雪";
            if (code >= 80 && code <= 82) return "にわか雨";
            if (code >= 85 && code <= 86) return "にわか雪";
            if (code >= 95 && code <= 99) return "雷雨";

            return "不明";
        }

        // 天気アイコン
        private string GetWeatherIcon(int code) {
            if (code == 0) return "☀️";
            if (code == 1) return "🌤️";
            if (code == 2) return "⛅";
            if (code == 3) return "☁️";
            if (code == 45 || code == 48) return "🌫️";
            if (code >= 51 && code <= 67) return "🌧️";
            if (code >= 71 && code <= 77) return "❄️";
            if (code >= 80 && code <= 82) return "🌦️";
            if (code >= 85 && code <= 86) return "🌨️";
            if (code >= 95 && code <= 99) return "⛈️";

            return "🌈";
        }
    }
}
