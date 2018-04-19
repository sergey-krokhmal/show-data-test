using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib.Extensions
{
    public static class DateTimeExtension
    {
        public static string DateFormat { get { return "dd.MM.yyyy HH:mm:ss"; } }

        public static DateTime ToUtcDateTime(this string dateTime)
        {
            DateTime date;
            if (!DateTime.TryParseExact(dateTime, DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out date))
            {
                throw new FormatException($"Wrong date format (needs {DateFormat})");
            }
            return date.ToUniversalTime();
        }
    }
}
