using System;
using System.Linq;

namespace CGI.SOAR.Intranet.Core.TimesSheets
{
    internal static class TimeSheetExtensions
    {
        public static double[] Days(this TimeEntry entry)
            => new[]
            {
                entry.Monday,
                entry.Tuesday,
                entry.Wednesday,
                entry.Thursday,
                entry.Friday,
                entry.Saturday,
                entry.Sunday
            };

        public static double TotalFor(this TimeSheet timeSheet, Func<TimeEntry, double> selector)
            => timeSheet.Entries.Any() ? timeSheet.Entries.Sum(selector) : 0;

        public static double TotalForWeek(this TimeSheet timeSheet)
            => timeSheet.Entries.Any() ? timeSheet.TotalFor(te => te.Days().DefaultIfEmpty(0).Sum()) : 0;
    }
}
