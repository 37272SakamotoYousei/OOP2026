using System.ComponentModel;
using System.Drawing.Text;
using System.Windows.Forms;
using static CarReportSystem.CarReport;

namespace CarReportSystem {
    public partial class Form1 : Form {

        //カーレポート管理用リスト
        BindingList<CarReport> listCarReports = new BindingList<CarReport>();
        public Form1() {
            InitializeComponent();
            dgvRecords.DataSource = listCarReports;
        }

        //追加ボタンイベントハンドラ
        private void btAddRecord_Click(object sender, EventArgs e) {

            tsslbMessage.Text = String.Empty; //メッセージ領域のクリア

            if (cbAuthor.Text == string.Empty || cbCarName.Text == string.Empty) {
                tsslbMessage.Text = "記録者、または車名が未入力です";
                return;
            }

            var carReport = new CarReport {
                Date = dtpDate.Value,
                Author = cbAuthor.Text,
                Maker = getRadioButtonMaker(),
                CarName = cbCarName.Text,
                Report = tbReport.Text,
                Picture = pbPicture.Image,
            };
            listCarReports.Add(carReport);

            SetCbAuthor(cbAuthor.Text);
            SetCbCarName(cbCarName.Text);

            dgvRecords.CurrentRow.Selected = false;
            ImputItemsAllClear();
        }

        private MakerGroup getRadioButtonMaker() {
            if (rbToyota.Checked)
                return MakerGroup.トヨタ;
            if (rbNissan.Checked)
                return MakerGroup.日産;
            if (rbHonda.Checked)
                return MakerGroup.ホンダ;
            if (rbSubaru.Checked)
                return MakerGroup.スバル;
            if (rbInport.Checked)
                return MakerGroup.輸入車;
            return MakerGroup.その他;
        }

        private void btOpenPicture_Click(object sender, EventArgs e) {
            if (ofdPicFileOpen.ShowDialog() == DialogResult.OK) {
                pbPicture.Image = Image.FromFile(ofdPicFileOpen.FileName);
            }
        }

        private void btNewInput_Click(object sender, EventArgs e) {
            ImputItemsAllClear();
        }

        private void ImputItemsAllClear() {
            dtpDate.Value = DateTime.Today;
            cbAuthor.Text = String.Empty;
            rbOther.Checked = true;
            cbCarName.Text = String.Empty;
            tbReport.Text = string.Empty;
            pbPicture.Image = null;

            dgvRecords.CurrentRow.Selected = false;
        }

        //private void dgvRecords_Click(object sender, EventArgs e) {

        //    if (dgvRecords.CurrentRow is null)
        //        return;

        //    dtpDate.Value = (DateTime)dgvRecords.CurrentRow.Cells["Date"].Value;
        //    cbAuthor.Text = (string)dgvRecords.CurrentRow.Cells["Author"].Value;
        //    SetRadioButtonMaker((MakerGroup)dgvRecords.CurrentRow.Cells["Maker"].Value);
        //    cbCarName.Text = (string)dgvRecords.CurrentRow.Cells["CarName"].Value;
        //    tbReport.Text = (string)dgvRecords.CurrentRow.Cells["Report"].Value;
        //    pbPicture.Image = (Image)dgvRecords.CurrentRow.Cells["Picture"].Value;
        //}

        private void SetRadioButtonMaker(MakerGroup targetMaker) {

            switch (targetMaker) {
                case MakerGroup.トヨタ:
                    rbToyota.Checked = true;
                    break;
                case MakerGroup.日産:
                    rbNissan.Checked = true;
                    break;
                case MakerGroup.ホンダ:
                    rbHonda.Checked = true;
                    break;
                case MakerGroup.スバル:
                    rbSubaru.Checked = true;
                    break;
                case MakerGroup.輸入車:
                    rbInport.Checked = true;
                    break;
                default:
                    rbOther.Checked = true;
                    break;
            }
        }

        //記録者の入力履歴をコンボボックスへ登録(重複なし)
        private void SetCbAuthor(string author) {
            if (!cbAuthor.Items.Contains(author))
                cbAuthor.Items.Add(author);
        }

        //車名の入力履歴をコンボボックスへ登録(重複なし)
        private void SetCbCarName(string carName) {
            if (!cbCarName.Items.Contains(carName))
                cbCarName.Items.Add(carName);
        }

        private void btDeletePicture_Click(object sender, EventArgs e) {
            pbPicture.Image = null;
        }

        private void btDeleteRecod_Click(object sender, EventArgs e) {
            if ((dgvRecords.CurrentRow is null) || (!dgvRecords.CurrentRow.Selected)) return;

            //削除したいインデックスを指定してリストから削除
            listCarReports.RemoveAt(dgvRecords.CurrentRow.Index);
            ImputItemsUpdate();

        }

        private void btModifyRecord_Click(object sender, EventArgs e) {
            //if (cbAuthor.Text == string.Empty || cbCarName.Text == string.Empty) {
            //    tsslbMessage.Text = "記録者、または車名が未入力です";
            //    return;
            //}

            //var carReport = new CarReport {
            //    Date = dtpDate.Value,
            //    Author = cbAuthor.Text,
            //    Maker = getRadioButtonMaker(),
            //    CarName = cbCarName.Text,
            //    Report = tbReport.Text,
            //    Picture = pbPicture.Image,
            //};

            //SetCbAuthor(cbAuthor.Text);
            //SetCbCarName(cbCarName.Text);
            //ImputItemsAllClear();

            //listCarReports[dgvRecords.CurrentRow.Index] = carReport;

            listCarReports[dgvRecords.CurrentRow.Index].Date = dtpDate.Value;
            listCarReports[dgvRecords.CurrentRow.Index].Author = dtpDate.Text;
            listCarReports[dgvRecords.CurrentRow.Index].Maker = getRadioButtonMaker();
            listCarReports[dgvRecords.CurrentRow.Index].CarName = cbCarName.Text;
            listCarReports[dgvRecords.CurrentRow.Index].Report = tbReport.Text;
            listCarReports[dgvRecords.CurrentRow.Index].Picture = pbPicture.Image;

            dgvRecords.Refresh(); //データグリッドビューの更新

        }

        public void ImputItemsUpdate() {
            if (!dgvRecords.CurrentRow.Selected)
                ImputItemsAllClear();
        }
        private void dgvRecords_Click(object sender, EventArgs e) {

            if ((dgvRecords.CurrentRow is null) || (!dgvRecords.CurrentRow.Selected))
                return;

            dtpDate.Value = (DateTime)dgvRecords.CurrentRow.Cells["Date"].Value;
            cbAuthor.Text = (string)dgvRecords.CurrentRow.Cells["Author"].Value;
            SetRadioButtonMaker((MakerGroup)dgvRecords.CurrentRow.Cells["Maker"].Value);
            cbCarName.Text = (string)dgvRecords.CurrentRow.Cells["CarName"].Value;
            tbReport.Text = (string)dgvRecords.CurrentRow.Cells["Report"].Value;
            pbPicture.Image = (Image)dgvRecords.CurrentRow.Cells["Picture"].Value;

            ImputItemsUpdate();
        }

        private void 終了ToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void 色設定ToolStripMenuItem_Click(object sender, EventArgs e) {
            ColorDialog cdColor = new ColorDialog();
            cdColor.Color = Form1.DefaultBackColor;
            cdColor.CustomColors = new int[] { 0x00FF0000, 0x0000FF00, 0x000000FF };
            if (cdColor.ShowDialog() == DialogResult.OK) {
                this.BackColor = cdColor.Color;
            }
        }
    }
}