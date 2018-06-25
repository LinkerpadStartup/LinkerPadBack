using System;

namespace LinkerPad.Common
{
    public static class StringExtension
    {
        public static string SubStringAtWrodEnd(string text, int length)
        {
            if (string.IsNullOrWhiteSpace(text))
                return string.Empty;

            if (length >= text.Length)
            {
                return text;
            }

            int whitespaceIndex = text.LastIndexOf(" ", length, StringComparison.Ordinal);
            return text.Substring(0, whitespaceIndex > 0 ? whitespaceIndex : length).TrimEnd() + "...";
        }

        public static string ToPersianNumber(this string input)
        {
            if (input.Trim() == "") return "";

            input = input.Replace("0", "۰");
            input = input.Replace("1", "۱");
            input = input.Replace("2", "۲");
            input = input.Replace("3", "۳");
            input = input.Replace("4", "۴");
            input = input.Replace("5", "۵");
            input = input.Replace("6", "۶");
            input = input.Replace("7", "۷");
            input = input.Replace("8", "۸");
            input = input.Replace("9", "۹");
            return input;
        }
    }
}
