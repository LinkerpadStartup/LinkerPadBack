using System;

namespace LinkerPad.Common
{
    public class PersianDateConvertor
    {
        public static DateTime FirstDateOfYear(int year)
        {
            return new PersianDateTime(year, 1, 1).ToDateTime();
        }

        public static DateTime LastDaTeOfYear(int year)
        {
            return new PersianDateTime(year, 1, 1).AddMonths(12).AddDays(-1).ToDateTime();
        }

        public static DateTime FirstDateOfMonth(int year, int month)
        {
            return new PersianDateTime(year, month, 1).ToDateTime();
        }

        public static DateTime LastDateOfMonth(int year, int month)
        {
            return new PersianDateTime(year, month, 1).AddMonths(1).AddDays(-1).ToDateTime();
        }

        public static DateTime GetDate(int year, int month, int day, int hour)
        {
            return new PersianDateTime(year, month, day, hour, 0, 0).ToDateTime();
        }

        public static string PersianMonthName(int year, int month)
        {
            return new PersianDateTime(new DateTime(year, month, 1)).MonthName;
        }

        public static string NameOfMounthWithDay(int year, int mounth, int day)
        {
            DateTime date = new DateTime(year, mounth, day);
            PersianDateTime mounthname = new PersianDateTime(date);
            return mounthname.Day + " " + mounthname.MonthName;
        }
    }
}