using System.Text;

namespace Section05 {
    internal class Program {
        static void Main(string[] args) {
            var c = ",";
            var result = String.Join(c, GetWords());
            Console.WriteLine(result);
        }

        private static IEnumerable<object> GetWords() {
            return ["Orannge", "Lemon", "Strrawberry"];
        }
    }
}
