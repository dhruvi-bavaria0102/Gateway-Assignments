using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace UnitTest_2
{
    public static class ExtendMethods
    {
     
        /// <summary>
        /// Change lowercase from uppercase
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Return lowercase string.</returns>
        public static string ConvertToLower(this string a)
        {
            return a.ToLower();
        }

        /// <summary>
        /// Change lowercase to uppercase
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Return uppercase string.</returns>
        public static string ConvertToUpper(this string a)
        {
            return a.ToUpper();
        }

        /// <summary>
        /// Change string to title case
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Return string in title case letter</returns>
        public static string ConvertToTitleCase(this string a)
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            var output = textInfo.ToTitleCase(a);
            return output;
        }

        /// <summary>
        /// Find lowercase character in string
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Return number of lowercase letters.</returns>
        public static bool IsLower(this string a)
        {
            string Mystring = a;
            char[] chars;
            char ch;
            int length = Mystring.Length;
            int cnt;
            int totalcntlower = 0;

            chars = Mystring.ToCharArray(0, length);
            for (cnt = 0; cnt < length; cnt++)
            {
                ch = chars[cnt];
                if (char.IsLower(ch))
                {
                    totalcntlower++;
                }
            }
            if (totalcntlower == length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Find total uppercase letters in string.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Return number of uppercase letters.</returns>
        public static bool IsUpper(this string a)
        {
            string Mystring = a;
            char[] chars;
            char ch;
            int length = Mystring.Length;
            int cnt;
            int totalcntupper = 0;

            chars = Mystring.ToCharArray(0, length);
            for (cnt = 0; cnt < length; cnt++)
            {
                ch = chars[cnt];
                if (char.IsUpper(ch))
                {
                    totalcntupper++;
                }
            }
            if (totalcntupper == length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Verify if input string can be converted to valid numeric
        /// </summary>
        /// <param name="input"></param>
        /// <returns>It shuold return true or false.</returns>
        public static bool IsValidNumeric(this string a)
        {
            int number1 = 0;
            return int.TryParse(a, out number1);
        }

        /// <summary>
        /// Change first letter into capital letter
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Return string with first letter capital letter</returns>
        public static string ConvertToCapitalize(this string a)
        {
            return char.ToUpper(a[0]) + a.Substring(1);
        }

        /// <summary>
        /// Convert string to int
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Return true if possible otherwise return false.</returns>
        public static int? ConvertStringToNumber(this string a)
        {
            if (a.IsValidNumeric())
            {
                return int.Parse(a);
            }
            else
                return null;
        }

        /// <summary>
        /// Remove last character from string. 
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Return string without last character.</returns>
        public static string RemoveLastCharacterFrom(this string a)
        {
            return a.Remove(a.Length - 1, 1);
        }

        /// <summary>
        /// Give the totla word in the input.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Return number of words in the string.</returns>
        public static int CountingWord(this string a)
        {
            int b = 0, myWord = 1;
            while (b <= a.Length - 1)
            {
                if (a[b] == ' ' || a[b] == '\n' || a[b] == '\t')
                {
                    myWord++;
                }
                b++;
            }
            return myWord;
        }
     
    }
}
