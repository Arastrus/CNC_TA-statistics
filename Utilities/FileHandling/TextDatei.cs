﻿using System;
using System.IO;
using System.Text;

namespace KH.Utilities
{
    public static class TextDatei
    {
        ///<summary>
        /// Liefert den Inhalt der Datei zurück.
        ///</summary>
        ///<param name="sFilename">Dateipfad</param>
        public static string ReadFile(String sFilename)
        {
            string sContent = "";

            if (File.Exists(sFilename))
            {
                StreamReader myFile = new StreamReader(sFilename, System.Text.Encoding.Default);
                sContent = myFile.ReadToEnd();
                myFile.Close();
            }
            return sContent;
        }

        ///<summary>
        /// Schreibt den übergebenen Inhalt in eine Textdatei.
        ///</summary>
        ///<param name="sFilename">Pfad zur Datei</param>
        ///<param name="sLines">zu schreibender Text</param>
        public static void WriteFile(String sFilename, String sLines)
        {
            StreamWriter myFile = new StreamWriter(sFilename, false, System.Text.Encoding.Default);
            myFile.Write(sLines);
            myFile.Close();
        }

        ///<summary>
        /// Fügt den übergebenen Text an das Ende einer Textdatei an.
        ///</summary>
        ///<param name="sFilename">Pfad zur Datei</param>
        ///<param name="sLines">anzufügender Text</param>
        public static void Append(string sFilename, string sLines)
        {
            StreamWriter myFile = new StreamWriter(sFilename, true, System.Text.Encoding.Default);
            myFile.Write(sLines);
            myFile.Close();
        }

        ///<summary>
        /// Liefert den Inhalt der übergebenen Zeilennummer zurück.
        ///</summary>
        ///<param name="sFilename">Pfad zur Datei</param>
        ///<param name="iLine">Zeilennummer</param>
        public static string ReadLine(String sFilename, int iLine)
        {
            string sContent = "";
            float fRow = 0;
            if (File.Exists(sFilename))
            {
                StreamReader myFile = new StreamReader(sFilename, System.Text.Encoding.Default);
                while (!myFile.EndOfStream && fRow < iLine)
                {
                    fRow++;
                    sContent = myFile.ReadLine();
                }
                myFile.Close();
                if (fRow < iLine)
                    sContent = "";
            }
            return sContent;
        }

        /// <summary>
        /// Schreibt den übergebenen Text in eine definierte Zeile.
        ///</summary>
        ///<param name="sFilename">Pfad zur Datei</param>
        ///<param name="iLine">Zeilennummer</param>
        ///<param name="sLines">Text für die übergebene Zeile</param>
        ///<param name="bReplace">Text in dieser Zeile überschreiben (t) oder einfügen (f)</param>
        public static void WriteLine(String sFilename, int iLine, string sLines, bool bReplace)
        {
            string sContent = "";
            string[] delimiterstring = { "\r\n" };

            if (File.Exists(sFilename))
            {
                StreamReader myFile = new StreamReader(sFilename, System.Text.Encoding.Default);
                sContent = myFile.ReadToEnd();
                myFile.Close();
            }

            string[] sCols = sContent.Split(delimiterstring, StringSplitOptions.None);

            if (sCols.Length >= iLine)
            {
                if (!bReplace)
                    sCols[iLine - 1] = sLines + "\r\n" + sCols[iLine - 1];
                else
                    sCols[iLine - 1] = sLines;

                sContent = "";
                for (int x = 0; x < sCols.Length - 1; x++)
                {
                    sContent += sCols[x] + "\r\n";
                }
                sContent += sCols[sCols.Length - 1];

            }
            else
            {
                for (int x = 0; x < iLine - sCols.Length; x++)
                    sContent += "\r\n";

                sContent += sLines;
            }


            StreamWriter mySaveFile = new StreamWriter(sFilename, false, System.Text.Encoding.Default);
            mySaveFile.Write(sContent);
            mySaveFile.Close();
        }

        public static void RemoveLine(string fileName, int line)
        {
            // Datei existent, dann ...
            if (File.Exists(fileName))
            {
                int counter = 1;
                StringBuilder sb = new StringBuilder();
                // Zeile für Zeile in der Datei durchlaufen
                foreach (string s in File.ReadAllLines(fileName, Encoding.Default))
                {
                    // wenn Zeile ungleich der zu löschenden Zeile ist, dann...
                    if (counter != line)
                        sb.AppendLine(s); // Zeile zum StringBuilder hinzufügen

                    counter++;
                }

                // mit Hilfe des StringBuilder Inhalts, die vorhandene Datei ersetzen
                File.WriteAllText(fileName, sb.ToString(), Encoding.Default);
            }
        }
    }
}
