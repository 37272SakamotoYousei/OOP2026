
namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            var text = "Cozy lummox gives smart squid who asks for job pen";

            Exercise1(text);
            Console.WriteLine();
            Exercise2(text);
        }

        private static void Exercise1(string text) {
            var word = new Dictionary<char, int>();
            foreach (var item in text.ToUpper()) {
                if ('A' <= item && item <= 'Z') {
                    if (word.ContainsKey(item))
                        word[item]++;
                    else
                        word[item] = 1;
                }
            }
            foreach (var alph in word.OrderBy(s => s.Key)) {
                Console.WriteLine($"{alph.Key}:{alph.Value}");
            }
        }

        private static void Exercise2(string text) {
            var word = new SortedDictionary<char, int>();
            foreach (var item in text.ToUpper()) {
                if ('A' <= item && item <= 'Z') {
                    if (word.ContainsKey(item))
                        word[item]++;
                    else
                        word[item] = 1;
                }
            }
            foreach (var alph in word) {
                Console.WriteLine($"{alph.Key}:{alph.Value}");
            }
        }
    }
}
