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
            DateTime birth = dtpBirth.Value; //生まれた日付
            DateTime today = DateTime.Today; //今日の日付


            TimeSpan diff = today - birth;

            int age = today.Year - birth.Year;

            if (today < birth.AddYears(age)) {
                age--;
            }


            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar(); //曜日
            var dayOfWeek = culture.DateTimeFormat.GetDayName(birth.DayOfWeek);


            tbOut.Text = $"あなたは{GetAge(birth, today)}歳です";
            tbOut2.Text = $"経過日数{diff.Days}日";
            tbOut3.Text = $"生まれた{birth.Month}月{birth.Day}日は" +
                          $"第{NthWeek(birth)}週の{dayOfWeek}です";
        }

        //年齢を求めるメソッド
        static int GetAge(DateTime birthday, DateTime targetDay) {
            var age = targetDay.Year - birthday.Year;
            if (targetDay < birthday.AddYears(age)) {
                age--;
            }
            return age;
        }

        //指定した日が第何週かを求める
        static int NthWeek(DateTime date) {
            var firstDay = new DateTime(date.Year, date.Month, 1);
            var firstDayOfWeek = (int)(firstDay.DayOfWeek);
            return (date.Day + firstDayOfWeek - 1) / 7 + 1;
        }

        private void Form1_Load(object sender, EventArgs e) {

        }
    }
}
