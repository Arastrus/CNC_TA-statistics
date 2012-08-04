using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Website_Extractor.Utilities
{
    public static class StringConverterUtils
    {
        /// <summary>
        /// Fills a number (as string) with zeroes (left-sided)
        /// </summary>
        /// <param name="input">String to be filled with zeroes</param>
        /// <param name="length">Length of the outputstring (total)</param>
        /// <returns>the resulting string</returns>
        public static string fillWithZeroes(string input, int length) //
        {
            StringBuilder tempBuild = new StringBuilder();
            for (int i = input.Length; i < length; i++)
            {
                tempBuild.Append("0");
            }
            return tempBuild.Append(input).ToString();
        }
    }
}
