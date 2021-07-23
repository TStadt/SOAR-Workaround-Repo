using System.ComponentModel.DataAnnotations;

namespace CGI.SOAR.Intranet.Core.TimesSheets
{
    public class Task
    {
        public int Id { get; set; }

        [Required, StringLength(300)]
        public string Name { get; set; }

        public bool IsNoteRequired { get; set; }
    }
}