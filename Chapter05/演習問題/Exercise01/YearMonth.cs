using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    //5.1.1
    public class YearMonth {
        public int Year { get; init; }
        public int Month { get; init; }

        public YearMonth(int year, int month) {
            Year = year;
            Month = month;
        }
        //5.1.2
        public bool IsCentury => 2001 <= Year && Year <= 2100;
        //5.1.3
        public YearMonth AddOneMonth() {
            if (Month == 12) {
                var num = new YearMonth(Year + 1, 1);
                return num;
            } else {
                var num = new YearMonth(Year, Month + 1);
                return num;
            }
        }
        //5.1.4
        public override string ToString() => Year + "年" + Month + "月";
    }
}
