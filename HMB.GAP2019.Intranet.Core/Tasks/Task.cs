using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HMB.GAP2019.Intranet.Core.Tasks
{
    public class Task
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(300)]
        public string Name { get; set; }

        public bool IsNoteRequired { get; set; }

        

    }
}
