using System.Runtime.CompilerServices;

namespace SalesCalculator {
    internal class Program {
        static void Main(string[] args) {
            var sales = new Salescounter(@"data\sales.csv");
            var amountPerStore = sales.GetPerStoreSales();
            foreach(KeyValuePair<string,int>obj in amountPerStore) {
                Console.WriteLine($"{obj.Key} {obj.Value}");
            }
        }
    }
}
