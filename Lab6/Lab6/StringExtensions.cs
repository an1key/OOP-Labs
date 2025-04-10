using System;
using System.Text.RegularExpressions;

namespace Lab6
{
    public static class StringExtensions
    {
        public static string RemoveRussianLetters(this string input)
        {
            return Regex.Replace(input, @"[А-Яа-я]", "");
        }
    }
}