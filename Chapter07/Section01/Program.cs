using System.Text;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            var numbers = new List<int> { 9, 7, 5, 4, 2, 5, 4, 0, 4, 1, 0, 4 };
            var books = Books.GetBooks();
            var priceAverage = books.Average(x => x.Price);
            var pageAverage = books.Sum(x => x.Pages);
            var maxPrice = books.Max(x => x.Price);
            var more = books.Where(x => x.Price >= 500);

            Console.WriteLine("平均金額:" + priceAverage);
            Console.WriteLine("合計ページ:" + pageAverage);
            Console.WriteLine("高価な本:" + maxPrice);
            Console.WriteLine("---500円以上の本---");
            foreach (var morePrice in more) {
                Console.WriteLine(morePrice.Title);
            }
            Console.WriteLine();
            //250ページ以上の本を上位3冊出力
            Console.WriteLine("---250ページ以上の本を上位3冊出力---");
            var page = books.Where(x => x.Pages >= 250).Take(3);
            foreach(var book in page) {
                Console.WriteLine(book.Title);
            }
        }
    }
}
