using System.Runtime.InteropServices;

namespace WorkFlowSystem.Web.Extensions
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Czas w strefie Warszawa
        /// </summary>
        /// <param name="utcDate"></param>
        /// <returns></returns>
        public static DateTime ToWarsawTime(this DateTime utcDate)
        {
            var timeZone = TimeZoneInfo.FindSystemTimeZoneById(
                RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
                    ? "Central European Standard Time"
                    : "Europe/Warsaw");

            return TimeZoneInfo.ConvertTimeFromUtc(
                DateTime.SpecifyKind(utcDate, DateTimeKind.Utc),
                timeZone);
        }

        public static string ToWarsawString(
            this DateTime utcDate,
            string format = "yyyy-MM-dd HH:mm")
        {
            return utcDate
                .ToWarsawTime()
                .ToString(format);
        }
    }
}
