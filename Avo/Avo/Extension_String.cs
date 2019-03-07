using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avo
{
    public static class Extension_String
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
        public static string Except(this string originalValue, string charactersToAdd, int numberOfWords)
        {
            var showValueEndExceptValue = false;
            if (string.IsNullOrEmpty(originalValue))
            {
                return null;
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
    }
}
