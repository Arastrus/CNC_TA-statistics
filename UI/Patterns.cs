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
    public partial class Patterns : Form
    {

        public Patterns()
        {
            InitializeComponent();
        }

        private void vistaButton2_Click(object sender, EventArgs e)
        {
            try
            {
                string[] alliances = textBox1.Text.Replace(" ", "").Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                string alliancesName = "";
                foreach (string alliance in alliances)
                {
                    alliancesName += HtmlExtractor.getAllianceNameForID(alliance) + "_&_Co";
                    break;
                }
                alliancesName = alliancesName.Substring(0, alliancesName.Length - 1);
                Directory.CreateDirectory(GlobalData.WorldPath + alliancesName);
                TextDatei.WriteFile(GlobalData.WorldPath + alliancesName + "\\ID.txt", textBox1.Text.Replace(" ", ""));
                MessageBox.Show(CnfLocalSettings.Instance.GetString("patternCreated"));
                this.Close();
            }
            catch
            {
                MessageBox.Show(CnfLocalSettings.Instance.GetString("noAllianceID"));
            }
        }

        private void Patterns_Load(object sender, EventArgs e)
        {
            this.Text = CnfLocalSettings.Instance.GetString("createSet");
            groupBox3.Text = CnfLocalSettings.Instance.GetString("byPlayerIDs");
            vistaButton1.ButtonText = CnfLocalSettings.Instance.GetString("nameOfPattern");
            label2.Text = CnfLocalSettings.Instance.GetString("spacesReplaced");
            vistaButton6.ButtonText = CnfLocalSettings.Instance.GetString("playersids");
            label1.Text = CnfLocalSettings.Instance.GetString("seperatedBy");
            vistaButton2.ButtonText = vistaButton4.ButtonText = vistaButton5.ButtonText = CnfLocalSettings.Instance.GetString("create");
            groupBox1.Text = CnfLocalSettings.Instance.GetString("byAllianceID");
            vistaButton3.ButtonText = CnfLocalSettings.Instance.GetString("allianceIDs");
            groupBox2.Text = label3.Text = vistaButton4.ButtonText = CnfLocalSettings.Instance.GetString("curDeactivated");
        }

        private void Patterns_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void vistaButton4_Click(object sender, EventArgs e)
        {
            Application.DoEvents();
            Directory.CreateDirectory(GlobalData.WorldPath + "Top50");
            TextDatei.WriteFile(GlobalData.WorldPath + "Top50\\ID.txt", "123456789");
            Application.DoEvents();
            MessageBox.Show(CnfLocalSettings.Instance.GetString("patternCreated"));
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
            groupBox2.Top = 12;
            groupBox2.Height = (this.Height - 62) / 2 - 3;
            groupBox1.Top = groupBox2.Top + groupBox2.Height + 6;
            groupBox1.Height = groupBox2.Height;
        }

        private void Patterns_Resize(object sender, EventArgs e)
        {
            Patterns_ResizeEnd(sender, e);
        }

        private void vistaButton5_Click(object sender, EventArgs e)
        {
            //if (textBox2.Text == "")
            //    MessageBox.Show("Please enter a name for the set of players you are creating");
            //else if (textBox3.Text == "")
            //    MessageBox.Show("Please enter the players' ids");
            //else
            //{
            //    HtmlExtractor.CreatePatternForPlayerIDs(textBox3.Text.Replace(" ", "").Split(new char[] {','}), textBox2.Text);
            //    MessageBox.Show("The pattern has been created.");
            //    this.Close();
            //}
        }
    }
}
