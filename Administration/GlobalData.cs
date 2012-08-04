using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;

namespace KH.Config
{
    public static class GlobalData
    {
        private static string _sPatternName = "";
        private static string _sBasePath = "";
        private static string _sBaseURLPath = "http://stats.cnc-alliances.com/";
        private static string _sWorldPath = "";
        private static string _sSelectedWorldURLPart = "";

        public static string PatternName
        {
            get
            {
                return _sPatternName;
            }
            set
            {
                _sPatternName = value;
            }
        }

        public static string PatternPath
        {
            get
            {
                return _sWorldPath + _sPatternName + "\\";
            }
        }

        public static string WorldPath
        {
            get
            {
                return _sWorldPath;
            }
            set
            {
                _sWorldPath = value;
            }
        }

        public static string BasePath
        {
            get
            {
                return _sBasePath;
            }
            set
            {
                _sBasePath = value;
            }
        }

        public static string BaseURLPath
        {
            get
            {
                return _sBaseURLPath;
            }
        }

        public static string SelectedWorldURLPart
        {
            get
            {
                return _sSelectedWorldURLPart;
            }
            set
            {
                _sSelectedWorldURLPart = value;
            }
        }
    }
}