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
        public static string Except(this string originalValue, string charactersToAdd, int numberOfWords , int maximumWord)
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
            if (value == null) return null;
            string clean = System.Text.RegularExpressions.Regex.Replace(value, @"[^a-zA-Z0-9\s]", string.Empty);
            return clean;
        }
        public static string RemoveCharacterInAString(string characterToRemove, string originalString)
        {
            if (string.IsNullOrEmpty(characterToRemove))
            {
                return originalString;
            }
            return System.Text.RegularExpressions.Regex.Replace(originalString, characterToRemove, "");
        }

        public static string RemoveWhiteSpaces(string originalStringValue)
        {
            if (string.IsNullOrEmpty(originalStringValue))
            {
                return null;
            }
            originalStringValue = originalStringValue.Trim();
            return System.Text.RegularExpressions.Regex.Replace(originalStringValue, @"\s+", "");
        }
    }
}
