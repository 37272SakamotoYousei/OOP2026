
using System;
using System.Runtime.Intrinsics.X86;
using System.Xml.Linq;

namespace Exercise03 {
    internal class Program {
        static void Main(string[] args) {
            var text = "Jackdaws love my big sphinx of quartz";
            #region
            Console.WriteLine("6.3.1");
            Exercise1(text);

            Console.WriteLine("6.3.2");
            Exercise2(text);

            Console.WriteLine("6.3.3");
            Exercise3(text);

            Console.WriteLine("6.3.4");
            Exercise4(text);

            Console.WriteLine("6.3.5");
            Exercise5(text);

            Console.WriteLine("6.3.6");
            Exercise6(text);
            #endregion
        }

        private static void Exercise1(string text) {
            var cnt = text.Count(c => c == ' ');
            Console.WriteLine(cnt);
        }

        private static void Exercise2(string text) {
            Console.Write("検索:");
            var search = Console.ReadLine();
            Console.Write("置換:");
            var Replacement = Console.ReadLine();
            var replaced = text.Replace(search, Replacement);
            Console.WriteLine(replaced);
        }

        private static void Exercise3(string text) {

        }

        private static void Exercise4(string text) {
            var word = text.Split(' ').Count();
            Console.WriteLine("単語数:" + word);
        }

        private static void Exercise5(string text) {
            var word = text.Split(' ').Where(s => s.Length <= 4).ToList();
            //リストにする場合ToList(); 配列にする場合ToArray();
            foreach (var str in word) {
                Console.WriteLine(str);
            }
        }

        private static void Exercise6(string text) {
            var str = text.ToLower().Replace(" ","");
            //辞書(ディクショナリ)を使った集計
            var alphDicCount = Enumerable.Range('a', 26).
                ToDictionary(num => ((char)num).ToString(),num => 0);

            var dict = new SortedDictionary<char, int>();
            foreach(var c in str) {
                if (dict.ContainsKey(c))
                    dict[c]++;
                else
                    dict[c] = 1;
            }
            foreach(var word in dict) {
                Console.WriteLine(word.Key + ":" + word.Value);
            }


            //var dict = new Dictionary<char, int>();
            //foreach (var str in text) {
            //    if (dict.ContainsKey(str)) {

            //        dict[str] += 1;
            //    } else {
            //        dict[str] = 1;
            //    }
            //}
            //foreach(KeyValuePair<char, int> obj in dict) {
            //    Console.WriteLine($"{obj.Key} : {obj.Value}");
            //}
        }
    }
}
