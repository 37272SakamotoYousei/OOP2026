namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            Console.Write("数字文字列:");
            if (int.TryParse(Console.ReadLine(), out var num)) {
                var number = num.ToString("#,0");
                Console.WriteLine(number);
            } else {
                Console.WriteLine("整数文字列ではありません");
            }

        }
    }
}
