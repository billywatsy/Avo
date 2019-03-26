using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avo
{
    public static class ExtensionDate
    {
        public static bool IsBetweenRange(this DateTime dateToCheck, DateTime startDate, DateTime endDate)
        {
            return dateToCheck >= startDate && dateToCheck <= endDate;
        }

        public static int CurrrentYearDifference(this DateTime dateOfBirth)
        {
            // Calculate the age.
            // Go back to the year the person was born in case of a leap year
            var age = DateTime.Today.Year - dateOfBirth.Year;
            if (dateOfBirth > DateTime.Today.AddYears(-age))
            {
                age = -1 * age;
            } 
            return age;
        }

        /// <summary>
        ///     Span Difference 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string ToTimeSpanDifference(this DateTime date)
        {
            string time = "";
            TimeSpan span = DateTime.Now.Subtract(date);

            if (span.Days <= 1)
            {
                time = string.Format("{0:D2} hrs, {1:D2} mins, {2:D2} secs ago", span.Hours, span.Minutes, span.Seconds);
            }
            else
            {
                if (span.Days <= 28)
                {
                    time = span.Days + " day(s) ago";
                }
                else
                {
                    if (span.Days >= 30 && span.Days <= 360)
                    {
                        time = Math.Round((decimal)(span.Days / 30)) + " month(s) ago";
                    }
                    else
                    {
                        time = Math.Round((decimal)(span.Days / 360)) + " year(s) ago";
                    }
                }
            }
            return time;
        }

        public static string ToShortTimeDisplay(this DateTime date)
        {
            return string.Format("{0} {1} {2} ", date.Day , date.ToString("MMM"), date.Year);
        }
        
    }
}
