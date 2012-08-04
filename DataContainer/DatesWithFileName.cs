using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Website_Extractor.DataContainer
{
    public class DatesWithFileName : IComparable
    {
        private string _fileName;
        private DateTime _date;

        public DatesWithFileName(string fileName, DateTime date)
        {
            _fileName = fileName;
            _date = date;
        }

        public DateTime date
        {
            get
            {
                return _date;
            }
            set { _date = value; }
        }
        public string fileName { get { return _fileName; } set { _fileName = value; } }

        public int CompareTo(object obj)
        {
            int result = 1;
            if (obj != null && obj is DatesWithFileName)
            {
                DatesWithFileName w = obj as DatesWithFileName;
                result = this.date.CompareTo(w.date);
            }
            return result;
        }

        static public int Compare(DatesWithFileName x, DatesWithFileName y)
        {
            int result = 1;
            if (x != null && y != null)
            {
                result = x.date.CompareTo(y.date);
            }
            return result;
        }
    }
}
