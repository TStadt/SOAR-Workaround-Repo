using System.ComponentModel.DataAnnotations;

namespace CGI.SOAR.Intranet.Core.TimesSheets
{
    public class TimeEntry
    {
        [Required]
        public Task AssignedTask { get; set; }

        public double Monday { get; set; }
        public double Tuesday { get; set; }
        public double Wednesday { get; set; }
        public double Thursday { get; set; }
        public double Friday { get; set; }
        public double Saturday { get; set; }
        public double Sunday { get; set; }

        [StringLength(1000)]
        public string Note { get; set; }
    }
}