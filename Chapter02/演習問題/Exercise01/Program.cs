
namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            var songs = new List<Song>();
            while (true) {
                //アーティスト名出力
                Console.Write("曲名:");
                string? title = Console.ReadLine();
                if (title == "end") {
                    break;
                } else {
                    Console.Write("アーティスト名:");
                    string? artistname = Console.ReadLine();
                    Console.Write("演奏時間(秒):");
                    string? count = Console.ReadLine();
                    int length = int.Parse(count);
                    var song = new Song(title, artistname, length);
                    songs.Add(song);
                }
            }
            PrintSongs(songs);
        }

        private static void PrintSongs(IEnumerable<Song> songs) {

            foreach (var song in songs) {
                var minutes = song.Length / 60;
                var seconds = song.Length % 60;
                Console.WriteLine($"{song.Title}{song.ArtistName}{minutes}:{seconds:00}");
            }
        }
    }
}