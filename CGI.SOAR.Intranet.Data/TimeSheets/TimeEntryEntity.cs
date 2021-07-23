using System;
using System.ComponentModel.DataAnnotations;
using CGI.SOAR.Intranet.Core.Authentication;
using CGI.SOAR.Intranet.Core.TimesSheets;

namespace CGI.SOAR.Intranet.Data.TimeSheets
{
    public class TimeEntryEntity
    {
        public int Id { get; set; }

        [Required]
        public Employee AssignedEmployee { get; set; }

        [Required]
        public Task AssignedTask { get; set; }

        public DateTime MondayOfWeek { get; set; }

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