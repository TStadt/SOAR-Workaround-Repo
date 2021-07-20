using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HMB.GAP2019.Intranet.Core.Timesheet
{
    public class TimeEntry
    {
        [Required]
        public Task Task { get; set; }

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
