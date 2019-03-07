using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avo
{
    public static class Extension_Number
    {
		
        public static string ToThousandSeparator(this decimal value , int numberOfDecimalPlaces)
        {
            if (numberOfDecimalPlaces < 0) numberOfDecimalPlaces = 0;
            return string.Format("{0:N"+ numberOfDecimalPlaces + "}", value).ToString();
        }
    }
}
