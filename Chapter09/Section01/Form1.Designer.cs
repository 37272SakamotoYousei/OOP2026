namespace Section01 {
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
            dtpDate = new DateTimePicker();
            btGet = new Button();
            tbOut = new TextBox();
            nudDay = new NumericUpDown();
            label1 = new Label();
            dtpBirth = new DateTimePicker();
            btBithCalc = new Button();
            tbOut2 = new TextBox();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)nudDay).BeginInit();
            SuspendLayout();
            // 
            // dtpDate
            // 
            dtpDate.Font = new Font("Yu Gothic UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            dtpDate.Location = new Point(65, 26);
            dtpDate.Margin = new Padding(6);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(461, 43);
            dtpDate.TabIndex = 0;
            dtpDate.ValueChanged += dtpDate_ValueChanged;
            // 
            // btGet
            // 
            btGet.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btGet.Location = new Point(538, 26);
            btGet.Margin = new Padding(6);
            btGet.Name = "btGet";
            btGet.Size = new Size(139, 43);
            btGet.TabIndex = 1;
            btGet.Text = "計算";
            btGet.UseVisualStyleBackColor = true;
            btGet.Click += btGet_Click;
            // 
            // tbOut
            // 
            tbOut.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            tbOut.Location = new Point(194, 194);
            tbOut.Margin = new Padding(6);
            tbOut.Name = "tbOut";
            tbOut.Size = new Size(611, 29);
            tbOut.TabIndex = 2;
            tbOut.TextChanged += tbOut_TextChanged;
            // 
            // nudDay
            // 
            nudDay.Font = new Font("Yu Gothic UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            nudDay.Location = new Point(65, 87);
            nudDay.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            nudDay.Name = "nudDay";
            nudDay.Size = new Size(120, 43);
            nudDay.TabIndex = 3;
            nudDay.ValueChanged += nudDay_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label1.Location = new Point(194, 93);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(71, 37);
            label1.TabIndex = 4;
            label1.Text = "日後";
            // 
            // dtpBirth
            // 
            dtpBirth.Font = new Font("Yu Gothic UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            dtpBirth.Location = new Point(65, 139);
            dtpBirth.Margin = new Padding(6);
            dtpBirth.Name = "dtpBirth";
            dtpBirth.Size = new Size(461, 43);
            dtpBirth.TabIndex = 5;
            // 
            // btBithCalc
            // 
            btBithCalc.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btBithCalc.Location = new Point(538, 139);
            btBithCalc.Margin = new Padding(6);
            btBithCalc.Name = "btBithCalc";
            btBithCalc.Size = new Size(139, 43);
            btBithCalc.TabIndex = 6;
            btBithCalc.Text = "計算";
            btBithCalc.UseVisualStyleBackColor = true;
            btBithCalc.Click += btBithCalc_Click;
            // 
            // tbOut2
            // 
            tbOut2.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            tbOut2.Location = new Point(194, 235);
            tbOut2.Margin = new Padding(6);
            tbOut2.Name = "tbOut2";
            tbOut2.Size = new Size(611, 29);
            tbOut2.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label2.Location = new Point(151, 200);
            label2.Name = "label2";
            label2.Size = new Size(34, 17);
            label2.TabIndex = 8;
            label2.Text = "年齢";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label3.Location = new Point(125, 241);
            label3.Name = "label3";
            label3.Size = new Size(60, 17);
            label3.TabIndex = 9;
            label3.Text = "経過日数";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2321, 1374);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(tbOut2);
            Controls.Add(btBithCalc);
            Controls.Add(dtpBirth);
            Controls.Add(label1);
            Controls.Add(nudDay);
            Controls.Add(tbOut);
            Controls.Add(btGet);
            Controls.Add(dtpDate);
            Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            Margin = new Padding(6);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)nudDay).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dtpDate;
        private Button btGet;
        private TextBox tbOut;
        private NumericUpDown nudDay;
        private Label label1;
        private DateTimePicker dtpBirth;
        private Button btBithCalc;
        private TextBox tbOut2;
        private Label label2;
        private Label label3;
    }
}
