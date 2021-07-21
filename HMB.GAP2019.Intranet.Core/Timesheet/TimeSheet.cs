using HMB.GAP2019.Intranet.Core.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HMB.GAP2019.Intranet.Core.Timesheet
{
    public class TimeSheet
    {

        public int Id { get; set; }

        public IEnumerable<TimeEntry> Entries { get; set; }

        public Employee Employee { get; set; }

        public DateTime MondayOfWeek { get; set; }

    }
}
