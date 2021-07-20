using System;
using System.ComponentModel.DataAnnotations;

namespace HMB.GAP2019.Intranet.Core.Announcements
{
    public class Announcement
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsHighPriority { get; set; }

        [Required, StringLength(500)]
        public string Title { get; set; }

        [Required]
        public string Body { get; set; }
    }
}