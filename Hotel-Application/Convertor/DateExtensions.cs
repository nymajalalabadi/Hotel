using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Application.Convertor
{
    public static class DateExtensions
    {
        public static string ToShamsi(this DateTime date)
        {
            PersianCalendar pc = new PersianCalendar();

            int year = pc.GetYear(date);
            int month = pc.GetMonth(date);
            int day = pc.GetDayOfMonth(date);

            return $"{year}/{month.ToString("00")}/{day.ToString("00")}";
        }

        public static DateTime ToMiladiDate(this string date)
        {
            var splitedDate = date.Split('/');

            int year = int.Parse(splitedDate[0]);
            int month = int.Parse(splitedDate[1]);
            int day = int.Parse(splitedDate[2]);

            DateTime thisDate = new DateTime(year, month, day, new PersianCalendar());

            return thisDate;
        }
    }
}
