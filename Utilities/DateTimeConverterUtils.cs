using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Website_Extractor.Utilities
{
    public static class DateTimeConverterUtils
    {

        public static DateTime UnixTimeStampToDateTime(long unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }

        public static long DateTimeToUnixTimestamp(DateTime _DateTime)
        {
            TimeSpan _UnixTimeSpan = (_DateTime - new DateTime(1970, 1, 1, 0, 0, 0));
            return (long)_UnixTimeSpan.TotalSeconds;
        }
    }
}
