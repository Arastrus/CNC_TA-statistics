using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Net;
using KH.Utilities;
using ErfassungKH.DataContainer;
using KH.Config;
using Rainbird.Tools.ComInterop;
using System.Runtime.InteropServices;
using Website_Extractor.DataContainer;
using System.Web.Script.Serialization;
using System.Threading;
using ErfassungKH.Config;
using System.Globalization;
using Website_Extractor.Utilities;
using System.Net.NetworkInformation;

namespace Website_Extractor
{
    public partial class Stats : Form
    {
        #region lifetime variables
        bool _loaded = false;
        string _worldsPage = "";
        string optionalProxy = "";
        List<TxtEntry> _worlds = new List<TxtEntry>();
        const int GWL_EXSTYLE = -20;
        const int WS_TABSTOP = 0x00010000;
        JavaScriptSerializer jss = new JavaScriptSerializer();
        object n = System.Reflection.Missing.Value; // Substitution von Missing.Value zur Übersichtlichkeit
        ComObject myWordApp;
        #endregion

        #region DLL imports
        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [System.Runtime.InteropServices.DllImport("user32.DLL")]
        public static extern IntPtr GetWindowThreadProcessId(int hWnd, ref IntPtr lpdwProcessID);
        #endregion

        public Stats()
        {
            InitializeComponent();
            if (!getWorlds())
            {
                string proxySaved = CnfLocalSettings.Instance.Proxy;
                if (proxySaved == "" || !CanPing(proxySaved))
                {
                    Proxy p = new Proxy();
                    if (p.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        string proxy = p.Value;
                        p.Close();
                        p.Dispose();
                        if (CanPing(proxy))
                        {
                            CnfLocalSettings.Instance.Proxy = proxy;
                            optionalProxy = proxy;
                            if (!getWorlds())
                            {
                                MessageBox.Show(CnfLocalSettings.Instance.GetString("noProxy"));
                                this.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show(CnfLocalSettings.Instance.GetString("noProxy"));
                            this.Close();
                        }
                    }
                }
                else
                {
                    optionalProxy = proxySaved;
                    if (!getWorlds())
                    {
                        MessageBox.Show(CnfLocalSettings.Instance.GetString("noProxy"));
                        this.Close();
                    }
                }

            }
        }

        private static bool CanPing(string address)
        {
            Ping ping = new Ping();

            try
            {
                PingReply reply = ping.Send(address, 2000);
                if (reply == null) return false;

                return (reply.Status == IPStatus.Success);
            }
            catch (PingException e)
            {
                return false;
            }
        }

        private bool getWorlds()
        {
            try
            {
                string path = "getWorlds";
                _worldsPage = HtmlExtractor.getMethod(path, optionalProxy);
                return true;
            }
            catch
            {
                _worldsPage = "";
                return false;
            }
        }


        #region updateFormContentMethods
        private void UpdateWorldSelection()
        {
            var jss = new JavaScriptSerializer();
            List<Dictionary<string, string>> dict = jss.Deserialize<List<Dictionary<string, string>>>(_worldsPage);

            foreach (Dictionary<string, string> dic in dict)
            {
                _worlds.Add(new TxtEntry(dic["n"], dic["id"], dic["ts"]));
            }
            _worlds.Sort();
            foreach (TxtEntry entry in _worlds)
            {
                comboBox1.Items.Add(entry.Name);
            }
        }

        private void UpdateListBox()
        {
            if (comboBox1.SelectedItem != null)
            {
                listBox1.Items.Clear();
                if (!Directory.Exists(GlobalData.WorldPath))
                    Directory.CreateDirectory(GlobalData.WorldPath);
                foreach (DirectoryInfo fi in new DirectoryInfo(GlobalData.WorldPath).GetDirectories())
                {
                    listBox1.Items.Add(fi.Name);
                }
            }
        }

        private void UpdatePatternList()
        {
            listBox2.Items.Clear();
            FileInfo[] pdfs = new DirectoryInfo(GlobalData.PatternPath).GetFiles("*.pdf");
            List<DatesWithFileName> times = getDateTimesFromFiles(pdfs);
            times.Sort();
            for (int i = 0, j = times.Count; i < j; i++)
            {
                string[] parts = times[i].fileName.Split(new char[] { '-' });
                string from = parts[0];
                string to = parts[1].Split(new string[] { ".pdf" }, StringSplitOptions.RemoveEmptyEntries)[0];
                listBox2.Items.Add(from + "-" + to);
            }
        }
        #endregion

        #region GUI-events handling
        private void Stats_Load(object sender, EventArgs e)
        {
            GlobalData.BasePath = System.Windows.Forms.Application.StartupPath + "\\";
            if (!File.Exists(CnfLocalSettings.Instance.IniFullName))
                TextDatei.WriteFile(CnfLocalSettings.Instance.IniFullName, "[General]\r\nlastWorld=0\r\nlastAlly=0\r\nlastPattern=0\r\nshowPDFs=1\r\nLanguage=0");
            #region Formsettings
            DateTime now = DateTime.Now;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd.MM.yyyy HH:mm:ss";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd.MM.yyyy HH:mm:ss";
            dateTimePicker1.MaxDate = now;
            long minTicks = (long)(60 * 60 * 24 * 60 * (long)10000000);
            dateTimePicker1.MinDate = new DateTime(DateTime.Now.Ticks - minTicks);
            dateTimePicker2.MaxDate = now;
            dateTimePicker2.MinDate = new DateTime(DateTime.Now.Ticks - minTicks);
            DateTime setToday = new DateTime(now.Year, now.Month, now.Day);
            dateTimePicker1.Value = setToday;
            try
            {
                dateTimePicker2.Value = now;
            }
            catch
            { 
            }

            SetWindowLong(this.Handle, GWL_EXSTYLE, GetWindowLong(this.Handle, GWL_EXSTYLE) | WS_TABSTOP);

            UpdateWorldSelection();
            UpdateListBox();

            string strLanguage = SetLanguage();
            try
            {
                comboBoxLeng.SelectedIndex = Convert.ToInt32(strLanguage);
            }
            catch (Exception)
            {
                comboBoxLeng.SelectedIndex = 0;
            }

            _loaded = true;

            try
            {
                comboBox1.SelectedIndex = CnfLocalSettings.Instance.LastWorld;
            }
            catch
            {
                comboBox1.SelectedIndex = -1;
            }
            try
            {
                listBox1.SelectedIndex = CnfLocalSettings.Instance.LastAlly;
            }
            catch
            {
                listBox1.SelectedIndex = -1;
            }
            try
            {
                listBox2.SelectedIndex = CnfLocalSettings.Instance.LastPattern;
            }
            catch
            {
                listBox2.SelectedIndex = -1;
            }
            try
            {
                comboBoxLeng.SelectedIndex = Convert.ToInt32(CnfLocalSettings.Instance.Language);
            }
            catch
            {
                comboBoxLeng.SelectedIndex = 0;
            }
            if (CnfLocalSettings.Instance.ShowPdfs == 1)
                checkBoxShowPDF.Checked = true;
            else
                checkBoxShowPDF.Checked = false;
            #endregion
        }

        private void listBox2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBox2.SelectedItems.Count >= 0)
                System.Diagnostics.Process.Start(GlobalData.PatternPath + listBox2.SelectedItem.ToString() + ".pdf");
        }

