using System;

namespace LinkerPad.Common
{
    public enum PersianCalendarFormat
    {
        ShortDateTime = 1,
        LongDateTime = 2,
        LongDate = 3,
        ShortDate = 4,
        ShortDayMonth = 5
    }

    public enum MiladiCalendarFormat
    {
        LongDateTime = 1,
        ShortDayMonth = 2
    }

    public class DateConvertor
    {
        public static string ShamsiDate(DateTime? date, PersianCalendarFormat persianCalendarFormat)
        {
            DateTime dt = Convert.ToDateTime(date);
            System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();

            switch (persianCalendarFormat)
            {
                case PersianCalendarFormat.ShortDateTime:
                    string farsiDate = $"{pc.GetYear(dt)}/{pc.GetMonth(dt)}/{pc.GetDayOfMonth(dt)}";
                    return farsiDate + " - " + dt.TimeOfDay.ToString().Substring(0, 5);

                case PersianCalendarFormat.LongDate:
                    return $"{pc.GetDayOfMonth(dt)} {GetMonthName(pc.GetMonth(dt))} {pc.GetYear(dt)}";

                case PersianCalendarFormat.LongDateTime:
                    return $"{pc.GetDayOfMonth(dt)} {GetMonthName(pc.GetMonth(dt))} {pc.GetYear(dt)} - {dt.TimeOfDay.ToString().Substring(0, 5)}";

                case PersianCalendarFormat.ShortDate:
                    return $"{ pc.GetYear(dt)}/{ pc.GetMonth(dt)}/{ pc.GetDayOfMonth(dt)}";

                case PersianCalendarFormat.ShortDayMonth:
                    return $"{pc.GetMonth(dt)}/{ pc.GetDayOfMonth(dt)}";

                default:
                    return String.Empty;
            }
        }

        public static DateTime MiladiDate(string date)
        {
            string[] datePicker = date.Split('-');
            string[] datePart = datePicker[0].Split('/');
            string[] timePart = datePicker[1].Split(':');
            System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
            DateTime dt = pc.ToDateTime(Convert.ToInt32(datePart[0]), Convert.ToInt32(datePart[1]), Convert.ToInt32(datePart[2]), Convert.ToInt32(timePart[0]), Convert.ToInt32(timePart[1]), 0, 0);
            return dt;
        }

        public static string MiladiDateTime(DateTime dateTime, MiladiCalendarFormat miladiCalendarFormat)
        {
            switch (miladiCalendarFormat)
            {
                case MiladiCalendarFormat.LongDateTime:
                    return $"{dateTime.Day} {GetMiladiMonthName(dateTime.Month)} {dateTime.Year} - {dateTime.TimeOfDay.ToString().Substring(0, 5)}";

                case MiladiCalendarFormat.ShortDayMonth:
                    return $"{dateTime.Day} {GetMiladiMonthName(dateTime.Month)} {dateTime.Year} - {dateTime.TimeOfDay.ToString().Substring(0, 5)}";
                default:
                    return string.Empty;
            }
        }

        private static string GetMonthName(int month)
        {
            switch (month)
            {
                case 1:
                    return "فروردین";
                case 2:
                    return "اردیبهشت";
                case 3:
                    return "خرداد";
                case 4:
                    return "تیر";
                case 5:
                    return "مرداد";
                case 6:
                    return "شهریور";
                case 7:
                    return "مهر";
                case 8:
                    return "آبان";
                case 9:
                    return "آذر";
                case 10:
                    return "دی";
                case 11:
                    return "بهمن";
                case 12:
                    return "اسفند";
                default:
                    return "Invalid Month";
            }
        }

        private static string GetMiladiMonthName(int month)
        {
            switch (month)
            {
                case 1:
                    return "January";
                case 2:
                    return "Februrary";
                case 3:
                    return "March";
                case 4:
                    return "April";
                case 5:
                    return "May";
                case 6:
                    return "June";
                case 7:
                    return "July";
                case 8:
                    return "August";
                case 9:
                    return "September";
                case 10:
                    return "October";
                case 11:
                    return "November";
                case 12:
                    return "December";
                default:
                    return "Invalid Month";
            }
        }
    }
}
