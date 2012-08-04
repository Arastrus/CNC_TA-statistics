using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ErfassungKH.DataContainer;
using ErfassungKH.Utilities;
using System.Threading;
using KH.Config;
using KH.Utilities;

namespace ErfassungKH.Config
{
    public class CnfLocalSettings : ErfassungKH.Config.CnfSettings<CnfLocalSettings>
    {
        protected IniFile _iniFile = null;
        protected ErfassungKH.Utilities.Languages.LanguageIni _langIni = null;

        /// <summary>
        /// Default constructor for this class (required for serialization).
        /// </summary>
        protected CnfLocalSettings()
        {
            base._FileFullNameIni = GlobalData.BasePath + "CNC statistics.ini";
            _iniFile = new IniFile(_FileFullNameIni);

            if (CreateNewLangIni(Language) == false)
            {
                //was nun ? _langIni erzeugen ?? , sonst null 
                _langIni = new ErfassungKH.Utilities.Languages.LanguageIni("0", "");
            }
        }

        public static CnfLocalSettings Instance
        {
            get
            {
                if (_Instance == null)
                {
                    // for thread safety, lock an object when
                    // instantiating the new Logger object. This prevents
                    // other threads from performing the same block at the
                    // same time.
                    lock (thisLock)
                    {
                        // Two or more threads might have found a null
                        // mLogger and are therefore trying to create a 
                        // new one. One thread will get to lock first, and
                        // the other one will wait until mLock is released.
                        // Once the second thread can get through, mLogger
                        // will have already been instantiated by the first
                        // thread so test the variable again. 
                        if (_Instance == null)
                        {
                            _Instance = new CnfLocalSettings();

                            //TODO: prüfen, wenn Exception !!! 
                        }
                    }
                }
                return _Instance;
            }
        }

        public string IniFullName
        {
            get { return _FileFullNameIni; }
        }

        public int LastWorld
        {
            get
            {
                return Convert.ToInt32(_iniFile.ReadValue("General", "lastWorld"));
            }
            set
            {
                _iniFile.WriteValue("General", "lastWorld", value.ToString());
            }
        }

        public int LastPattern
        {
            get
            {
                return Convert.ToInt32(_iniFile.ReadValue("General", "lastPattern"));
            }
            set
            {
                _iniFile.WriteValue("General", "lastPattern", value.ToString());
            }
        }

        public int LastAlly
        {
            get
            {
                return Convert.ToInt32(_iniFile.ReadValue("General", "lastAlly"));
            }
            set
            {
                _iniFile.WriteValue("General", "lastAlly", value.ToString());
            }
        }

        public string Language
        {
            get
            {
                return _iniFile.ReadValue("General", "Language");
            }
            set
            {
                _iniFile.WriteValue("General", "Language", value);
            }
        }

        public string Proxy
        {
            get
            {
                return _iniFile.ReadValue("General", "Proxy");
            }
            set
            {
                _iniFile.WriteValue("General", "Proxy", value);
            }
        }

        public bool CreateNewLangIni(string strLang)
        {
            try
            {
                string strLangIniPath = GlobalData.BasePath + @"\Languages.ini";
                if (File.Exists(strLangIniPath))
                    _langIni = new ErfassungKH.Utilities.Languages.LanguageIni(strLang, strLangIniPath);
                else
                    return false;

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public String GetString(string strKey)
        {
            return _langIni.GetStringByLanguage(strKey);
        }
        
        internal void UpdateLanguage(string strLang)
        {
            _langIni.UpdateLanguage(strLang);
        }

        public int ShowPdfs
        {
            get
            {
                return Convert.ToInt32(_iniFile.ReadValue("General", "showPDFs"));
            }
            set
            {
                _iniFile.WriteValue("General", "showPDFs", value.ToString());
            }
        }
    }
}