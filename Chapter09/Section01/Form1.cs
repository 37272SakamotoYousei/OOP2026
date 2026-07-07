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

            tbOut.Text = $"Ç†Ç»ÇΩÇÕ{age}çŒÇ≈Ç∑";
            tbOut2.Text = $"åoâﬂì˙êî{diff.Days}ì˙";
        }
    }
}
