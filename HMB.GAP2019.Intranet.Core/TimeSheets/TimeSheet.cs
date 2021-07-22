using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HMB.GAP2019.Intranet.Core.Authentication;
using HMB.GAP2019.Intranet.Core.TimeEntries;

namespace HMB.GAP2019.Intranet.Core.TimeSheets
{
    public class TimeSheet
    {

        public int Id { get; set; }

        [Required]
        public DateTime Week { get; set; }

        [Required]
        public Authentication.Employee Employee { get; set; }

        public List<TimeEntry> TimeEntries { get; set; }


    }
}