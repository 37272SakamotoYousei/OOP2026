using System.Globalization;

namespace Section01 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btGet_Click(object sender, EventArgs e) {
            DateTime date = dtpDate.Value;

            tbOut.Text = date.AddDays((double)nudDay.Value).ToString();
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e) {

        }

        private void nudDay_ValueChanged(object sender, EventArgs e) {

        }

        private void tbOut_TextChanged(object sender, EventArgs e) {

        }

        private void btBithCalc_Click(object sender, EventArgs e) {
            DateTime birth = dtpBirth.Value; //ê∂Ç‹ÇÍÇΩì˙ït
            DateTime today = DateTime.Today; //ç°ì˙ÇÃì˙ït


            TimeSpan diff = today - birth;

            int age = today.Year - birth.Year;

            if (today < birth.AddYears(age)) {
                age--;
            }


            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar(); //ójì˙
            var dayOfWeek = culture.DateTimeFormat.GetDayName(birth.DayOfWeek);


            tbOut.Text = $"Ç†Ç»ÇΩÇÕ{GetAge(birth, today)}çŒÇ≈Ç∑";
            tbOut2.Text = $"åoâﬂì˙êî{diff.Days}ì˙";
            tbOut3.Text = $"ê∂Ç‹ÇÍÇΩ{birth.Month}åé{birth.Day}ì˙ÇÕ" +
                          $"ëÊ{NthWeek(birth)}èTÇÃ{dayOfWeek}Ç≈Ç∑";
            tbOut4.Text = Birthday(today, birth);
        }

        static string Birthday(DateTime today, DateTime birth) {
            DateTime DAY = new DateTime(today.Year, birth.Month, birth.Day);
            if (DAY == today.Date) {
                    return $"íaê∂ì˙ÇÕç°ì˙Ç≈Ç∑";
            }
            if(DAY < today) {
                DAY = DAY.AddYears(1);
            }
            var BIRTH = DAY - today;
            return $"íaê∂ì˙Ç‹Ç≈Ç†Ç∆{BIRTH.Days}ì˙Ç≈Ç∑";
        }


            //îNóÓÇãÅÇﬂÇÈÉÅÉ\ÉbÉh
            static int GetAge(DateTime birthday, DateTime targetDay) {
            var age = targetDay.Year - birthday.Year;
            if (targetDay < birthday.AddYears(age)) {
                age--;
            }
            return age;
        }

        //éwíËÇµÇΩì˙Ç™ëÊâΩèTÇ©ÇãÅÇﬂÇÈ
        static int NthWeek(DateTime date) {
            var firstDay = new DateTime(date.Year, date.Month, 1);
            var firstDayOfWeek = (int)(firstDay.DayOfWeek);
            return (date.Day + firstDayOfWeek - 1) / 7 + 1;
        }

        private void Form1_Load(object sender, EventArgs e) {

        }
    }
}
