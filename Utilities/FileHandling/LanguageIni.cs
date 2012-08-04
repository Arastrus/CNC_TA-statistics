using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ErfassungKH.Utilities;

namespace ErfassungKH.Utilities.Languages 
{
    public class LanguageIni : ErfassungKH.Tables.KHTable
    {
        public enum eLanguageType : int
        {
            DE = 0, //INI-Werte
            EN,
            FR,
            ES,
            IT,
            NL
        }

        public eLanguageType _LandType = eLanguageType.DE;//Default
        // Languages.ini
        // key=de;en;fr;es;it;nl
        // language=Deutsch;English;Français;Español (Castellano);Italiano;Nederlands

        public LanguageIni(string strLang, string strPath)
            : base(strPath)
        {
            try
            {
                _LandType = GetLanguageFromString(strLang);
            }
            catch (Exception)
            {
                //na ja, Pech gehabt dann
                // wird als Default bleiben
            }
        }

        public void UpdateLanguage(string strLang)
        {
            _LandType = GetLanguageFromString(strLang);
        }

        public int Language
        {
            get
            {
                return (int)_LandType;
            }
        }

        public eLanguageType GetLanguageFromString(string lang)
        {
            //FOR: TwoLetterISOLanguageName
            try
            {
                return (eLanguageType)Enum.Parse(typeof(eLanguageType), lang);
            }
            catch (Exception)
            {
            }

            //etwas schief gelaufen -> versuche TwoLetterISOLanguageName
            switch (lang)
            {
                case "de":
                    return eLanguageType.DE;

                case "en":
                    return eLanguageType.EN;

                case "es":
                    return eLanguageType.ES;

                case "fr":
                    return eLanguageType.FR;

                case "it":
                    return eLanguageType.IT;

                case "nl":
                    return eLanguageType.NL;

                default:
                    break;
            }

            //wird wieder ArgumentException werfen
            return (eLanguageType)Enum.Parse(typeof(eLanguageType), lang);
        }

        public string GetStringByLanguage(string strKey)
        {
            return GetStringByCode(true, strKey);
        }

        //TODO: überarbeiten. Vorschlag: Textdatei beim Setzen der Sprache lesen und Tabelle(mit 3 Spalten) im Speicher halten
        private string GetStringByCode(bool bString, string strKey)
        {
            string strOutput = String.Empty;

            int j = _headerData.Length;
            int iColumn = 0;

            for (int k = 0; k < _iLineCount; k++)
            {
                if (_tableData[k][iColumn] == strKey)
                {
                    strOutput = _tableData[k][Language + 1];
                    break;
                }
            }

            //liefert den Key zurück, wenn der Wert nicht gefunden ist
            if (strOutput == String.Empty)
                return strKey;

            return strOutput;
        }
    }
}
