using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Serialization;

namespace TFSManager.Core
{
    public static class Util
    {
        public const string NA = "N/A";
        private const string REGEX_FILENAME_NORMALIZE = @"[^A-Za-z0-9_.\-]";
        private const UInt32 WM_VSCROLL = 0x0115;

        [DllImport("Shlwapi.dll", CharSet = CharSet.Auto)]
        public static extern long StrFormatByteSize(long fileSize,
            [MarshalAs(UnmanagedType.LPTStr)] StringBuilder buffer,
            int bufferSize);

        [DllImport("wininet.dll", SetLastError = true)]
        public static extern bool InternetGetCookie(
            string url, string cookieName,
            StringBuilder cookieData, ref int size);

        public static string GetUriCookie(Uri uri)
        {
            string result = null;

            // Determine the size of the cookie
            int datasize = 256;
            var cookieData = new StringBuilder(datasize);

            if (!InternetGetCookie(uri.ToString(), null, cookieData,
                ref datasize))
            {
                if (datasize < 0)
                {
                    return null;
                }

                // Allocate stringbuilder large enough to hold the cookie
                cookieData = new StringBuilder(datasize);
                if (!InternetGetCookie(uri.ToString(), null, cookieData,
                    ref datasize))
                {
                    return null;
                }
            }

            if (cookieData.Length > 0)
            {
                result = cookieData.ToString().Replace(';', ',');
            }

            return result;
        }

        public static string StringFormatByteSize(long fileSize)
        {
            var sbBuffer = new StringBuilder(20);
            StrFormatByteSize(fileSize, sbBuffer, 20);
            return sbBuffer.ToString();
        }

        public static int StrToInt(string str)
        {
            return StrToInt(str, 0);
        }

        public static int StrToInt(string str, int defaultValue)
        {
            int value = defaultValue;
            int.TryParse(str.Trim(), out value);

            return value;
        }

        public static string DateTimeToString(DateTime date)
        {
            return date == DateTime.MinValue ? NA : date.ToString();
        }

        /// <summary>
        /// Joins the collection to string with separator.
        /// </summary>
        /// <param name="collection">collection</param>
        /// <param name="separator">separator</param>
        /// <returns>joined string with separator</returns>
        public static string JoinCollection(ICollection collection, string separator)
        {
            if (collection != null)
            {
                var sb = new StringBuilder();

                if (!IsNullOrEmpty(separator))
                {
                    foreach (object item in collection)
                    {
                        sb.Append(item.ToString());
                        sb.Append(separator);
                    }


                    int separatorLength = separator.Length;
                    if (sb.Length > 0)
                    {
                        sb.Remove(sb.Length - separatorLength, separatorLength);
                    }
                }
                else
                {
                    foreach (object item in collection)
                    {
                        sb.Append(item.ToString());
                    }
                }

                return sb.ToString();
            }
            else
            {
                return null;
            }
        }

        public static string RemoveDiacritics(string value)
        {
            string stFormD = value.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();

            for (int ich = 0; ich < stFormD.Length; ich++)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(stFormD[ich]);
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(stFormD[ich]);
                }
            }

