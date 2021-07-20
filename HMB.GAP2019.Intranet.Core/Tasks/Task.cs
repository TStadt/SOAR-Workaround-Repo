using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HMB.GAP2019.Intranet.Core.TimeEntry;

namespace HMB.GAP2019.Intranet.Core.Tasks
{
    public class Task
    {
        public int Id { get; set; }

        [Required, StringLength(300)]
        public string Name { get; set; }

        public List<TimeEntry.TimeEntry> timeEntries  { get; set; }


        public bool RequiresNote { get; set; } 

    }
}
