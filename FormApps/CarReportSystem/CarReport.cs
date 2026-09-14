using Microsoft.Data.Sqlite;

namespace CarReportSystem {
    public class CarReport {

        public enum MakerGroup {
            なし,
            トヨタ,
            日産,
            ホンダ,
            スバル,
            輸入車,
            その他,
        }

        [System.ComponentModel.DisplayName("ID")]
        public int Id { get; set; } //ID
        [System.ComponentModel.DisplayName("日付")]
        public DateTime Date { get; set; } //日付
        [System.ComponentModel.DisplayName("記録者")]
        public string Author { get; set; } = String.Empty;//記録者
        [System.ComponentModel.DisplayName("メーカー")]
        public MakerGroup Maker { get; set; } //メーカー
        [System.ComponentModel.DisplayName("車名")]
        public string CarName { get; set; } = String.Empty; //車名
        [System.ComponentModel.DisplayName("レポート")]
        public string Report { get; set; } = String.Empty; //レポート
        [System.ComponentModel.DisplayName("画像")]
        public Image? Picture { get; set; } //画像
    }

    public static class Database {
        //DBファイルの保存場所
        private static readonly string DatabasePath =
            Path.Combine(AppContext.BaseDirectory, "carreport.db");

        // SQLiteへ接続するための接続文字列
        private static readonly string ConnectionString =
            $"Data Source={DatabasePath}";

        // DBファイルの保存場所を外部から確認するための読み取り専用プロパティ
        public static string FilePath => DatabasePath;

        // 新しいSQLiteConnectionを生成して返す
        public static SqliteConnection GetConnection() {
            return new SqliteConnection(ConnectionString);
        }

        // DBの初期化処理
        public static void Initialize() {
            // 接続オブジェクトを生成する。
            using var connection = GetConnection();

            //DBを開く
            connection.Open();

            // SQLを実行するためのコマンドオブジェクトを作る
            using var command = connection.CreateCommand();

            // Productsテーブルを作るSQL
            // IF NOT EXISTS により、既にテーブルがあってもエラーにならない
            command.CommandText =
                """
            CREATE TABLE IF NOT EXISTS CarReports (
                Id      INTEGER  PRIMARY KEY AUTOINCREMENT,
                Date    TEXT     NOT NULL,
                Author  TEXT     NOT NULL,
                Maker   INTEGER NOT NULL,
                CarName TEXT     NOT NULL,
                Report  TEXT     NOT NULL,
                Picture BLOB
            );
            """;

            //結果行を返さないSQLを実行する
            command.ExecuteNonQuery();
        }
    }
}
