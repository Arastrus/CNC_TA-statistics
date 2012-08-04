namespace Website_Extractor
{
    partial class Proxy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Proxy));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.vistaButton3 = new VistaButtonTest.VistaButton();
            this.vistaButton2 = new VistaButtonTest.VistaButton();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(7, 69);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(541, 22);
            this.textBox1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.vistaButton3);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.vistaButton2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(555, 157);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            // 
            // vistaButton3
            // 
            this.vistaButton3.BackColor = System.Drawing.Color.Transparent;
            this.vistaButton3.BaseColor = System.Drawing.Color.DimGray;
            this.vistaButton3.ButtonColor = System.Drawing.Color.Transparent;
            this.vistaButton3.ButtonText = "Gib bitte die Proxyadresse ein (im Format xxx.xxx.xxx.xxx:Port)";
            this.vistaButton3.Enabled = false;
            this.vistaButton3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vistaButton3.ForeColor = System.Drawing.Color.Black;
            this.vistaButton3.HighlightColor = System.Drawing.Color.Gainsboro;
            this.vistaButton3.Location = new System.Drawing.Point(13, 30);
            this.vistaButton3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.vistaButton3.Name = "vistaButton3";
            this.vistaButton3.Size = new System.Drawing.Size(535, 33);
            this.vistaButton3.TabIndex = 9;
            // 
            // vistaButton2
            // 
            this.vistaButton2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.vistaButton2.BackColor = System.Drawing.Color.Transparent;
            this.vistaButton2.BaseColor = System.Drawing.Color.Transparent;
            this.vistaButton2.ButtonColor = System.Drawing.Color.DarkGray;
            this.vistaButton2.ButtonText = "OK";
            this.vistaButton2.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vistaButton2.ForeColor = System.Drawing.Color.Black;
            this.vistaButton2.Location = new System.Drawing.Point(225, 111);
            this.vistaButton2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.vistaButton2.Name = "vistaButton2";
            this.vistaButton2.Size = new System.Drawing.Size(104, 34);
            this.vistaButton2.TabIndex = 1;
            this.vistaButton2.Click += new System.EventHandler(this.vistaButton2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(245, 116);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Proxy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(555, 157);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "Proxy";
            this.Text = "Proxy";
            this.Load += new System.EventHandler(this.Patterns_Load);
            this.ResizeEnd += new System.EventHandler(this.Patterns_ResizeEnd);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Patterns_KeyDown);
            this.Resize += new System.EventHandler(this.Patterns_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private VistaButtonTest.VistaButton vistaButton3;
        private VistaButtonTest.VistaButton vistaButton2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
    }
}