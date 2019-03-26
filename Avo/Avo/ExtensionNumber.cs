using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avo
{
    public static class ExtensionNumber
    {

        #region PrivateFunctions
        private static string AddThousandsSeparator(Object numeric, int numberOfDecimalPlaces)
        {
            // note this would crash when passed a non-numeric object.
            // that's why it's private, and it's the class's responsibility
            // to limit the entry points to this function to numeric types only

            if (numberOfDecimalPlaces < 0) numberOfDecimalPlaces = 0;
            return String.Format("{0:N" + Math.Max(0, numberOfDecimalPlaces) + "}", numeric);
        }
        #endregion
        #region ThousandSeparator
         
        public static string ToThousandsSeparator(this decimal value, int numberOfDecimalPlaces)
        {
            return AddThousandsSeparator(value, numberOfDecimalPlaces);
        }

        public static string ToThousandsSeparator(this int value, int numberOfDecimalPlaces)
        {
            return AddThousandsSeparator(value, numberOfDecimalPlaces);
        }

        public static string ToThousandsSeparator(this double value, int numberOfDecimalPlaces)
        {
            return AddThousandsSeparator(value, numberOfDecimalPlaces);
        }

        public static string ToThousandsSeparator(this long value, int numberOfDecimalPlaces)
        {
            return AddThousandsSeparator(value, numberOfDecimalPlaces);
        }

        public static string ToThousandsSeparator(this float value, int numberOfDecimalPlaces)
        {
            return AddThousandsSeparator(value, numberOfDecimalPlaces);
        }

        #endregion
        
    }
}
