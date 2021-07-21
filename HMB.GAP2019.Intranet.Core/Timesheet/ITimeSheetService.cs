using System;
using System.Collections.Generic;
using System.Text;

namespace HMB.GAP2019.Intranet.Core.Timesheet
{
    public interface ITimeSheetService
    {
        bool SubmitTimeSheet(TimeSheet timeSheet);

        Dictionary<String, IEnumerable<String>> ValidateTimeSheet(TimeSheet timeSheet);

        TimeSheet GetTimeSheet(DateTime dateInWeek);

        bool DeleteTimeSheet(DateTime dateInWeek);
    }
}
