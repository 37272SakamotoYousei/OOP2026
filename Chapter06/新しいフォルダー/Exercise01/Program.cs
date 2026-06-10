using System.Globalization;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            var a = Console.ReadLine();
            var b = Console.ReadLine();

            var cultureInfo = new CultureInfo("ja-JP");

            if (String.Compare(a, b, cultureInfo,
                                    CompareOptions.IgnoreWidth | CompareOptions.IgnoreCase) == 0) {
                Console.WriteLine("等しい");
            } else {
                Console.WriteLine("等しくない");
            }
        }
    }
}
