
using System.Security.Cryptography.X509Certificates;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            List<string> langs = [
            "C#", "Java", "Ruby", "PHP", "Python", "TypeScript",
                "JavaScript", "Swift", "Go",
            ];

            Exercise1(langs);
            Console.WriteLine("---");
            Exercise2(langs);
            Console.WriteLine("---");
            Exercise3(langs);
        }

        private static void Exercise1(List<string> langs) {
            Console.WriteLine("4-1-1");
            Console.WriteLine("foreach文で出力");
            /*var name = langs.Where(s => s.Contains('S'));
            foreach (var n in name) {
                Console.WriteLine(n);
            }*/
            foreach (var lang in langs) {
                if (lang.Contains('S')) {
                    Console.WriteLine(lang);
                }
            }

            Console.WriteLine("\nfor文で出力");
            for (int i = 0; i < 9; i++) {
                if (langs[i].Contains('S')) {
                    Console.WriteLine(langs[i]);
                }
            }


            Console.WriteLine("\nwhile文で出力");
            int cnt = 0;
            while (cnt < langs.Count) {
                if (langs[cnt].Contains('S')) {
                    Console.WriteLine(langs[cnt]);
                }
                cnt++;
            }
        }

        private static void Exercise2(List<string> langs) {
            Console.WriteLine("4-1-2");
            IEnumerable<string> name = langs.Where(s => s.Contains('S'));
            foreach (var n in name) {
                Console.WriteLine(n);
            }

        }

        private static void Exercise3(List<string> langs) {
            Console.WriteLine("4-1-3");
            /*var lang = langs.Find(s => s.Length == 10);
            if (lang == null) {
                lang = "unknown";
            }
            Console.WriteLine(lang);*/

            var lang = langs.Find(s => s.Length == 10)?? "unknown";
            Console.WriteLine(lang);
        }
    }
}
