using System.Xml;
using System.Xml.Serialization;

namespace CarReportSystem {
    public sealed class Settings {

        private const string FileName = "setting.xml";

        //唯一のSettingオブジェクト
        private static Settings _instance = new Settings();

        //メイン画面に設定した色情報
        public int MaiinFormBackColor { get; set; }
        = SystemColors.Control.ToArgb();

        public static Settings Instance {
            get { return _instance; }
        }

        //外部からnewできないようにする
        private Settings() { }

        public void Load() {
            if (!File.Exists(FileName))
                return;

            using var reader = XmlReader.Create(FileName);
            var serializer = new XmlSerializer(typeof(SettingsData));

            if (serializer.Deserialize(reader) is Settings data) {
                MaiinFormBackColor = data.MaiinFormBackColor;
            }
        }

        public void Save() {
            var data = new SettingsData {
                MainFormBackColor = MaiinFormBackColor
            };

            using var writer = XmlWriter.Create(FileName);
            var serializer = new XmlSerializer(typeof(SettingsData));
            serializer.Serialize(writer, data);
        }
    }

    //XML保存用のクラス
    public class SettingsData {
        public int MainFormBackColor { get; set; }
    }
}