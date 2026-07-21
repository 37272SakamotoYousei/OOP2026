namespace CarReportSystem {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            label1 = new Label();
            dtpDate = new DateTimePicker();
            label2 = new Label();
            label3 = new Label();
            groupBox1 = new GroupBox();
            rbOther = new RadioButton();
            rbInport = new RadioButton();
            rbSubaru = new RadioButton();
            rbHonda = new RadioButton();
            rbNissan = new RadioButton();
            rbToyota = new RadioButton();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            tbReport = new TextBox();
            dgvRecords = new DataGridView();
            label7 = new Label();
            btNewInput = new Button();
            btOpenPicture = new Button();
            label8 = new Label();
            btDeletePicture = new Button();
            pbPicture = new PictureBox();
            btAddRecord = new Button();
            btModifyRecord = new Button();
            btDeleteRecod = new Button();
            menuStrip1 = new MenuStrip();
            ファイルFToolStripMenuItem = new ToolStripMenuItem();
            開くToolStripMenuItem = new ToolStripMenuItem();
            保存ToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            色設定ToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            終了ToolStripMenuItem = new ToolStripMenuItem();
            ヘルプHToolStripMenuItem = new ToolStripMenuItem();
            a = new ToolStripMenuItem();
            cbAuthor = new ComboBox();
            cbCarName = new ComboBox();
            statusStrip1 = new StatusStrip();
            tsslbMessage = new ToolStripStatusLabel();
            ofdPicFileOpen = new OpenFileDialog();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRecords).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbPicture).BeginInit();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label1.Location = new Point(27, 33);
            label1.Name = "label1";
            label1.Size = new Size(62, 32);
            label1.TabIndex = 0;
            label1.Text = "日付";
            // 
            // dtpDate
            // 
            dtpDate.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            dtpDate.Location = new Point(112, 32);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(200, 33);
            dtpDate.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label2.Location = new Point(10, 127);
            label2.Name = "label2";
            label2.Size = new Size(79, 32);
            label2.TabIndex = 2;
            label2.Text = "メーカー";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label3.Location = new Point(20, 82);
            label3.Name = "label3";
            label3.Size = new Size(0, 32);
            label3.TabIndex = 3;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rbOther);
            groupBox1.Controls.Add(rbInport);
            groupBox1.Controls.Add(rbSubaru);
            groupBox1.Controls.Add(rbHonda);
            groupBox1.Controls.Add(rbNissan);
            groupBox1.Controls.Add(rbToyota);
            groupBox1.Location = new Point(112, 127);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(358, 32);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            // 
            // rbOther
            // 
            rbOther.AutoSize = true;
            rbOther.Location = new Point(303, 13);
            rbOther.Name = "rbOther";
            rbOther.Size = new Size(56, 19);
            rbOther.TabIndex = 8;
            rbOther.TabStop = true;
            rbOther.Text = "その他";
            rbOther.UseVisualStyleBackColor = true;
            // 
            // rbInport
            // 
            rbInport.AutoSize = true;
            rbInport.Location = new Point(236, 11);
            rbInport.Name = "rbInport";
            rbInport.Size = new Size(61, 19);
            rbInport.TabIndex = 7;
            rbInport.TabStop = true;
            rbInport.Text = "輸入車";
            rbInport.UseVisualStyleBackColor = true;
            // 
            // rbSubaru
            // 
            rbSubaru.AutoSize = true;
            rbSubaru.Location = new Point(176, 11);
            rbSubaru.Name = "rbSubaru";
            rbSubaru.Size = new Size(54, 19);
            rbSubaru.TabIndex = 6;
            rbSubaru.TabStop = true;
            rbSubaru.Text = "スバル";
            rbSubaru.UseVisualStyleBackColor = true;
            // 
            // rbHonda
            // 
            rbHonda.AutoSize = true;
            rbHonda.Location = new Point(117, 11);
            rbHonda.Name = "rbHonda";
            rbHonda.Size = new Size(53, 19);
            rbHonda.TabIndex = 5;
            rbHonda.TabStop = true;
            rbHonda.Text = "ホンダ";
            rbHonda.UseVisualStyleBackColor = true;
            // 
            // rbNissan
            // 
            rbNissan.AutoSize = true;
            rbNissan.Location = new Point(62, 11);
            rbNissan.Name = "rbNissan";
            rbNissan.Size = new Size(49, 19);
            rbNissan.TabIndex = 1;
            rbNissan.TabStop = true;
            rbNissan.Text = "日産";
            rbNissan.UseVisualStyleBackColor = true;
            // 
            // rbToyota
            // 
            rbToyota.AutoSize = true;
            rbToyota.Location = new Point(6, 11);
            rbToyota.Name = "rbToyota";
            rbToyota.Size = new Size(50, 19);
            rbToyota.TabIndex = 0;
            rbToyota.TabStop = true;
            rbToyota.Text = "トヨタ";
            rbToyota.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label4.Location = new Point(3, 82);
            label4.Name = "label4";
            label4.Size = new Size(86, 32);
            label4.TabIndex = 7;
            label4.Text = "記録者";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label5.Location = new Point(27, 178);
            label5.Name = "label5";
            label5.Size = new Size(62, 32);
            label5.TabIndex = 8;
            label5.Text = "車名";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label6.Location = new Point(6, 221);
            label6.Name = "label6";
            label6.Size = new Size(83, 32);
            label6.TabIndex = 9;
            label6.Text = "レポート";
            // 
            // tbReport
            // 
            tbReport.Location = new Point(112, 232);
            tbReport.Multiline = true;
            tbReport.Name = "tbReport";
            tbReport.Size = new Size(316, 94);
            tbReport.TabIndex = 10;
            // 
            // dgvRecords
            // 
            dgvRecords.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRecords.Location = new Point(112, 344);
            dgvRecords.MultiSelect = false;
            dgvRecords.Name = "dgvRecords";
            dgvRecords.Size = new Size(623, 233);
            dgvRecords.TabIndex = 11;
            dgvRecords.Click += dgvRecords_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label7.Location = new Point(27, 344);
            label7.Name = "label7";
            label7.Size = new Size(62, 32);
            label7.TabIndex = 12;
            label7.Text = "一覧";
            // 
            // btNewInput
            // 
            btNewInput.BackColor = Color.FromArgb(192, 255, 255);
            btNewInput.FlatStyle = FlatStyle.Flat;
            btNewInput.Location = new Point(343, 32);
            btNewInput.Name = "btNewInput";
            btNewInput.Size = new Size(85, 33);
            btNewInput.TabIndex = 13;
            btNewInput.Text = "新規入力";
            btNewInput.UseVisualStyleBackColor = false;
            btNewInput.Click += btNewInput_Click;
            // 
            // btOpenPicture
            // 
            btOpenPicture.FlatStyle = FlatStyle.Flat;
            btOpenPicture.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btOpenPicture.ForeColor = Color.Salmon;
            btOpenPicture.Location = new Point(544, 33);
            btOpenPicture.Name = "btOpenPicture";
            btOpenPicture.Size = new Size(112, 33);
            btOpenPicture.TabIndex = 14;
            btOpenPicture.Text = "開く...///♡";
            btOpenPicture.UseVisualStyleBackColor = true;
            btOpenPicture.Click += btOpenPicture_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label8.Location = new Point(476, 33);
            label8.Name = "label8";
            label8.Size = new Size(62, 32);
            label8.TabIndex = 15;
            label8.Text = "画像";
            // 
            // btDeletePicture
            // 
            btDeletePicture.BackColor = Color.FromArgb(255, 192, 192);
            btDeletePicture.FlatStyle = FlatStyle.Flat;
            btDeletePicture.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btDeletePicture.Location = new Point(662, 32);
            btDeletePicture.Name = "btDeletePicture";
            btDeletePicture.Size = new Size(73, 33);
            btDeletePicture.TabIndex = 16;
            btDeletePicture.Text = "削除";
            btDeletePicture.UseVisualStyleBackColor = false;
            btDeletePicture.Click += btDeletePicture_Click;
            // 
            // pbPicture
            // 
            pbPicture.Location = new Point(476, 72);
            pbPicture.Name = "pbPicture";
            pbPicture.Size = new Size(259, 181);
            pbPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            pbPicture.TabIndex = 17;
            pbPicture.TabStop = false;
            // 
            // btAddRecord
            // 
            btAddRecord.BackColor = Color.FromArgb(192, 255, 192);
            btAddRecord.FlatStyle = FlatStyle.Flat;
            btAddRecord.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btAddRecord.ForeColor = SystemColors.ControlText;
            btAddRecord.Location = new Point(476, 259);
            btAddRecord.Name = "btAddRecord";
            btAddRecord.Size = new Size(83, 67);
            btAddRecord.TabIndex = 18;
            btAddRecord.Text = "追加";
            btAddRecord.UseVisualStyleBackColor = false;
            btAddRecord.Click += btAddRecord_Click;
            // 
            // btModifyRecord
            // 
            btModifyRecord.BackColor = Color.FromArgb(255, 255, 192);
            btModifyRecord.FlatStyle = FlatStyle.Flat;
            btModifyRecord.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btModifyRecord.Location = new Point(565, 259);
            btModifyRecord.Name = "btModifyRecord";
            btModifyRecord.Size = new Size(81, 67);
            btModifyRecord.TabIndex = 19;
            btModifyRecord.Text = "修正";
            btModifyRecord.UseVisualStyleBackColor = false;
            // 
            // btDeleteRecod
            // 
            btDeleteRecod.BackColor = Color.FromArgb(255, 192, 192);
            btDeleteRecod.FlatStyle = FlatStyle.Flat;
            btDeleteRecod.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btDeleteRecod.Location = new Point(652, 259);
            btDeleteRecod.Name = "btDeleteRecod";
            btDeleteRecod.Size = new Size(83, 67);
            btDeleteRecod.TabIndex = 20;
            btDeleteRecod.Text = "削除";
            btDeleteRecod.UseVisualStyleBackColor = false;
            btDeleteRecod.Click += btDeleteRecod_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { ファイルFToolStripMenuItem, ヘルプHToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(785, 24);
            menuStrip1.TabIndex = 21;
            menuStrip1.Text = "menuStrip1";
            // 
            // ファイルFToolStripMenuItem
            // 
            ファイルFToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 開くToolStripMenuItem, 保存ToolStripMenuItem, toolStripSeparator2, 色設定ToolStripMenuItem, toolStripSeparator1, 終了ToolStripMenuItem });
            ファイルFToolStripMenuItem.Name = "ファイルFToolStripMenuItem";
            ファイルFToolStripMenuItem.Size = new Size(67, 20);
            ファイルFToolStripMenuItem.Text = "ファイル(&F)";
            // 
            // 開くToolStripMenuItem
            // 
            開くToolStripMenuItem.Name = "開くToolStripMenuItem";
            開くToolStripMenuItem.Size = new Size(155, 22);
            開くToolStripMenuItem.Text = "開く...";
            // 
            // 保存ToolStripMenuItem
            // 
            保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            保存ToolStripMenuItem.Size = new Size(155, 22);
            保存ToolStripMenuItem.Text = "保存...";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(152, 6);
            // 
            // 色設定ToolStripMenuItem
            // 
            色設定ToolStripMenuItem.Name = "色設定ToolStripMenuItem";
            色設定ToolStripMenuItem.Size = new Size(155, 22);
            色設定ToolStripMenuItem.Text = "色設定...";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(152, 6);
            // 
            // 終了ToolStripMenuItem
            // 
            終了ToolStripMenuItem.Name = "終了ToolStripMenuItem";
            終了ToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.F4;
            終了ToolStripMenuItem.Size = new Size(155, 22);
            終了ToolStripMenuItem.Text = "終了(&X)";
            // 
            // ヘルプHToolStripMenuItem
            // 
            ヘルプHToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { a });
            ヘルプHToolStripMenuItem.Name = "ヘルプHToolStripMenuItem";
            ヘルプHToolStripMenuItem.Size = new Size(65, 20);
            ヘルプHToolStripMenuItem.Text = "ヘルプ(&H)";
            // 
            // a
            // 
            a.Name = "a";
            a.Size = new Size(164, 22);
            a.Text = "このアプリについて...";
            // 
            // cbAuthor
            // 
            cbAuthor.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            cbAuthor.FormattingEnabled = true;
            cbAuthor.Location = new Point(112, 81);
            cbAuthor.Name = "cbAuthor";
            cbAuthor.Size = new Size(200, 33);
            cbAuthor.TabIndex = 22;
            // 
            // cbCarName
            // 
            cbCarName.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            cbCarName.FormattingEnabled = true;
            cbCarName.Location = new Point(112, 181);
            cbCarName.Name = "cbCarName";
            cbCarName.Size = new Size(200, 33);
            cbCarName.TabIndex = 23;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { tsslbMessage });
            statusStrip1.Location = new Point(0, 582);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(785, 22);
            statusStrip1.SizingGrip = false;
            statusStrip1.TabIndex = 24;
            statusStrip1.Text = "statusStrip1";
            // 
            // tsslbMessage
            // 
            tsslbMessage.Name = "tsslbMessage";
            tsslbMessage.Size = new Size(0, 17);
            // 
            // ofdPicFileOpen
            // 
            ofdPicFileOpen.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(785, 604);
            Controls.Add(statusStrip1);
            Controls.Add(cbCarName);
            Controls.Add(cbAuthor);
            Controls.Add(btDeleteRecod);
            Controls.Add(btModifyRecord);
            Controls.Add(btAddRecord);
            Controls.Add(pbPicture);
            Controls.Add(btDeletePicture);
            Controls.Add(label8);
            Controls.Add(btOpenPicture);
            Controls.Add(btNewInput);
            Controls.Add(label7);
            Controls.Add(dgvRecords);
            Controls.Add(tbReport);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(groupBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(dtpDate);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            SizeGripStyle = SizeGripStyle.Show;
            Text = "試乗レポート管理システム";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRecords).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbPicture).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DateTimePicker dtpDate;
        private Label label2;
        private Label label3;
        private GroupBox groupBox1;
        private RadioButton rbOther;
        private RadioButton rbInport;
        private RadioButton rbSubaru;
        private RadioButton rbHonda;
        private RadioButton rbNissan;
        private RadioButton rbToyota;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox tbReport;
        private DataGridView dgvRecords;
        private Label label7;
        private Button btNewInput;
        private Button btOpenPicture;
        private Label label8;
        private Button btDeletePicture;
        private PictureBox pbPicture;
        private Button btAddRecord;
        private Button btModifyRecord;
        private Button btDeleteRecod;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem ファイルFToolStripMenuItem;
        private ToolStripMenuItem 開くToolStripMenuItem;
        private ToolStripMenuItem 保存ToolStripMenuItem;
        private ToolStripMenuItem 色設定ToolStripMenuItem;
        private ToolStripMenuItem 終了ToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem ヘルプHToolStripMenuItem;
        private ToolStripMenuItem a;
        private ComboBox cbAuthor;
        private ComboBox cbCarName;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel tsslbMessage;
        private OpenFileDialog ofdPicFileOpen;
    }
}