            return (sb.ToString().Normalize(NormalizationForm.FormC));
        }

        /// <summary>
        /// Hashes the string as byte array always 16 bytes length.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public static byte[] HashString(string key)
        {
            if (key == null)
            {
                throw new ArgumentNullException(key);
            }
            byte[] bytes = Encoding.Unicode.GetBytes(key);
            MD5 md = new MD5CryptoServiceProvider();
            return md.ComputeHash(bytes);
        }

        /// <summary>
        /// Determines whether flags enum value has given flag value set.
        /// </summary>
        /// <param name="flagToTest">Enum flag value to test for.</param>
        /// <param name="testSource">Enum flags value where to test for <c>flagToTest</c> if is set.</param>
        /// <returns>Returns true if <c>flagToTest</c> is set in enum <c>testSource</c>.</returns>
        public static bool IsFlagSet(Enum flagToTest, Enum testSource)
        {
            int iflagToTest = Convert.ToInt32(flagToTest);
            int itestSource = Convert.ToInt32(testSource);

            return ((itestSource & iflagToTest) == iflagToTest);
        }

        public static bool StringContains(string str, string contains, bool ignoreCase)
        {
            if (str == null)
            {
                return false;
            }

            return ignoreCase
                ? str.IndexOf(contains, StringComparison.CurrentCultureIgnoreCase) > -1
                : str.Contains(contains);
        }

        public static Color GetResultColor(bool result)
        {
            return result ? Color.Blue : Color.Red;
        }

        /// <summary>
        /// Determines whether specified string is null or empty
        /// </summary>
        /// this method replaces <see cref="string.IsNullOrEmpty"/> method because a bug
        /// <param name="value">string</param>
        /// <returns>
        /// 	<c>true</c> if specified value is null or empty; otherwise, <c>false</c>.
        /// </returns>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool IsNullOrEmpty(string value)
        {
            if (value != null)
            {
                return value.Length == 0;
            }
            return true;
        }

        /// <summary>
        /// Compare two string values if they are equal. 
        /// </summary>
        /// <param name="str1">First string value to compare.</param>
        /// <param name="str2">Second string value to compare.</param>
        /// <param name="ignoreCase">True to ignore case.</param>
        /// <returns>Returns true if specified string values are equal, of false if not.</returns>
        public static bool StrEqual(string str1, string str2, bool ignoreCase)
        {
            return (string.Compare(str1, str2, ignoreCase) == 0);
        }

        /// <summary>
        /// Tests if specified string ends with other specified string.
        /// </summary>
        /// <param name="source">Source string.</param>
        /// <param name="endWith">End with string.</param>
        /// <param name="ignoreCase">True to ignore case, false to not ignore case.</param>
        /// <returns>Returns true if <c>source</c> ends with <c>endWith</c>.</returns>
        public static bool StrEndWith(string source, string endWith, bool ignoreCase)
        {
            if (ignoreCase)
            {
                source = source.ToUpper();
                endWith = endWith.ToUpper();
            }

            return source.EndsWith(endWith);
        }

        /// <summary>
        /// Tests if specified string end with other specified string.
        /// </summary>
        /// <param name="source">Source string.</param>
        /// <param name="endWith">End with string.</param>
        /// <returns>Returns true if <c>source</c> ends with <c>endWith</c>.</returns>
        /// <remarks>Parameter <c>ignoreCase</c> is set to true.</remarks>
        public static bool StrEndWith(string source, string endWith)
        {
            return StrStartWith(source, endWith, true);
        }

        /// <summary>
        /// Tests if specified string contains other specified string.
        /// </summary>
        /// <param name="source">Source string.</param>
        /// <param name="contain">Contains string.</param>
        /// <param name="ignoreCase">True to ignore case, false to not ignore case.</param>
        /// <returns>Returns true if <c>source</c> contains <c>contain</c>.</returns>
        public static bool StrContain(string source, string contain, bool ignoreCase)
        {
            if (ignoreCase)
            {
                source = source.ToUpper();
                contain = contain.ToUpper();
            }

            return source.Contains(contain);
        }

        /// <summary>
        /// Tests if specified string contains other specified string.
        /// </summary>
        /// <param name="source">Source string.</param>
        /// <param name="contain">Contains string.</param>
        /// <returns>Returns true if <c>source</c> contains <c>contain</c>.</returns>
        /// <remarks>Parameter <c>ignoreCase</c> is set to true.</remarks>
        public static bool StrContain(string source, string contain)
        {
            return StrContain(source, contain, true);
        }

        /// <summary>
        /// Tests if specified string start with other specified string.
        /// </summary>
        /// <param name="source">Source string.</param>
        /// <param name="startWith">Start with string.</param>
        /// <param name="ignoreCase">True to ignore case, false to not ignore case.</param>
        /// <returns>Returns true if <c>source</c> starts with <c>startWith</c>.</returns>
        public static bool StrStartWith(string source, string startWith, bool ignoreCase)
        {
            if (ignoreCase)
            {
                source = source.ToUpper();
                startWith = startWith.ToUpper();
            }

            return source.StartsWith(startWith);
        }

        /// <summary>
        /// Tests if specified string start with other specified string.
        /// </summary>
        /// <param name="source">Source string.</param>
        /// <param name="startWith">Start with string.</param>
        /// <returns>Returns true if <c>source</c> starts with <c>startWith</c>.</returns>
        /// <remarks>Parameter <c>ignoreCase</c> is set to true.</remarks>
        public static bool StrStartWith(string source, string startWith)
        {
            return StrStartWith(source, startWith, true);
        }

        /// <summary>
        /// Compares source string if is occured in specified array of strings.
        /// </summary>
        /// <param name="source">Source string.</param>
        /// <param name="ignoreCase">True to ignore case, false to not ignore case.</param>
        /// <param name="mustMatchAll">True if all strings in <c>toStrings</c> must be equal to <c>source</c>, false if only one must be equal.</param>
        /// <param name="toStrings">Array of string to compare <c>source</c> string with.</param>
        /// <returns>
        /// If <c>mustMatchAll</c> is true, then returns true only if all items in <c>toStrings</c> are equal to <c>source</c>, otherwise returns false.
        /// If <c>mustMatchAll</c> is false, then returns true if at least one item from <c>toStrings</c> is equal to <c>source</c>, 
        /// otherwise returns false.
        /// </returns>
        public static bool StrEqual(string source, bool ignoreCase, bool mustMatchAll, params string[] toStrings)
        {
            bool res = false;

            foreach (string s in toStrings)
            {
                res = StrEqual(source, s, ignoreCase);
                if (mustMatchAll)
                {
                    if (!res)
                    {
                        return false;
                    }
                }
                else
                {
                    if (res)
                    {
                        break;
                    }
                }
            }

            return res;
        }

        /// <summary>
        /// Compares source string if is occured in specified array of strings.
        /// </summary>
        /// <param name="source">Source string.</param>
        /// <param name="mustMatchAll">True if all strings in <c>toStrings</c> must be equal to <c>source</c>, false if only one must be equal.</param>
        /// <param name="toStrings">Array of string to compare <c>source</c> string with.</param>
        /// <returns>
        /// If <c>mustMatchAll</c> is true, then returns true only if all items in <c>toStrings</c> are equal to <c>source</c>, otherwise returns false.
        /// If <c>mustMatchAll</c> is false, then returns true if at least one item from <c>toStrings</c> is equal to <c>source</c>, 
        /// otherwise returns false.
        /// </returns>
        /// <remarks>Parameter <c>ignoreCase</c> is set to true.</remarks>
        public static bool StrEqual(string source, bool mustMatchAll, params string[] toStrings)
        {
            return StrEqual(source, true, mustMatchAll, toStrings);
        }

        /// <summary>
        /// Compare two string values if they are equal. 
        /// </summary>
        /// <param name="str1">First string value to compare.</param>
        /// <param name="str2">Second string value to compare.</param>
        /// <returns>Returns true if specified string values are equal, of false if not.</returns>
        /// <remarks>Param <c>ignoreCase</c> is set to true.</remarks>
        public static bool StrEqual(string str1, string str2)
        {
            return StrEqual(str1, str2, true);
        }

        public static bool IsVersionEqual(string version1, string version2)
        {
            var v1 = new Version(version1);
            var v2 = new Version(version2);

            return v1.Equals(v2);
        }

        public static bool StrInList(string str, List<string> list, bool ignoreCase)
        {
            int index = list.FindIndex(delegate(string item)
            {
                return StrEqual(item, str, ignoreCase);
            });

            return index > -1;
        }

        public static bool IsAllTrue<T>(IDictionary<T, bool> dictionary)
        {
            int trueCount;
            return IsAllTrue(dictionary, out trueCount);
        }

        public static bool IsAllTrue<T>(IDictionary<T, bool> dictionary, out int trueCount)
        {
            trueCount = 0;

            foreach (var pair in dictionary)
            {
                if (pair.Value)
                {
                    trueCount++;
                }
            }

            return (trueCount == dictionary.Count);
        }

        public static bool IsAllFalse<T>(IDictionary<T, bool> dictionary)
        {
            foreach (var pair in dictionary)
            {
                if (pair.Value)
                {
                    return false;
                }
            }

            return true;
        }

        public static List<T> GetAllFalse<T>(IDictionary<T, bool> dictionary)
        {
            var result = new List<T>();

            foreach (var pair in dictionary)
            {
                if (!pair.Value)
                {
                    result.Add(pair.Key);
                }
            }

            return result;
        }

        public static List<T> GetAllTrue<T>(IDictionary<T, bool> dictionary)
        {
            var result = new List<T>();

            foreach (var pair in dictionary)
            {
                if (pair.Value)
                {
                    result.Add(pair.Key);
                }
            }

            return result;
        }

        public static DateTime ParseDateTime(string dateTime)
        {
            if (StrEqual(dateTime, NA) || StrContain(dateTime, NA))
            {
                return DateTime.MinValue;
            }

            // string format: 27.12.2007 20:55:15
            string[] parts = dateTime.Split(' ');
            string[] dateParts = parts[0].Split('.');
            string[] timeParts = parts[1].Split(':');

            return new DateTime(
                Convert.ToInt32(dateParts[2]), // year
                Convert.ToInt32(dateParts[1]), // month
                Convert.ToInt32(dateParts[0]), // day
                Convert.ToInt32(timeParts[0]), // hour
                Convert.ToInt32(timeParts[1]), // minutes
                Convert.ToInt32(timeParts[2])); // seconds
        }

        public static Color GetStatusColor(bool success)
        {
            return success ? Color.FromKnownColor(KnownColor.ControlText) : Color.Red;
        }

        #region Serialization and deserialization of objects using M$ XmlSerializer

        /// <summary>
        /// Deserialize object from xml, which was serilized by [Serializable] flag.
        /// </summary>
        /// <param name="resultType">Type of the result.</param>
        /// <param name="extraTypes">The extra types.</param>
        /// <param name="xml">XML data.</param>
        /// <returns>Deserialized object.</returns>
        public static object DeserializeObjectFromXml(Type resultType, Type[] extraTypes, string xml)
        {
            if (xml == null || xml.Length == 0)
            {
                return null;
            }

            object result;
            var serializer = new XmlSerializer(resultType, extraTypes);
            TextReader r = new StringReader(xml);
            result = serializer.Deserialize(r);

            return result;
        }

        /// <summary>
        /// Create XML from specified object by serialization.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="extraTypes">The extra types.</param>
        /// <param name="obj">The obj.</param>
        /// <returns>XML data.</returns>
        public static string SerializeObjectToXml(Type objectType, Type[] extraTypes, object obj)
        {
            var sb = new StringBuilder();
            var serializer = new XmlSerializer(objectType, extraTypes);
            TextWriter w = new StringWriter(sb);
            serializer.Serialize(w, obj);
            w.Flush();
            w.Close();

            return sb.ToString();
        }

        #endregion

        #region Debug utility / helpers

        private const string exceptionString =
            @"
{0} {1}
{0} type: {2}
{0} message: {3}
{0} source: {4}
{0} stack trace: {5}
{0} has inner exception: {6}";

        /// <summary>
        /// Write advanced log from specified exception to debug output.
        /// </summary>
        /// <param name="msg">log message.</param>
        /// <param name="e">Exception to log.</param>
        public static void DebugWrite(string msg, Exception e)
        {
#if DEBUG
            DebugWrite("{0}: {1}", msg, GetExceptionStr(e));
#endif
        }

        /// <summary>
        /// Write advanced log from specified exception to debug output.
        /// </summary>
        /// <param name="e">Exception to log.</param>
        public static void DebugWrite(Exception e)
        {
#if DEBUG
            DebugWrite(GetExceptionStr(e));
#endif
        }

        /// <summary>
        /// Write log to debug output.
        /// </summary>
        /// <param name="msg">Log message.</param>
        public static void DebugWrite(string msg)
        {
#if DEBUG
            DebugWrite(msg, new object[] {null});
#endif
        }

        /// <summary>
        /// Write log to debug output.
        /// </summary>
        /// <param name="msg">Log message.</param>
        /// <param name="pars">Parameters used to format log message.</param>
        public static void DebugWrite(string msg, params object[] pars)
        {
#if DEBUG
            if ((pars != null) || (pars.Length > 0))
            {
                Debug.WriteLine(string.Format(msg, pars));
            }
            else
            {
                Debug.WriteLine(msg);
            }
#endif
        }

        /// <summary>
        /// Returns exception string with stacktrace.
        /// </summary>
        /// <param name="e">Exception.</param>
        /// <param name="loopInnerExceptions">if set to <c>true</c> [loop inner exceptions].</param>
        /// <returns>Exception string.</returns>
        public static string GetExceptionStr(Exception e, bool loopInnerExceptions)
        {
            try
            {
                var sb = new StringBuilder();
                int deep = 1;
                Exception innerEx = AppendEx(sb, "Exception was handled", deep, e);

                while (innerEx != null)
                {
                    deep++;
                    innerEx = AppendEx(sb, string.Format("Inner exception(deep: {0})", deep - 1), deep, innerEx);
                }

                return sb.ToString();
            }
            catch (Exception e1)
            {
                DebugWrite("Exception in GetExceptionStr, {0}", e1.Message);
                return string.Empty;
            }

            #region old

            //            string inner = string.Empty;
            //            if (e.InnerException != null)
            //            {
            //                try
            //                {
            //                    inner = string.Format("Inner exc. message: {0}, source: {1}, stacktrace: {2}",
            //                                          e.InnerException.Message, e.InnerException.Source, e.InnerException.StackTrace);
            //                }
            //                catch
            //                {
            //                }
            //            }
            //
            //            return string.Format("Exception type: {0}, message: {1}, stacktrace: {2}, inner: {3}",
            //                                 e.GetType().FullName, e.Message, e.StackTrace, inner);

            #endregion
        }

        /// <summary>
        /// Returns exception string with stacktrace.
        /// </summary>
        /// <param name="e">Exception.</param>
        /// <returns>Exception string.</returns>
        public static string GetExceptionStr(Exception e)
        {
            return GetExceptionStr(e, true);
        }

        private static Exception AppendEx(StringBuilder sb, string firstLine, int deep, Exception e)
        {
            sb.AppendFormat(exceptionString,
                new string('-', deep),
                firstLine,
                e.GetType().FullName,
                e.Message,
                e.Source,
                e.StackTrace,
                e.InnerException != null ? "yes" : "no");

            return e.InnerException;
        }

        #endregion

        public static string ExtractResourceFile(string resourceFileName)
        {
            string result = string.Empty;

            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                Stream stream = assembly.GetManifestResourceStream(resourceFileName);
                if (stream != null)
                {
                    using (stream)
                    {
                        StreamReader sr = new StreamReader(stream);
                        result = sr.ReadToEnd();
                        sr.Close();
                    }

                    break;
                }
            }

            return result;
        }

        public static void RecursiveFolderDelete(string folder)
        {
            if (!Directory.Exists(folder))
            {
                return;
            }

            foreach (var fileInfo in new DirectoryInfo(folder).GetFiles())
            {
                fileInfo.Delete();
            }

            Directory.Delete(folder);
        }
    }

    public delegate void MethodInvokerExt<T>(T argument);
}