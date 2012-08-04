using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KH.Utilities;
using KH.Config;
using System.IO;
using ErfassungKH.Config;

namespace Website_Extractor
{
    public partial class Proxy : Form
    {

        public Proxy()
        {
            InitializeComponent();
        }

        private void vistaButton2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void Patterns_Load(object sender, EventArgs e)
        {
            vistaButton3.ButtonText = CnfLocalSettings.Instance.GetString("enterProxy");
        }

        private void Patterns_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void vistaButton6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Patterns_ResizeEnd(object sender, EventArgs e)
        {
        }

        private void Patterns_Resize(object sender, EventArgs e)
        {
        }

        private void vistaButton5_Click(object sender, EventArgs e)
        {
        }

        public string Value
        {
            get
            {
                return textBox1.Text;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            vistaButton2_Click(sender, e);
        }
    }
}
