
namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {


            int[] numbers = [5, 10, 17, 9, 3, 21, 10, 40, 21, 3, 35];


            Console.WriteLine("7.1.1");
            Exercise1(numbers);

            Console.WriteLine("7.1.2");
            Exercise2(numbers);

            Console.WriteLine("7.1.3");
            Exercise3(numbers);

            Console.WriteLine("7.1.4");
            Exercise4(numbers);

            Console.WriteLine("7.1.5");
            Exercise5(numbers);
        }

        private static void Exercise1(int[] numbers) {
            var max = numbers.Max();
            Console.WriteLine(max);
        }

        private static void Exercise2(int[] numbers) {
            foreach (var last in numbers.TakeLast(2)) {
                Console.WriteLine(last);
            }
        }

        private static void Exercise3(int[] numbers) {
            var number = numbers.Select(n => n.ToString("000")).ToArray();
            foreach(var num in number) {
                Console.WriteLine(num);
            }
        }

        private static void Exercise4(int[] numbers) {
            //P175参考
            foreach (var n in numbers.Order().Take(3)) {
                Console.WriteLine(n);
            }
        }

        private static void Exercise5(int[] numbers) {
            //P174参考
            var cnt = numbers.Distinct().Count(n => 10 < n);
            Console.WriteLine(cnt);
        }
    }
}