        private void listBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (listBox2.SelectedItems.Count >= 0 && e.KeyCode == Keys.Delete)
            {
                try
                {
                    FileInfo[] fis = new DirectoryInfo(GlobalData.PatternPath).GetFiles("*" + listBox2.SelectedItem.ToString() + "*");
                    foreach (FileInfo fi in fis)
                    {
                        fi.Delete();
                    }
                    UpdatePatternList();
                }
                catch
                {
                    MessageBox.Show(CnfLocalSettings.Instance.GetString("deleteError"));
                }
            }
        }

        public void ButtonGenerate_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            progressBar1.Visible = true;
            progressBar1.Value = 0;
            if (listBox1.SelectedItems.Count > 0 && dateTimePicker1.Value.Ticks <= dateTimePicker2.Value.Ticks)
            {
                backgroundWorker1.RunWorkerAsync(new DateTime[] { dateTimePicker1.Value, dateTimePicker2.Value });
            }
            else
            {
                MessageBox.Show(CnfLocalSettings.Instance.GetString("errorGenerate"));
                this.Enabled = true;
            }
        }

        private void Stats_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0 && _loaded)
            {
                GlobalData.PatternName = listBox1.SelectedItem.ToString();
                CnfLocalSettings.Instance.LastAlly = listBox1.SelectedIndex;
                listBox2.Items.Clear();
                UpdatePatternList();
            }
        }

        private void vistaButtonGenerate_Click(object sender, EventArgs e)
        {
            ButtonGenerate_Click(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            vistaButtonGenerate_Click(sender, e);
        }

        private void vistaButton2_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            Patterns pat = new Patterns();
            pat.FormClosing += new FormClosingEventHandler(pat_FormClosing);
            pat.ShowDialog();
        }

        void pat_FormClosing(object sender, FormClosingEventArgs e)
        {
            UpdateListBox();
            this.Enabled = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex >= 0 && _loaded)
            {
                backgroundWorker2.CancelAsync();
                label2.Visible = true;
                string lastUpdate = "";
                foreach (TxtEntry entry in _worlds)
                {
                    if (entry.Name == comboBox1.SelectedItem.ToString())
                    {
                        GlobalData.SelectedWorldURLPart = entry.ID;
                        lastUpdate = DateTimeConverterUtils.UnixTimeStampToDateTime(Convert.ToInt64(entry.LastUpdate)).ToString();
                        label2.Text = "Last update: " + lastUpdate;
                    }
                }
                CnfLocalSettings.Instance.LastWorld = comboBox1.SelectedIndex;
                GlobalData.WorldPath = GlobalData.BasePath + comboBox1.SelectedItem.ToString().Replace(' ', '_') + "\\";
                backgroundWorker2.Dispose();
                Thread.Sleep(50);
                backgroundWorker2 = new BackgroundWorker();
                backgroundWorker2.WorkerReportsProgress = true;
                backgroundWorker2.WorkerSupportsCancellation = true;
                backgroundWorker2.DoWork += new DoWorkEventHandler(backgroundWorker2_DoWork);
                backgroundWorker2.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker2_ProgressChanged);
                backgroundWorker2.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker2_RunWorkerCompleted2);
                backgroundWorker2.RunWorkerAsync(lastUpdate);
                UpdateListBox();
            }
        }

        private void checkBoxShowPDF_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowPDF.Checked)
                CnfLocalSettings.Instance.ShowPdfs = 1;
            else
                CnfLocalSettings.Instance.ShowPdfs = 0;
        }

        private void comboBoxLeng_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((comboBoxLeng.SelectedItem != null) && _loaded)
            {
                ErfassungKH.Config.CnfLocalSettings.Instance.Language = comboBoxLeng.SelectedIndex.ToString();
                SetLanguage();
                checkBoxShowPDF.Location = new Point(this.Width / 2 - checkBoxShowPDF.Width / 2, checkBoxShowPDF.Location.Y);
            }
        }
        #endregion

        #region backgroundWorker to get the data from server
        private void backgroundWorker1_DoWork_1(object sender, DoWorkEventArgs e)
        {
            try
            {
                DateTime[] args = e.Argument as DateTime[];
                DateTime from = args[0];
                DateTime to = args[1];
                e.Result = "";

                loadData(from, to);
            }
            catch (Exception ex)
            {
                e.Result = ex.Message;
            }
        }

        private void backgroundWorker1_ProgressChanged_1(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted_1(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Enabled = true;
            progressBar1.Visible = false;
            if (e.Result as string != "")
                MessageBox.Show(CnfLocalSettings.Instance.GetString("errorOccured") + e.Result as string);
            int sel = listBox1.SelectedIndex;
            listBox1.SelectedIndex = -1;
            listBox1.SelectedIndex = sel;
        }

        /// <summary>
        /// Update "lastUpdate" panel to signalize the arriving of new data to the user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            string lastUpdate = e.Argument as string;
            int time = 0;
            while (time < 500000)
            {
                Thread.Sleep(500);
                time += 500;
                if (backgroundWorker2.CancellationPending)
                    break;
                if (time >= 500000)
                {
                    List<TxtEntry> newWorlds = new List<TxtEntry>();
                    string path = "getWorlds";
                    string page = HtmlExtractor.getMethod(path, optionalProxy);
                    var jss = new JavaScriptSerializer();
                    List<Dictionary<string, string>> dict = jss.Deserialize<List<Dictionary<string, string>>>(page);

                    foreach (Dictionary<string, string> dic in dict)
                    {
                        newWorlds.Add(new TxtEntry(dic["n"], dic["id"], dic["ts"]));
                    }
                    foreach (TxtEntry entry in newWorlds)
                    {
                        if (entry.ID == GlobalData.SelectedWorldURLPart && lastUpdate != DateTimeConverterUtils.UnixTimeStampToDateTime(Convert.ToInt64(entry.LastUpdate)).ToString())
                        {
                            backgroundWorker2.ReportProgress(0, DateTimeConverterUtils.UnixTimeStampToDateTime(Convert.ToInt64(entry.LastUpdate)).ToString() as object);
                            break;
                        }
                    }
                    time = 0;
                }
            }
        }

        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            label2.Text = CnfLocalSettings.Instance.GetString("labelLastUpdate") + e.UserState as string;
            MessageBox.Show(CnfLocalSettings.Instance.GetString("updateArrived"));
        }

        private void backgroundWorker2_RunWorkerCompleted2(object sender, RunWorkerCompletedEventArgs e)
        {
        }
        #endregion

        #region Excel and data related methods (should be in other classes, but...)
        /// <summary>
        /// Awful method to get all the data
        /// </summary>
        private void loadData(DateTime from, DateTime to)
        {
            List<EntryWithFields> listEntries = new List<EntryWithFields>();
            string allIDfile = "";

            if (File.Exists(GlobalData.PatternPath + "\\ID.txt"))
            {
                backgroundWorker1.ReportProgress(5);

                allIDfile = GlobalData.PatternPath + "\\ID.txt";

                if (File.Exists(allIDfile))
                {
                    string id = TextDatei.ReadLine(allIDfile, 1);

                    if (id == "123456789")
                        ;//Function not implemented at this time (Top X players)
                    else
                    {
                        string read = HtmlExtractor.getMethod(new object[] { "getAlliancePlayersHistory", ",\"world\":\"" + GlobalData.SelectedWorldURLPart + "\",\"id\":" + id + ",\"from\":" + DateTimeConverterUtils.DateTimeToUnixTimestamp(from) + ",\"to\":" + DateTimeConverterUtils.DateTimeToUnixTimestamp(to) }, optionalProxy);
                        List<List<Player>> players = new List<List<Player>>();
                        players = (List<List<Player>>)jss.Deserialize<List<List<Player>>>(read);
                        foreach (List<Player> player in players)
                        {
                            listEntries.Add(new EntryWithFields(player[0].n, player[1].bde, player[0].bde, player[1].s, player[0].s, player[0].ID));
                        }
                    }
                }
            }
            else
            {
                if (File.Exists(GlobalData.PatternPath + "\\players.txt"))
                {
                    List<TxtEntry> idsNew = getIdsFromFile(GlobalData.PatternPath + "\\players.txt");
                    StringBuilder build = new StringBuilder();
                    for (int i = 0, j = idsNew.Count; i < j; i++)
                    {
                        if (i < (j - 1))
                            build.Append("{\"id\":" + idsNew[i].ID + "},");
                        else
                            build.Append("{\"id\":" + idsNew[i].ID + "}");
                    }

                    string read = HtmlExtractor.getMethod(new object[] { "getPlayersHistory", ",\"world\":\"" + GlobalData.SelectedWorldURLPart + "\",\"players\":[" + build.ToString() + "],\"from\":" + DateTimeConverterUtils.DateTimeToUnixTimestamp(from) + ",\"to\":" + DateTimeConverterUtils.DateTimeToUnixTimestamp(to) }, optionalProxy);
                    List<List<Player>> players = new List<List<Player>>();
                    players = (List<List<Player>>)jss.Deserialize<List<List<Player>>>(read);
                    foreach (List<Player> player in players)
                    {
                        listEntries.Add(new EntryWithFields(player[0].n, player[1].bde, player[0].bde, player[1].s, player[0].s, player[0].ID));
                    }
                }
            }

            backgroundWorker1.ReportProgress(70);
            writeDataInExcelSheet(GlobalData.BasePath + "Muster.xlsx", GlobalData.PatternPath + StringConverterUtils.fillWithZeroes(from.Day.ToString(), 2) + "." + StringConverterUtils.fillWithZeroes(from.Month.ToString(), 2) + "." + from.Year.ToString() + "-" + StringConverterUtils.fillWithZeroes(to.Day.ToString(), 2) + "." + StringConverterUtils.fillWithZeroes(to.Month.ToString(), 2) + "." + to.Year.ToString() + ".xlsx", listEntries);
        }

        private List<DatesWithFileName> getDateTimesFromFiles(FileInfo[] pdfs)
        {
            List<DatesWithFileName> dates = new List<DatesWithFileName>();
            foreach (FileInfo fi in pdfs)
            {
                dates.Add(new DatesWithFileName(fi.Name, new DateTime(Convert.ToInt32(fi.Name.Substring(6, 4)), Convert.ToInt32(fi.Name.Substring(3, 2)), Convert.ToInt32(fi.Name.Substring(0, 2)))));
            }
            dates.Sort();
            return dates;
        }

        private List<TxtEntry> getIdsFromFile(string _idAndNamesPath)
        {
            if (File.Exists(_idAndNamesPath))
            {
                string[] lines = TextDatei.ReadFile(_idAndNamesPath).Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

                List<TxtEntry> ids = new List<TxtEntry>();

                foreach (string line in lines)
                {
                    ids.Add(new TxtEntry(line.Split(new char[] { ';' })[0], line.Split(new char[] { ';' })[1]));
                }

                return ids;
            }
            else
                return new List<TxtEntry>();
        }

        private void writeDataInExcelSheet(string oldExcelFilePath, string newExcelFilePath, List<EntryWithFields> listEntries)
        {
            try
            {
                myWordApp = new ComObject("Excel.Application");
            }
            catch
            {
                MessageBox.Show(CnfLocalSettings.Instance.GetString("noOfficeInstalled"));
                this.Close();
            }

            backgroundWorker1.ReportProgress(75);

            string pdfPath = "";

            try
            {
                myWordApp.SetProperty("Visible", false);
                ComObject obj = myWordApp.GetObjectReturningProperty("Workbooks");
                ComObject workbook = obj.InvokeObjectReturningFunction("Open", oldExcelFilePath);
                ComObject objN = myWordApp.GetObjectReturningProperty("ActiveWorkbook");
                ComObject worksheet = objN.GetObjectReturningProperty("ActiveSheet");

                List<string> left = new List<string>();
                List<string> came = new List<string>();
                int rowNr = 7;

                if (oldExcelFilePath.EndsWith("Muster.xlsx"))
                {
                    listEntries.Sort();

                    object[,] values = new object[listEntries.Count, 22];
                    int maxNr = listEntries.Count + rowNr - 1;
                    string maxNrString = maxNr.ToString();
                    for (int i = 0, j = listEntries.Count; i < j; i++)
                    {
                        if (i != 0)
                            ExcelViaComWrapper.insertRow("B7", worksheet);
                        values[i, 0] = "'" + listEntries[i].Name;
                        values[i, 1] = Int32.Parse(listEntries[i].OldS);
                        values[i, 2] = "=RANG(C" + rowNr + ";C$6:C$" + maxNrString + ";0)";
                        values[i, 3] = listEntries[i].Points;
                        values[i, 4] = "=(G" + rowNr + "-D" + rowNr + ")*(-1)";
                        values[i, 5] = "=RANG(E" + rowNr + ";E$6:E$" + maxNrString + ";0)";
                        values[i, 6] = "=RUNDEN((E" + rowNr + "-C" + rowNr + ")/C" + rowNr + "*100; 2)";
                        values[i, 7] = "=RANG(H" + rowNr + ";H$6:H$" + maxNrString + ";0)";
                        values[i, 8] = "=E" + rowNr + "-C" + rowNr;
                        values[i, 9] = "=RANG(J" + rowNr + ";J$6:J$" + maxNrString + ";0)";
                        values[i, 10] = listEntries[i].OldBdE;
                        values[i, 11] = "=RANG(L" + rowNr + ";L$6:L$" + maxNrString + ";0)";
                        values[i, 12] = listEntries[i].VBases;
                        values[i, 13] = "=(P" + rowNr + "-M" + rowNr + ")*(-1)";
                        values[i, 14] = "=RANG(N" + rowNr + ";N$6:N$" + maxNrString + ";0)";
                        values[i, 15] = "=WENN(N" + rowNr + "=0;0;RUNDEN((N" + rowNr + "-L" + rowNr + ")/L" + rowNr + "*100; 2))";
                        values[i, 16] = "=RANG(Q" + rowNr + ";Q$6:Q$" + maxNrString + ";0)";
                        values[i, 17] = "=N" + rowNr + "-L" + rowNr;
                        values[i, 18] = "=RANG(S" + rowNr + ";S$6:S$" + maxNrString + ";0)";
                        values[i, 19] = "";
                        values[i, 20] = "=RANG(W" + rowNr + ";W$6:W$" + maxNrString + ";0)";
                        values[i, 21] = "=((E" + rowNr + "-$X$4)/$X$5+(H" + rowNr + "-$Y$4)/$Y$5*4+(S" + rowNr + "-$Z$4)/$Z$5*4)/9";
                        rowNr++;
                    }
                    if (CnfLocalSettings.Instance.Language == "1")
                    {
                        ExcelViaComWrapper.setArrayToRangeValue2("C2", "J2", new object[1, 1] { { CnfLocalSettings.Instance.GetString("score") } }, worksheet);
                        ExcelViaComWrapper.setArrayToRangeValue2("L2", "S2", new object[1, 1] { { CnfLocalSettings.Instance.GetString("dfb") } }, worksheet);
                        ExcelViaComWrapper.setArrayToRangeValue2("C3", "J3", new object[1, 1] { { CnfLocalSettings.Instance.GetString("before") } }, worksheet);
                        ExcelViaComWrapper.setArrayToRangeValue2("L3", "L3", new object[1, 1] { { CnfLocalSettings.Instance.GetString("before") } }, worksheet);
                        ExcelViaComWrapper.setArrayToRangeValue2("E3", "F3", new object[1, 1] { { CnfLocalSettings.Instance.GetString("now") } }, worksheet);
                        ExcelViaComWrapper.setArrayToRangeValue2("N3", "P3", new object[1, 1] { { CnfLocalSettings.Instance.GetString("now") } }, worksheet);
                        ExcelViaComWrapper.setArrayToRangeValue2("P5", "P5", new object[1, 1] { { CnfLocalSettings.Instance.GetString("now") } }, worksheet);
                        ExcelViaComWrapper.setArrayToRangeValue2("G5", "G5", new object[1, 1] { { CnfLocalSettings.Instance.GetString("now") } }, worksheet);
                        ExcelViaComWrapper.setArrayToRangeValue2("H3", "J3", new object[1, 1] { { CnfLocalSettings.Instance.GetString("inc") } }, worksheet);
                        ExcelViaComWrapper.setArrayToRangeValue2("Q3", "S3", new object[1, 1] { { CnfLocalSettings.Instance.GetString("inc") } }, worksheet);
                        ExcelViaComWrapper.setArrayToRangeValue2("C4", "C5", new object[1, 1] { { CnfLocalSettings.Instance.GetString("value") } }, worksheet);
                        ExcelViaComWrapper.setArrayToRangeValue2("E4", "E5", new object[1, 1] { { CnfLocalSettings.Instance.GetString("value") } }, worksheet);
                        ExcelViaComWrapper.setArrayToRangeValue2("L4", "L5", new object[1, 1] { { CnfLocalSettings.Instance.GetString("value") } }, worksheet);
                        ExcelViaComWrapper.setArrayToRangeValue2("N4", "N5", new object[1, 1] { { CnfLocalSettings.Instance.GetString("value") } }, worksheet);
                        ExcelViaComWrapper.setArrayToRangeValue2("F4", "G4", new object[1, 1] { { CnfLocalSettings.Instance.GetString("pos") } }, worksheet);
                        ExcelViaComWrapper.setArrayToRangeValue2("O4", "P4", new object[1, 1] { { CnfLocalSettings.Instance.GetString("pos") } }, worksheet);
                        ExcelViaComWrapper.setArrayToRangeValue2("V4", "V5", new object[1, 1] { { CnfLocalSettings.Instance.GetString("pos") } }, worksheet);
                        ExcelViaComWrapper.setArrayToRangeValue2("V2", "V2", new object[1, 1] { { CnfLocalSettings.Instance.GetString("sum") } }, worksheet);
                        ExcelViaComWrapper.setArrayToRangeValue2("V3", "V3", new object[1, 1] { { CnfLocalSettings.Instance.GetString("weighted") } }, worksheet);
                    }
                    string sumColNrString = (maxNr + 1).ToString();
                    ExcelViaComWrapper.setArrayToRangeValue2("P" + sumColNrString, "Q" + sumColNrString, new object[1, 1] { { CnfLocalSettings.Instance.GetString("sum") } }, worksheet);
                    ExcelViaComWrapper.setArrayToRangeValue2("G" + sumColNrString, "H" + sumColNrString, new object[1, 1] { { CnfLocalSettings.Instance.GetString("sum") } }, worksheet);
                    ExcelViaComWrapper.setStringToValue2("J" + sumColNrString, "=SUMME(J6:J" + maxNr + ")", worksheet);
                    ExcelViaComWrapper.setStringToValue2("S" + sumColNrString, "=SUMME(S6:S" + maxNr + ")", worksheet);
                    ExcelViaComWrapper.setStringToValue2("X4", "=MIN(E6:E" + maxNr, worksheet);
                    ExcelViaComWrapper.setStringToValue2("X5", "=(MAX(E6:E" + maxNr + ")-MIN(E6:E" + maxNr + "))/100", worksheet);
                    ExcelViaComWrapper.setStringToValue2("Y4", "=MIN(H6:H" + maxNr, worksheet);
                    ExcelViaComWrapper.setStringToValue2("Y5", "=(MAX(H6:H" + maxNr + ")-MIN(H6:H" + maxNr + "))/100", worksheet);
                    ExcelViaComWrapper.setStringToValue2("Z4", "=MIN(S6:S" + maxNr, worksheet);
                    ExcelViaComWrapper.setStringToValue2("Z5", "=(MAX(S6:S" + maxNr + ")-MIN(S6:S" + maxNr + "))/100", worksheet);
                    ExcelViaComWrapper.setArrayToRangeValue2("B7", "W" + (rowNr - 1).ToString(), values, worksheet);
                    ExcelViaComWrapper.deleteRow("B6", worksheet);
                }

                ExcelViaComWrapper.setStringToValue2("B" + (rowNr + 1).ToString(), CnfLocalSettings.Instance.GetString("gone"), worksheet);
                ExcelViaComWrapper.setStringToValue2("C" + (rowNr + 1).ToString(), CnfLocalSettings.Instance.GetString("new"), worksheet);
                ComObject r = ExcelViaComWrapper.getRange("B" + (rowNr + 2), "", worksheet);
                ComObject font = r.GetObjectReturningProperty("Font");
                font.SetProperty("Bold", true);
                ComObject r2 = ExcelViaComWrapper.getRange("C" + (rowNr + 2), "", worksheet);
                ComObject font2 = r2.GetObjectReturningProperty("Font");
                font2.SetProperty("Bold", true);

                backgroundWorker1.ReportProgress(98);

                pdfPath = newExcelFilePath.Substring(0, newExcelFilePath.Length - 4) + "pdf";
                // DBase-Datei schließen (nicht speichern) und Excel-Datei sichtbar machen
                try
                {
                    FileInfo fi = new FileInfo(newExcelFilePath);
                    if (fi.Exists == true)
                        fi.Delete();
                    workbook.InvokeFunction("SaveAs", new object[] { newExcelFilePath, n, n, n, n, n, 3, n, n, n, n, n });
                    workbook.InvokeFunction("ExportAsFixedFormat", new object[] { 0, pdfPath, n, n, n, n, n, n, n });
                    MessageBox.Show(CnfLocalSettings.Instance.GetString("createdSuccessful"));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(CnfLocalSettings.Instance.GetString("errorSaveFile") + ex.Message);
                }
                backgroundWorker1.ReportProgress(100);

                workbook.InvokeFunction("Close", new object[] { false, n, n });
                try
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                }
                catch
                {
                }
                GC.Collect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(CnfLocalSettings.Instance.GetString("unknown") + ex.Message);
            }
            killExcelInstanceById(ref myWordApp);
            GC.Collect();
            if (checkBoxShowPDF.Checked)
                System.Diagnostics.Process.Start(pdfPath);
        }

        public static void killExcelInstanceById(ref ComObject myExcelApp)
        {
            try
            {
                IntPtr processID = new IntPtr();

                //API Funktion, out val: processId
                GetWindowThreadProcessId((int)myExcelApp.GetProperty("Hwnd"), ref processID);

                System.Diagnostics.Process myExcelProcess = System.Diagnostics.Process.GetProcessById(processID.ToInt32());

                // kill it!
                myExcelProcess.Kill();
            }
            catch
            {
                //TODO: Error?
            }
        }
        #endregion

        #region languageHandling
        private string SetLanguage()
        {
            try
            {
                string strLanguage = ErfassungKH.Config.CnfLocalSettings.Instance.Language;
                CultureInfo culturInfo = Thread.CurrentThread.CurrentUICulture;
                switch (strLanguage)
                {
                    case "1":
                        culturInfo = new CultureInfo("de-DE");
                        ErfassungKH.Config.CnfLocalSettings.Instance.UpdateLanguage("de");
                        break;
                    case "0":
                        culturInfo = new CultureInfo("en-GB");
                        ErfassungKH.Config.CnfLocalSettings.Instance.UpdateLanguage("en");
                        break;
                    default:
                        break;
                }

                if (culturInfo.LCID != Thread.CurrentThread.CurrentUICulture.LCID)
                {
                    Thread.CurrentThread.CurrentUICulture = culturInfo;

                    ErfassungKH.Config.CnfLocalSettings.Instance.UpdateLanguage(culturInfo.TwoLetterISOLanguageName);

                    System.Windows.Forms.InputLanguage.CurrentInputLanguage = System.Windows.Forms.InputLanguage.FromCulture(culturInfo);

                    CultureInfo.CurrentUICulture.ClearCachedData();

                    this.Invalidate(true);
                }
                SetControlTexts();
                return strLanguage;
            }
            catch
            {
            }

            return "";
        }

        private void SetControlTexts()
        {
            this.Text = CnfLocalSettings.Instance.GetString("formName");
            label1.Text = CnfLocalSettings.Instance.GetString("labelWorld");
            label2.Text = CnfLocalSettings.Instance.GetString("labelLastUpdate") + label2.Text.Split(new char[] { ':' })[1] + ":" + label2.Text.Split(new char[] { ':' })[2];
            vistaButton3.ButtonText = CnfLocalSettings.Instance.GetString("availableSets");
            vistaButton2.ButtonText = CnfLocalSettings.Instance.GetString("createSet");
            vistaButtonGenerate.ButtonText = CnfLocalSettings.Instance.GetString("updateSel");
            vistaButton4.ButtonText = CnfLocalSettings.Instance.GetString("from");
            vistaButton5.ButtonText = CnfLocalSettings.Instance.GetString("until");
            checkBoxShowPDF.Text = CnfLocalSettings.Instance.GetString("showPDFs");
        }
        #endregion
    }
}
