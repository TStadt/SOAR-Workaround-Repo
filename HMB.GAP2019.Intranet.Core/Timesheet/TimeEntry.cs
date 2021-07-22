using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HMB.GAP2019.Intranet.Core.Timesheet
{
    public class TimeEntry
    {
        public int Id { get; set; }

        [Required]
        public Core.Tasks.Task Task { get; set; }

        public double Monday { get; set; }
        public double Tuesday { get; set; }
        public double Wednesday { get; set; }
        public double Thursday { get; set; }
        public double Friday { get; set; }
        public double Saturday { get; set; }
        public double Sunday { get; set; }

        [MaxLength(1000)]
        public string Note { get; set; }


    }
}
