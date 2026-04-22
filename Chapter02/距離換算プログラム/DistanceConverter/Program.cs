using System.ComponentModel.Design;
using System.Diagnostics.Metrics;

namespace DistanceConverter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length >= 1 && args[0] == "-tom")
            {                                  //メートルへの変換
                int i = int.Parse(args[1]);
                int j = int.Parse(args[2]);
                PrintFeetToMeterList(i, j);
            }
            else if(args.Length >= 1 && args[0] == "-tof")
            {
                int i = int.Parse(args[1]);
                int j = int.Parse(args[2]);
                PrintMeterTofeetList(i, j);
            }
            else
            {
                Console.WriteLine("引数エラー");
            }
        }

        static void PrintFeetToMeterList(int start, int stop)
        {
            //フィートからメートルへの対応表を出力
            for (int feet = start; feet <= stop; feet++)
            {
                double merter = FeetToMerter(feet);
                Console.WriteLine($"{feet}ft = {merter:0.0000}m");
            }
        }
        static void PrintMeterTofeetList(int start, int stop)
        {
            //メートルからフィートへの対応表を出力
            for (int meter = start; meter <= stop; meter++)
            {
                double feet = MeterToFeet(meter);
                Console.WriteLine($"{meter}m = {feet:0.0000}ft");
            }
        }

        //フィートからメートルを求める
        static double FeetToMerter(int feet)
        {
            return feet * 0.3048;
        }
        //メートルからフィートを求める
        static double MeterToFeet(int meter)
        {
            return meter / 0.3048;
        }
    }
}
