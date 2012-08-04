using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

namespace ErfassungKH.DataContainer
{
    public class IniFile
    {
        public string _strPath;

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string strSection,
          string strKey, string strVal, string strFilePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string strSection,
          string strKey, string strDef, StringBuilder strbRetVal,
          int iSize, string strFilePath);

        public IniFile(string strINIPath)
        {
            _strPath = strINIPath;
        }

        public void WriteValue(string strSection, string strKey, string strValue)
        {
            WritePrivateProfileString(strSection, strKey, strValue, this._strPath);
        }

        public string ReadValue(string stSection, string strKey)
        {
            StringBuilder strbTemp = new StringBuilder(255);
            int i = GetPrivateProfileString(stSection, strKey, "", strbTemp, 255, this._strPath);
            return strbTemp.ToString();
        }
    }
}
