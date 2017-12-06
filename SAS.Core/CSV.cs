using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace SAS.Core
{
    public static class CSV
    {
        public static string[] Split(string input)
        {
            try
            {
                Regex csvSplit = new Regex("(?:^|,)(\"(?:[^\"]+|\"\")*\"|[^,]*)", RegexOptions.Compiled);
                List<string> list = new List<string>();
                string curr = null;
                foreach (Match match in csvSplit.Matches(input))
                {
                    curr = match.Value;
                    if (0 == curr.Length)
                    {
                        list.Add("");
                    }

                    list.Add(curr.TrimStart(',').Replace("\"", "").Trim());
                }

                return list.ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception("Csv Split failed", ex);
            }
        }

        public static string ToString(string value)
        {
            return value;
        }

        public static DateTime? ToDateTime(string value)
        {
            try
            {
                if (string.IsNullOrEmpty(value))
                    return null;


                DateTime result;

                if (DateTime.TryParseExact(value, "yyyy-MM-ddTHH:mm:ss.fff", CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
                    return result;

                if (DateTime.TryParseExact(value, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
                    return result;

                if (DateTime.TryParseExact(value, "yyyyMMdd-HH:mm:ss.fff", CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
                    return result;

                if (DateTime.TryParseExact(value, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
                    return result;

                if (DateTime.TryParseExact(value, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
                    return result;
                return result;
            }
            catch (Exception ex)
            {
                throw new InvalidCastException("ToDateTime conversion failed", ex);
            }
        }

        public static int? ToInt(string value)
        {
            try
            {
                if (string.IsNullOrEmpty(value))
                    return null;
                else
                    return Convert.ToInt32(value);
            }
            catch (Exception ex)
            {
                throw new InvalidCastException("ToInt conversion failed", ex);
            }
        }

        public static long? ToLong(string value)
        {
            try
            {
                if (string.IsNullOrEmpty(value))
                    return null;
                else
                    return Convert.ToInt64(value);
            }
            catch (Exception ex)
            {
                throw new InvalidCastException("ToLong conversion failed", ex);
            }
        }

        public static double? ToDouble(string value)
        {
            try
            {
                if (string.IsNullOrEmpty(value))
                    return null;
                else
                    return Convert.ToDouble(value);
            }
            catch (Exception ex)
            {
                throw new InvalidCastException("ToDouble conversion failed", ex);
            }
        }

        public static bool ToBool(string value)
        {
            try
            {
                string temp = value.ToUpper();
                bool result = false;
                switch (temp)
                {
                    case "": result = false; break;
                    case "N": result = false; break;
                    case "0": result = false; break;
                    case "F": result = false; break;
                    case "FALSE": result = false; break;

                    case "Y": result = true; break;
                    case "1": result = true; break;
                    case "T": result = true; break;
                    case "TRUE": result = true; break;
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new InvalidCastException("ToBool conversion failed", ex);
            }
        }
    }
}
