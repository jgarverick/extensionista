using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Extensionista
{
    public static class StringExtensions
    {
        /// <summary>
        /// Extension method used to concatenate a string array into a delimited string.
        /// </summary>
        /// <param name="array">The array which will use the extension method.</param>
        /// <param name="delimiter">The character that will serve as the delimiter.</param>
        /// <returns>The contents of the string array in one string, separated by the
        /// character noted by the delimiter.</returns>
        public static string ToDelimitedString(this string[] array, char delimiter)
        {
            string retval = string.Empty;
            return array.Length > 0 ? array.ToList().ToDelimitedString(delimiter) : string.Empty;
        }
        /// <summary>
        /// Extension method used to concatenate a List of strings into a delimited string.
        /// </summary>
        /// <param name="list">The List which will use the extension method.</param>
        /// <param name="delimiter">The character that will serve as the delimiter.</param>
        /// <returns>The contents of the string array in one string, separated by the
        /// character noted by the delimiter.</returns>
        public static string ToDelimitedString(this List<string> list, char delimiter)
        {
            string retval = string.Empty;
            list.ForEach(arr => retval += arr + delimiter.ToString());
            return retval.Length > 0 ? retval.Substring(0, retval.Length - 1) : string.Empty;
        }
        /// <summary>
        /// Extension method used to encode a string into a Base64 string.
        /// </summary>
        /// <param name="source">The source string to convert.</param>
        /// <returns>A Base64 encoded string.</returns>
        /// <remarks>This method implies an ASCII encoding.</remarks>
        public static string EncodeBase64(this string source)
        {
            return string.IsNullOrEmpty(source) ? string.Empty : Convert.ToBase64String(Encoding.ASCII.GetBytes(source));
        }
        /// <summary>
        /// Extension method used to decode a Base64 string.
        /// </summary>
        /// <param name="source">The Base64 encoded string to decode.</param>
        /// <returns>A decoded string.</returns>
        /// <remarks>This method implies an ASCII encoding.</remarks>
        public static string DecodeBase64(this string source)
        {
            return string.IsNullOrEmpty(source) ? string.Empty : Encoding.ASCII.GetString(Convert.FromBase64String(source));
        }
    }
}
