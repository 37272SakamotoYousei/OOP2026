
namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            var cities = new List<string> {
                "Tokyo", "New Delhi", "Bangkok", "London",
                "Paris", "Berlin", "Canberra", "Hong Kong",
            };

            Console.WriteLine("***** 3.2.1 *****");
            Exercise2_1(cities);
            Console.WriteLine();

            Console.WriteLine("***** 3.2.2 *****");
            Exercise2_2(cities);
            Console.WriteLine();

            Console.WriteLine("***** 3.2.3 *****");
            Exercise2_3(cities);
            Console.WriteLine();

            Console.WriteLine("***** 3.2.4 *****");
            Exercise2_4(cities);
            Console.WriteLine();
        }

        private static void Exercise2_1(List<string> cities) {
            while (true){
                Console.Write("にゅうりょく(空白で終了):");
                var name = Console.ReadLine();
                if (name == string.Empty) {
                    break;
                }
                var index = cities.FindIndex(s => s == name);
                Console.WriteLine(index);
            }
        }

        private static void Exercise2_2(List<string> cities) {
            var n = cities.Count(s => s.Contains('o'));
                Console.WriteLine(n);
        }

        private static void Exercise2_3(List<string> cities) {
            var name = cities.Where(s => s.Contains('o'));
            foreach (var n in name) {
                Console.WriteLine(n);
            }
        }

        private static void Exercise2_4(List<string> cities) {
            var name = cities
                .Where(s => s.StartsWith('B'))
                .Select(s => s.Length);
            foreach (var n in name) {
                Console.WriteLine(n);
            }
        }
    }
}
