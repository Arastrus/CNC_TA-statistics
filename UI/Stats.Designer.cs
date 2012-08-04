namespace Website_Extractor
{
    partial class Stats
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Stats));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxShowPDF = new System.Windows.Forms.CheckBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.comboBoxLeng = new System.Windows.Forms.ComboBox();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.vistaButton5 = new VistaButtonTest.VistaButton();
            this.vistaButton4 = new VistaButtonTest.VistaButton();
            this.vistaButton3 = new VistaButtonTest.VistaButton();
            this.vistaButton2 = new VistaButtonTest.VistaButton();
            this.progressBar1 = new VistaStyleProgressBar.ProgressBar();
            this.vistaButtonGenerate = new VistaButtonTest.VistaButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork_1);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged_1);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted_1);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button1.Location = new System.Drawing.Point(339, 338);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 25);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(484, 409);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(292, 12);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "by Arastrus (dakiff@gmail.com)   V. 2.0.0";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.flowLayoutPanel1.BackgroundImage = global::Website_Extractor.Properties.Resources.ta;
            this.flowLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(18, 336);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(179, 63);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 14;
            this.listBox1.Location = new System.Drawing.Point(12, 111);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(230, 144);
            this.listBox1.TabIndex = 9;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged_1);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(191, 17);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(203, 22);
            this.comboBox1.TabIndex = 10;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 14);
            this.label1.TabIndex = 11;
            this.label1.Text = "Select world:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(188, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Last update: ";
            this.label2.Visible = false;
            // 
            // checkBoxShowPDF
            // 
            this.checkBoxShowPDF.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.checkBoxShowPDF.AutoSize = true;
            this.checkBoxShowPDF.Checked = true;
            this.checkBoxShowPDF.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxShowPDF.Location = new System.Drawing.Point(298, 308);
            this.checkBoxShowPDF.Name = "checkBoxShowPDF";
            this.checkBoxShowPDF.Size = new System.Drawing.Size(185, 18);
            this.checkBoxShowPDF.TabIndex = 19;
            this.checkBoxShowPDF.Text = "Show PDFs after creation";
            this.checkBoxShowPDF.UseVisualStyleBackColor = true;
            this.checkBoxShowPDF.CheckedChanged += new System.EventHandler(this.checkBoxShowPDF_CheckedChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.dateTimePicker1.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(576, 110);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(194, 22);
            this.dateTimePicker1.TabIndex = 20;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.dateTimePicker2.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dateTimePicker2.Location = new System.Drawing.Point(576, 148);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(194, 22);
            this.dateTimePicker2.TabIndex = 21;
            // 
            // listBox2
            // 
            this.listBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 14;
            this.listBox2.Location = new System.Drawing.Point(248, 111);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(230, 144);
            this.listBox2.TabIndex = 22;
            this.listBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBox2_KeyDown);
            this.listBox2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox2_MouseDoubleClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(526, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(45, 43);
            this.pictureBox1.TabIndex = 105;
            this.pictureBox1.TabStop = false;
            // 
            // comboBoxLeng
            // 
            this.comboBoxLeng.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.comboBoxLeng.BackColor = System.Drawing.Color.White;
            this.comboBoxLeng.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLeng.FormattingEnabled = true;
            this.comboBoxLeng.Items.AddRange(new object[] {
            "English",
            "Deutsch"});
            this.comboBoxLeng.Location = new System.Drawing.Point(576, 17);
            this.comboBoxLeng.Name = "comboBoxLeng";
            this.comboBoxLeng.Size = new System.Drawing.Size(194, 22);
            this.comboBoxLeng.TabIndex = 104;
            this.comboBoxLeng.TabStop = false;
            this.comboBoxLeng.SelectedIndexChanged += new System.EventHandler(this.comboBoxLeng_SelectedIndexChanged);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.WorkerReportsProgress = true;
            this.backgroundWorker2.WorkerSupportsCancellation = true;
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.backgroundWorker2.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker2_ProgressChanged);
            this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker2_RunWorkerCompleted2);
            // 
            // vistaButton5
            // 
            this.vistaButton5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.vistaButton5.BackColor = System.Drawing.Color.Transparent;
            this.vistaButton5.BaseColor = System.Drawing.Color.Transparent;
            this.vistaButton5.ButtonColor = System.Drawing.Color.Transparent;
            this.vistaButton5.ButtonText = "Until:";
            this.vistaButton5.Enabled = false;
            this.vistaButton5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vistaButton5.ForeColor = System.Drawing.Color.Black;
            this.vistaButton5.HighlightColor = System.Drawing.Color.Transparent;
            this.vistaButton5.Location = new System.Drawing.Point(503, 143);
            this.vistaButton5.Name = "vistaButton5";
            this.vistaButton5.Size = new System.Drawing.Size(65, 31);
            this.vistaButton5.TabIndex = 16;
            this.vistaButton5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // vistaButton4
            // 
            this.vistaButton4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.vistaButton4.BackColor = System.Drawing.Color.Transparent;
            this.vistaButton4.BaseColor = System.Drawing.Color.Transparent;
            this.vistaButton4.ButtonColor = System.Drawing.Color.Transparent;
            this.vistaButton4.ButtonText = "From:";
            this.vistaButton4.Enabled = false;
            this.vistaButton4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vistaButton4.ForeColor = System.Drawing.Color.Black;
            this.vistaButton4.HighlightColor = System.Drawing.Color.Transparent;
            this.vistaButton4.Location = new System.Drawing.Point(503, 106);
            this.vistaButton4.Name = "vistaButton4";
            this.vistaButton4.Size = new System.Drawing.Size(74, 31);
            this.vistaButton4.TabIndex = 15;
            this.vistaButton4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // vistaButton3
            // 
            this.vistaButton3.BackColor = System.Drawing.Color.Transparent;
            this.vistaButton3.BaseColor = System.Drawing.Color.Transparent;
            this.vistaButton3.ButtonColor = System.Drawing.Color.Transparent;
            this.vistaButton3.ButtonText = "Available sets of players:";
            this.vistaButton3.Enabled = false;
            this.vistaButton3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vistaButton3.ForeColor = System.Drawing.Color.Black;
            this.vistaButton3.HighlightColor = System.Drawing.Color.Transparent;
            this.vistaButton3.Location = new System.Drawing.Point(12, 79);
            this.vistaButton3.Name = "vistaButton3";
            this.vistaButton3.Size = new System.Drawing.Size(264, 31);
            this.vistaButton3.TabIndex = 8;
            this.vistaButton3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // vistaButton2
            // 
            this.vistaButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.vistaButton2.BackColor = System.Drawing.Color.Transparent;
            this.vistaButton2.BaseColor = System.Drawing.Color.Transparent;
            this.vistaButton2.ButtonColor = System.Drawing.Color.DarkGray;
            this.vistaButton2.ButtonText = "Create a new set of players";
            this.vistaButton2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vistaButton2.ForeColor = System.Drawing.Color.Black;
            this.vistaButton2.Location = new System.Drawing.Point(12, 265);
            this.vistaButton2.Name = "vistaButton2";
            this.vistaButton2.Size = new System.Drawing.Size(230, 31);
            this.vistaButton2.TabIndex = 6;
            this.vistaButton2.Click += new System.EventHandler(this.vistaButton2_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.BackColor = System.Drawing.Color.Transparent;
            this.progressBar1.Location = new System.Drawing.Point(556, 348);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(170, 27);
            this.progressBar1.TabIndex = 4;
            this.progressBar1.Visible = false;
            // 
            // vistaButtonGenerate
            // 
            this.vistaButtonGenerate.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.vistaButtonGenerate.BackColor = System.Drawing.Color.Transparent;
            this.vistaButtonGenerate.BaseColor = System.Drawing.Color.Transparent;
            this.vistaButtonGenerate.ButtonColor = System.Drawing.Color.DarkGray;
            this.vistaButtonGenerate.ButtonText = "Update selected set";
            this.vistaButtonGenerate.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vistaButtonGenerate.ForeColor = System.Drawing.Color.Black;
            this.vistaButtonGenerate.Location = new System.Drawing.Point(316, 338);
            this.vistaButtonGenerate.Name = "vistaButtonGenerate";
            this.vistaButtonGenerate.Size = new System.Drawing.Size(149, 61);
            this.vistaButtonGenerate.TabIndex = 1;
            this.vistaButtonGenerate.Click += new System.EventHandler(this.vistaButtonGenerate_Click);
            // 
            // Stats
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(781, 428);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.comboBoxLeng);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.checkBoxShowPDF);
            this.Controls.Add(this.vistaButton5);
            this.Controls.Add(this.vistaButton4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.vistaButton3);
            this.Controls.Add(this.vistaButton2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.vistaButtonGenerate);
            this.Controls.Add(this.button1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "Stats";
            this.Text = "Statistics for CNC:TA";
            this.Load += new System.EventHandler(this.Stats_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Stats_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button button1;
        private VistaButtonTest.VistaButton vistaButtonGenerate;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private VistaStyleProgressBar.ProgressBar progressBar1;
        private VistaButtonTest.VistaButton vistaButton2;
        private VistaButtonTest.VistaButton vistaButton3;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private VistaButtonTest.VistaButton vistaButton4;
        private VistaButtonTest.VistaButton vistaButton5;
        private System.Windows.Forms.CheckBox checkBoxShowPDF;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox comboBoxLeng;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;


        public System.ComponentModel.RunWorkerCompletedEventHandler backgroundWorker2_RunWorkerCompleted { get; set; }
    }
}