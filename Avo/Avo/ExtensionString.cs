using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avo
{
    public static class ExtensionString
    {
        /// <summary>
        ///  example we have a phrase " welcome to contoso unvisert"
        /// 
        /// Except("welcome to contoso unvisert", "..." , 2)
        /// 
        /// this will return "welcome to"
        /// </summary>
        /// <param name="originalValue"></param>
        /// <param name="charactersToAdd"></param>
        /// <param name="numberOfWords"></param>
        /// <returns></returns>
        public static string Excerpt(this string originalValue, string charactersToAdd, int numberOfWords , int maximumWord)
        {
            var showValueEndExceptValue = false;
            if (string.IsNullOrEmpty(originalValue.Trim()))
            {
                return null;
            } 
            if(originalValue.Length > maximumWord)
            {
                return originalValue.Substring(0 , maximumWord);
            }

            char[] delimiters = new char[] { ' ', '\r', '\n' };
            var totalWords = originalValue.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Length;
            if (numberOfWords > totalWords)
            {
               numberOfWords = totalWords;
            }
            else
            {
                showValueEndExceptValue = true;
            }
            var newWord = string.Join(" ", originalValue.Split().Take(numberOfWords));
            if (showValueEndExceptValue)
            {
                newWord += charactersToAdd;
            }
            return newWord;
        }

        /// <summary>
        /// clean string to allow A-Za-z0-9 and spaces , underscores , '
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToAlphaNumericWithOutSpace(this string value)
        {
            if (string.IsNullOrEmpty(value)) return null;
            string clean = System.Text.RegularExpressions.Regex.Replace(value, @"[^a-zA-Z0-9\s]", string.Empty);
            return clean;
        }

        public static string RemoveCharacterInAString(string characterToRemove, string originalString)
        {
            if (string.IsNullOrEmpty(characterToRemove) || string.IsNullOrEmpty(originalString)) return originalString;
            return System.Text.RegularExpressions.Regex.Replace(originalString, characterToRemove, "");
        }

        public static string RemoveWhiteSpaces(string originalStringValue)
        {
            if (string.IsNullOrEmpty(originalStringValue)) return null;
            originalStringValue = originalStringValue.Trim();
            return System.Text.RegularExpressions.Regex.Replace(originalStringValue, @"\s+", "");
        }
        
        public static bool IsDate(this string data)
        {
            DateTime date = new DateTime();
            if (DateTime.TryParse(data, out date))
            {
                return true;
            }
            return false;
        }

        public static string ToNegativeBracketFormat(this string valueStringNumber)
        {
            if (!string.IsNullOrEmpty(valueStringNumber))
            {
                if (((valueStringNumber.ToCharArray().Count(c => c == '(')) + (valueStringNumber.ToCharArray().Count(c => c == ')'))) == 2)
                {
                    valueStringNumber = "-" + valueStringNumber.Replace(@"(", string.Empty).Replace(@")", string.Empty).Trim();
                }
            }
            return valueStringNumber;
        }
         
        public static int ToInt32(this string value)
        {
            int number;
            Int32.TryParse(value, out number);
            return number;
        }

        public static bool ToBoolean(this string value)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("value");
            }
            string val = value.ToLower().Trim();
            switch (val)
            {
                case "false":
                    return false;
                case "f":
                    return false;
                case "true":
                    return true;
                case "t":
                    return true;
                case "yes":
                    return true;
                case "no":
                    return false;
                case "y":
                    return true;
                case "n":
                    return false;
                default:
                    throw new ArgumentException("Invalid boolean");
            }
        } 

        public static string CapitalizeFirstLetterOnly(this string s)
        {
            if (string.IsNullOrEmpty(s)) return s;
            return s.Substring(0, 1).ToUpper() + s.Substring(1).ToLower();
        }
        
        /// <summary>
        ///     Replace specified characters with an empty string.
        /// </summary>
        /// <param name="s">the string</param>
        /// <param name="chars">list of characters to replace from the string</param>
        /// <example>
        ///     string s = "Friends";
        ///     s = s.Replace('F', 'r','i','s');  //s becomes 'end;
        /// </example>
        /// <returns>System.string</returns>
        public static string Replace(this string s, params char[] chars)
        {
            return chars.Aggregate(s, (current, c) => current.Replace(c.ToString(System.Globalization.CultureInfo.InvariantCulture), ""));
        }

        /// <summary>
        ///     Remove Characters from string
        /// </summary>
        /// <param name="s">string to remove characters</param>
        /// <param name="chars">array of chars</param>
        /// <returns>System.string</returns>
        public static string RemoveChars(this string s, params char[] chars)
        {
            var sb = new StringBuilder(s.Length);
            foreach (char c in s.Where(c => !chars.Contains(c)))
            {
                sb.Append(c);
            }
            return sb.ToString();
        }

        public static bool IsRequiredLength(this string val, int minCharLength, int maxCharLength)
        {
            return val != null && val.Length >= minCharLength && val.Length <= minCharLength;
        }

        public static bool HasNumbers(string input)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(input, "\\d+");
        }
    }
}
