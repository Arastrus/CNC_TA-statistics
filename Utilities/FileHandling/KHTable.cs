using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ErfassungKH.Utilities;
using KH.Utilities;

namespace ErfassungKH.Tables
{
    public class KHTable
    {
        internal string _strPath;
        internal string[][] _tableData;
        internal int _iLineCount;
        internal int _iLineCountAll;
        internal string[] _headerData;

        public KHTable(string strPath)
        {
            _strPath = strPath;
            ReloadList();
        }

        public string Path
        {
            get
            {
                return _strPath;
            }
        }

        internal void ReloadList()
        {
            this._iLineCount = LineCounterNotNull() - 1;
            this._iLineCountAll = LineCounterAll() - 1;
            this._headerData = ReadContent(1);
            this._tableData = ReadTableItems();
        }

        internal virtual string[] ReadContent(int iLine)
        {
            try
            {
                string[] strLine = null;
                string line = TextDatei.ReadLine(this._strPath, iLine);
                string[] tempParts = line.Split(new char[] { '"' });
                if (tempParts.Length % 2 == 0)
                    return null;
                else
                {
                    for (int i = 1, j = tempParts.Length; i < j; i += 2)
                    {
                        tempParts[i] = tempParts[i].Replace(";", "-°t");
                    }
                    line = "";
                    for (int i = 0, j = tempParts.Length; i < j; i++)
                    {
                        if (i == tempParts.Length - 1)
                            line += tempParts[i];
                        else
                            line += tempParts[i] + '"';
                    }
                }
                strLine = line.Split(new char[] { ';', '=' });
                for (int i = 0, j = strLine.Length; i < j; i++)
                {
                    strLine[i] = strLine[i].Replace("-°t", ";");
                }
                if (strLine.Length > 1)
                    return strLine;
                else
                    return null;
            }
            catch
            {
                return null;
            }
        }

        internal string[][] ReadTableItems()
        {
            if (this._iLineCount > 0)
            {
                string[][] temp = new string[_iLineCountAll][];
                for (int x = 0; x < this._iLineCountAll; x++)
                {
                    temp[x] = ReadContent(x + 2);
                }
                string[][] ArrayToReturn = new string[_iLineCount][];
                int iIndex = 0;
                foreach (string[] line in temp)
                {
                    if (line != null)
                    {
                        ArrayToReturn[iIndex] = line;
                        iIndex++;
                    }
                }
                return ArrayToReturn;
            }
            else
                return null;
        }

        internal bool WriteContent(string headerSelect, string headerSelectValue, string value, string header)
        {
            int index = GetLine(headerSelect, headerSelectValue);
            if (index >= 0)
            {
                WriteContent(index, value, header);
                return true;
            }
            return false;
        }

        internal void WriteContent(int index, string value, string header)
        {
            string val = "";
            int j = _headerData.Length;
            for (int i = 0; i < (j - 1); i++)
            {
                if (_headerData[i] == header)
                {
                    val += value + ";";
                    _tableData[index][i] = value;
                }
                else
                {
                    if (_headerData.Length > i)
                        val += _tableData[index][i] + ";";
                    else
                        val += ";";
                }
            }
            TextDatei.WriteLine(_strPath, index + 2, val, true);
        }

        internal string[] GetRowItems(string header)
        {
            if (this.LineCountWithEmptyLines > 0)
            {
                string[] temp = new string[this.LineCountWithEmptyLines];
                for (int x = 0; x < this.LineCountWithEmptyLines; x++)
                {
                    temp[x] = GetTableItem(header, x + 1);
                }
                return temp;
            }
            else
                return null;
        }

        internal virtual string[] GetLineContent(int iLine)
        {
            string[] line = _tableData[iLine];
            return line;
        }

        internal int GetLine(string header, string value)
        {
            int j = _headerData.Length;

            for (int i = 0; i < (j - 1); i++)
            {
                if (_headerData[i] == header)
                {
                    for (int k = 0; k < LineCountWithEmptyLines; k++)
                    {
                        if (_tableData[k][i] == value)
                        {
                            return k;
                        }
                    }
                }
            }
            return -1;
        }

        internal int GetLine(int id)
        {
            for (int i = 0, j = _tableData.Length; i < j; i++)
            {
                if (_tableData[i][0] == (id).ToString())
                {
                    return i;
                }
            }
            return -1;
        }

        internal string GetTableItem(string header, int id)
        {
            for (int i = 0, j = _headerData.Length; i < j; i++)
            {
                if ((_headerData[i] == header))
                {
                    return _tableData[(GetLine(id))][i];
                }
            }
            return null;
        }

        internal int LineCounterNotNull()
        {
            int iLineCount = 0;
            try
            {
                using (var reader = File.OpenText(this._strPath))
                {
                    string line = String.Empty;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.Split(new char[] { ';', '=' }).Length > 1)
                            iLineCount++;
                    }
                }
                return iLineCount;
            }
            catch
            {
                return -1;
            }
        }

        internal int LineCounterAll()
        {
            int iLineCount = 0;
            try
            {
                using (var reader = File.OpenText(this._strPath))
                {
                    while (reader.ReadLine() != null)
                    {
                        iLineCount++;
                    }
                }
                return iLineCount;
            }
            catch
            {
                return -1;
            }
        }

        public int LineCountWithoutEmptyLines
        {
            get
            {
                return _iLineCount;
            }
        }

        public int LineCountWithEmptyLines
        {
            get
            {
                return _iLineCountAll;
            }
        }

        public string[] HeaderData
        {
            get
            {
                return _headerData;
            }
        }

        public int ContentLength
        {
            get
            {
                return _tableData.Length;
            }
        }
    }
}
