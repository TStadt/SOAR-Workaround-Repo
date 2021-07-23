using System;
using System.Collections.Generic;

namespace CGI.SOAR.Intranet.Core.TimesSheets
{
    public interface ITimeSheetService
    {
        TimeSheet GetTimeSheet(DateTime dateInWeek);
        bool SubmitTimeSheet(TimeSheet timeSheet);
        Dictionary<string, IEnumerable<string>> ValidateTimeSheet(TimeSheet timeSheet);
    }
}