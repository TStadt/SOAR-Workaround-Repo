using HMB.GAP2019.Intranet.Core.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HMB.GAP2019.Intranet.Core.Timesheet
{
    public class TimeSheet
    {

        public IEnumerable<TimeEntry> Entries { get; set; }

        public Employee Employee { get; set; }

        public DateTime MondayOfWeek { get; set; }

    }
}
