using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avo
{
    public static class ExtensionNumber
    {
        #region ThousandSeparator
        public static string ToThousandSeparator(this decimal value, int numberOfDecimalPlaces)
        {
            if (numberOfDecimalPlaces < 0) numberOfDecimalPlaces = 0;
            return string.Format("{0:N" + numberOfDecimalPlaces + "}", value).ToString();
        }
        public static string ToThousandSeparator(this int value, int numberOfDecimalPlaces)
        {
            if (numberOfDecimalPlaces < 0) numberOfDecimalPlaces = 0;
            return string.Format("{0:N" + numberOfDecimalPlaces + "}", value).ToString();
        }
        public static string ToThousandSeparator(this double value, int numberOfDecimalPlaces)
        {
            if (numberOfDecimalPlaces < 0) numberOfDecimalPlaces = 0;
            return string.Format("{0:N" + numberOfDecimalPlaces + "}", value).ToString();
        }
        public static string ToThousandSeparator(this long value, int numberOfDecimalPlaces)
        {
            if (numberOfDecimalPlaces < 0) numberOfDecimalPlaces = 0;
            return string.Format("{0:N" + numberOfDecimalPlaces + "}", value).ToString();
        }
        #endregion
    }
}
