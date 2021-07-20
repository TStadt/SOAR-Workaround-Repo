using System;
using System.ComponentModel.DataAnnotations;
using HMB.GAP2019.Intranet.Core.Tasks;

namespace HMB.GAP2019.Intranet.Core.TimeEntry
{
    public class TimeEntry
    {

        public int Id { get; set; }

        public int Day { get; set; }

        [Required]
        public Tasks.TaskEntry task { get; set; }

        [StringLength(1000)]
        public string Note { get; set; }

    }
}