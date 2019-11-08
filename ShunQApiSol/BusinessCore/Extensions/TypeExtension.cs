using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

namespace BusinessCore.Extensions
{
    public static class TypeExtension
    {

        public static DateTime TrimTime(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day);
        }

        public static DateTime? TrimTime(this DateTime? date)
        {
            if (!date.HasValue)
                return date;

            return new DateTime(date.Value.Year, date.Value.Month, date.Value.Day);
        }

        public static DateTime? ToSqlDate(this DateTime? date)
        {
            if (!date.HasValue)
                return date;

            //is valid date
            return date.Value.Year >= 2010 ? date : null;
        }

        public static DateTime ToSqlDate(this DateTime date)
        {
            //is valid date
            return date.Year >= 2010 ? date : new DateTime(2010, 1, 1);
        }

        public static bool IsEmpty(this string str)
        {
            if (str == null)
                return true;

            return str.Trim().Length == 0;
        }

        public static string TrimAll(this string str)
        {
            if (str == null)
                return string.Empty;

            return str.Trim();
        }

        public static string ToAlphaNum(this string str)
        {
            if (str == null)
                return string.Empty;

            str = Regex.Replace(str, "[^a-zA-Z0-9]", "");

            return str.Trim();
        }

        public const string NAME_VALID_PATTERN = @"[a-zA-Z0-9@_. \-]";
        public static bool ValidChars(this string str)
        {
            if (str == null)
                return false;

            str = str.Trim();

            if (str.Length == 0)
                return false;

            return new Regex(@"^" + NAME_VALID_PATTERN + "+$").IsMatch(str);
        }

        /// <summary>
        /// Valid Chars A-Z0-9-_@space
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Sanitize(this string str)
        {
            if (str == null)
                return string.Empty;

            str = str.Trim();

            const string charstr = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_@ ";
            var validChars = charstr.ToCharArray();
            var newStr = string.Empty;
            for (int i = 0; i < str.Length; i++)
            {
                if (validChars.Contains(str[i]))
                    newStr += str[i];
            }
            return newStr;
        }


        public static bool IsEmail(this string str)
        {
            if (str == null)
                return false;

            return new System.ComponentModel.DataAnnotations.EmailAddressAttribute().IsValid(str);
        }
        public static bool IsNumber(this string str)
        {
            if (str == null)
                return false;

            if (str.Length == 0)
                return false;

            var isNumber = true;
            var chars = str.ToCharArray();
            for (var i = 0; i < chars.Length; i++)
            {
                if (!char.IsDigit(chars[i]))
                {
                    isNumber = false;
                    break;
                }
            }

            return isNumber;
        }

        public static bool IsMobileNumber(this string str)
        {
            if (str == null)
                return false;

            if (str.Trim().Length==0)
                return false;

            if (str.Length < 10)
                return false;

            var chars = str.ToCharArray();

            var isNumber = true;
            for (var i = 0; i < chars.Length; i++)
            {
                //if (chars[i] == '-' || chars[i] == ' ' || chars[i] == '(' || chars[i] == ')')//valid chars for phone number
                //    continue;

                if (!char.IsDigit(chars[i]))
                {
                    isNumber = false;
                    break;
                }
            }

            return isNumber;
        }

        public static string TimeAgo(this DateTime dt)
        {
            TimeSpan span = DateTime.Now - dt;
            if (span.Days > 365)
            {
                int years = (span.Days / 365);
                if (span.Days % 365 != 0)
                    years += 1;
                return String.Format("about {0} {1} ago",
                years, years == 1 ? "year" : "years");
            }
            if (span.Days > 30)
            {
                int months = (span.Days / 30);
                if (span.Days % 31 != 0)
                    months += 1;
                return String.Format("about {0} {1} ago",
                months, months == 1 ? "month" : "months");
            }
            if (span.Days > 0)
                return String.Format("about {0} {1} ago",
                span.Days, span.Days == 1 ? "day" : "days");
            if (span.Hours > 0)
                return String.Format("about {0} {1} ago",
                span.Hours, span.Hours == 1 ? "hour" : "hours");
            if (span.Minutes > 0)
                return String.Format("about {0} {1} ago",
                span.Minutes, span.Minutes == 1 ? "minute" : "minutes");
            if (span.Seconds > 5)
                return String.Format("about {0} seconds ago", span.Seconds);
            if (span.Seconds <= 5)
                return "just now";
            return string.Empty;
        }
    }
}
