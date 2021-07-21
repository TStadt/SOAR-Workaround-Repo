using System;
using System.Collections.Generic;
using System.Text;

namespace HMB.GAP2019.Intranet.Core.TimeSheets
{
    interface ITimeSheetService
    {
        bool CreateTimeSheet(TimeSheet timeSheet);
        bool UpdateTimeSheet(TimeSheet timeSheet);
        bool RemoveTimeSheet(int id);
        bool ValidateTimeSheet(TimeSheet timeSheet);
        TimeSheet GetTimeSheet(DateTime dateTime);
    }
}
