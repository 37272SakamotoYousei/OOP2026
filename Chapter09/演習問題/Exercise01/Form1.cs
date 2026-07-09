using System.Globalization;

namespace Exercise01 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btButton1_Click(object sender, EventArgs e) {
            DateTime today = DateTime.Now;
            var Date1 = today.ToString("yyyy/MM/dd HH:mm");
            tbOut1.Text = Date1;
        }

        private void btButton2_Click(object sender, EventArgs e) {
            DateTime today = DateTime.Now;
            var Date2 = today.ToString("yyyy”NMMŒŽdd“ú HHŽžmm•ªss•b");
            tbOut2.Text = Date2;
        }

        private void btButton3_Click(object sender, EventArgs e) {
            DateTime today = DateTime.Now;
            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            var Date3 = today.ToString("ggyy”NMMŒŽdd“ú(dddd)",culture);
            tbOut3.Text = Date3;
        }
    }
}
