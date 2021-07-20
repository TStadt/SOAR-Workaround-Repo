using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HMB.GAP2019.Intranet.Core.Authentication;
using HMB.GAP2019.Intranet.Core.TimeEntry;

namespace HMB.GAP2019.Intranet.Core.TimeSheets
{
    public class TimeSheet
    {

        public int Id { get; set; }

        [Required]
        public DateTime dateTime { get; set; }

        [Required]
        public Authentication.Employee employee { get; set; }

        public List<TimeEntry.TimeEntry> timeEntries { get; set; }


    }
}