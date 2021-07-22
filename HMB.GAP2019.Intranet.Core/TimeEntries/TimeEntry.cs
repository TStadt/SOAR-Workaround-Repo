using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HMB.GAP2019.Intranet.Core.Tasks;

namespace HMB.GAP2019.Intranet.Core.TimeEntries
{
    public class TimeEntry
    {
        
        public int Id { get; set; }

        public double Sunday { get; set; }
        public double Monday { get; set; }
        public double Tuesday { get; set; }
        public double Wednesday { get; set; }
        public double Thursday { get; set; }
        public double Friday { get; set; }
        public double Saturday { get; set; }


        [Required]
        public TaskEntry Task { get; set; }

        [StringLength(1000)]
        public string Note { get; set; }

    }
}