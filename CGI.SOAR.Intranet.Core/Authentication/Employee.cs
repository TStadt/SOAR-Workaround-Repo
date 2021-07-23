using System.ComponentModel.DataAnnotations;

namespace CGI.SOAR.Intranet.Core.Authentication
{
    public class Employee
    {
        public int Id { get; set; }

        [Required, StringLength(300)]
        public string Email { get; set; }

        [Required, StringLength(100)]
        public string FirstName { get; set; }

        [Required, StringLength(100)]
        public string LastName { get; set; }

    }
}
