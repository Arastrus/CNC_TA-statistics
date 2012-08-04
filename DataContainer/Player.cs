using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Website_Extractor.DataContainer
{
    class Player
    {
        public Player()
        {
            b = new List<Base>();
        }

        public string ID
        {
            get;
            set;
        }
        public string n
        {
            get;
            set;
        }
        public string aid
        {
            get;
            set;
        }
        public string fid
        {
            get;
            set;
        }
        public string s
        {
            get;
            set;
        }
        public string bc
        {
            get;
            set;
        }
        public string bd
        {
            get;
            set;
        }
        public string bde
        {
            get;
            set;
        }
        public string bdp
        {
            get;
            set;
        }
        public string dtc
        {
            get;
            set;
        }
        public string ts
        {
            get;
            set;
        }
        public List<Base> b
        {
            get;
            set;
        }
    }
}
