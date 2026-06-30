using System.Diagnostics;

namespace Section01 {
    internal class Program {
        static private Dictionary<string, string> prefOfficeDict = new Dictionary<string, string>();


        static void Main(string[] args) {
            string? pref, prefCaptalLocation;

            Console.WriteLine("県庁所在地の登録【入力終了:Ctrl + 'Z'】");
            while (true) {
                //①都道府県の入力
                Console.Write("都道府県:");
                pref = Console.ReadLine();

                if (pref == null) break;

                //②県庁所在地の入力
                Console.Write("県庁所在地:");
                prefCaptalLocation = Console.ReadLine();
                Console.WriteLine();

                //③県庁所在地登録処理
                var maki = pref;
                if (prefOfficeDict.ContainsKey(maki)) {
                    Console.Write("上書きしますか？(Y/N)");
                    if (Console.ReadLine() is "N") continue;
                }
                prefOfficeDict[pref] = prefCaptalLocation;
            }

            while (true) {
                Console.WriteLine("****めにゅ～****");
                Console.WriteLine("1:一覧表示");
                Console.WriteLine("2:検索");
                Console.WriteLine("3:終了");
                Console.Write(">");

                var menu = Console.ReadLine();
                if (menu is "3") {
                    break;
                }

                switch (menu) {
                    case "1":
                        foreach (var item in prefOfficeDict) {
                            Console.WriteLine($"{item.Key}の県庁所在地は{item.Value}です");
                        }
                        break;

                    case "2":
                        Console.Write("けんさく:");
                        var search = Console.ReadLine();
                        var result = prefOfficeDict[search];
                        Console.WriteLine($"{search}の県庁所在地は{result}です");
                        break;

                    default:
                        Console.WriteLine("正しい値ではありません");
                        break;
                }
            }
        }
    }
}
