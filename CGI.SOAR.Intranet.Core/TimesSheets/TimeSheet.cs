using System;
using System.Collections.Generic;
using CGI.SOAR.Intranet.Core.Authentication;

namespace CGI.SOAR.Intranet.Core.TimesSheets
{
    public class TimeSheet
    {
        public Employee Employee { get; set; }
        public DateTime MondayOfWeek { get; set; }
        public IEnumerable<TimeEntry> Entries { get; set; }
    }
}
