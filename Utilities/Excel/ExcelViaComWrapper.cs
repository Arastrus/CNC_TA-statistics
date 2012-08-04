using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rainbird.Tools.ComInterop;
using System.Reflection;

namespace Website_Extractor
{
    public static class ExcelViaComWrapper
    {
        private static object n = Missing.Value;

        public static void deleteRow(string cell1, ComObject worksheet)
        {
            ComObject r1 = getRange(cell1, "", worksheet);
            ComObject er1 = r1.GetObjectReturningProperty("EntireRow");
            er1.InvokeFunction("Delete", new object[] { n });
        }

        public static int getEnd(string cell, ComObject worksheet)
        {
            ComObject range = getRange(cell, "", worksheet);
            ComObject end = range.GetObjectReturningProperty("End", new object[] { -4162 });
            int rangeInt = (int)end.GetProperty("Row");
            return rangeInt;
        }

        public static ComObject getRange(string cell, string cell2, ComObject worksheet)
        {
            try
            {
                if (cell2 == "")
                    return worksheet.InvokeObjectReturningFunction("get_Range", new object[] { cell, n });
                else
                    return worksheet.InvokeObjectReturningFunction("get_Range", new object[] { cell, cell2 });
            }
            catch
            {
                if (cell2 == "")
                    return worksheet.GetObjectReturningProperty("Range", new object[] { cell, n });
                else
                    return worksheet.GetObjectReturningProperty("Range", new object[] { cell, cell2 });
            }
        }

        public static string getValue2ToString(string cell, ComObject worksheet)
        {
            try
            {
                ComObject nameRange = getRange(cell, "", worksheet);
                object v2 = nameRange.GetProperty("Value2");
                return v2.ToString();
            }
            catch
            {
                return "";
            }
        }

        public static void setStringToValue2(string cell, string value, ComObject worksheet)
        {
            ComObject nameRange = getRange(cell, "", worksheet);
            nameRange.SetProperty("Value2", value);
        }

        public static void setArrayToRangeValue2(string cell1, string cell2, object[,] value, ComObject worksheet)
        {
            ComObject nameRange = getRange(cell1, cell2, worksheet);
            nameRange.SetProperty("Value", value);
        }

        public static void insertRow(string cell, ComObject worksheet)
        {
            ComObject range = getRange(cell, "", worksheet);
            ComObject entireRow = range.GetObjectReturningProperty("EntireRow");
            entireRow.InvokeFunction("Insert", -4121);
        }
    }
}
