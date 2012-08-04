using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Website_Extractor
{
    public class TxtEntry : IComparable
    {
        private string _name;
        private string _id;
        private string _lastUpdate;

        public TxtEntry(string name, string id)
        {
            _name = name;
            _id = id;
        }

        public TxtEntry(string name, string id, string lastUpdate)
        {
            _name = name;
            _id = id;
            _lastUpdate = lastUpdate;
        }

        public string LastUpdate
        {
            get
            {
                return _lastUpdate;
            }
            set
            {
                _lastUpdate = value;
            }
        }

        public string ID
        {
            get
            {
                return _id;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public int CompareTo(object obj)
        {
            int result = 1;
            if (obj != null && obj is TxtEntry)
            {
                TxtEntry w = obj as TxtEntry;
                result = this.Name.CompareTo(w.Name);
            }
            return result;
        }

        static public int Compare(TxtEntry x, TxtEntry y)
        {
            int result = 1;
            if (x != null && y != null)
            {
                result = x.CompareTo(y);
            }
            return result;
        }
    }
}
