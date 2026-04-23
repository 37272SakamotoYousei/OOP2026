using System.ComponentModel.Design;
using System.Diagnostics.Metrics;

namespace DistanceConverter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 3 && int.TryParse(args[1], out var start) && (int.TryParse(args[1], out var stop)))
            {
                if (args.Length >= 1 && args[0] == "-tom")
                {                                  //メートルへの変換
                    PrintFeetToMeterList(int.Parse(args[1]), int.Parse(args[2]));
                }
                else if (args.Length >= 1 && args[0] == "-tof")
                {
                    PrintMeterTofeetList(int.Parse(args[1]), int.Parse(args[2]));
                }
                else
                {
                    Console.WriteLine("引数エラー");
                }
            }
            else
            {
                Console.WriteLine("引数エラー");
            }

            static void PrintFeetToMeterList(int start, int stop)
            {
                FeetConverter converter = new FeetConverter();
                //フィートからメートルへの対応表を出力
                for (int feet = start; feet <= stop; feet++)
                {
                    double merter = converter.ToMeter(feet);
                    Console.WriteLine($"{feet}ft = {merter:0.0000}m");
                }
            }
            static void PrintMeterTofeetList(int start, int stop)
            {
                FeetConverter converter = new FeetConverter();
                //メートルからフィートへの対応表を出力
                for (int meter = start; meter <= stop; meter++)
                {
                    double feet = converter.FromMeter(meter);
                    Console.WriteLine($"{meter}m = {feet:0.0000}ft");
                }
            }
        }
    }
}
