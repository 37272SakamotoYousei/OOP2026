using System.ComponentModel.Design;
using System.Diagnostics.Metrics;

namespace DistanceConverter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length >= 1 && args[0] == "-tom"){
                //フィートからメートルへの対応表を出力
                for (int feet = 1; feet <= 10; feet++){
                    double merter = FeetToMerter(feet);
                    Console.WriteLine($"{feet}ft = {merter:0.0000}m");
                }
            }else{
                //メートルからフィートへの対応表を出力
                for (int meter = 1; meter <= 10; meter++){
                    double feet = MeterToFeet(meter);
                    Console.WriteLine($"{meter}m = {feet:0.0000}ft");
                }
            }
        }
        //フィートからメートルを求める
        static double FeetToMerter(int feet){
            return feet * 0.3048;
        }
        //メートルからフィートを求める
        static double MeterToFeet(int meter){
            return meter / 0.3048;
        }
    }
}
