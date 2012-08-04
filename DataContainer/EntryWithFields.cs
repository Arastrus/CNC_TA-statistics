using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Website_Extractor
{
    class EntryWithFields : IComparable
    {
        string _name;
        string _vbases;
        string _points;
        string _id;
        string _oldS;
        string _oldBdE;

        public EntryWithFields(string name, string vbases, string vbasesOld, string points, string pointsOld, string id)
        {
            _name = name;
            _vbases = vbases;
            _points = points;
            _id = id;
            _oldBdE = vbasesOld;
            _oldS = pointsOld;
        }

        public string OldS
        {
            get
            {
                return _oldS;
            }
            set
            {
                _oldS = value;
            }
        }

        public string OldBdE
        {
            get
            {
                return _oldBdE;
            }
            set
            {
                _oldBdE = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public string VBases
        {
            get
            {
                return _vbases;
            }
        }

        public string Points
        {
            get
            {
                return _points;
            }
        }

        public string ID
        {
            get
            {
                return _id;
            }
        }

        public int CompareTo(object obj)
        {
            int result = 1;
            if (obj != null && obj is EntryWithFields)
            {
                EntryWithFields w = obj as EntryWithFields;
                result = this.Name.CompareTo(w.Name);
            }
            return result;
        }

        static public int Compare(EntryWithFields x, EntryWithFields y)
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
