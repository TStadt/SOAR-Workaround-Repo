using CGI.SOAR.Intranet.Core.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CGI.SOAR.Intranet.Infrastructure.Authentication
{
    public class InMemoryEmployeeRepository : IEmployeeRepository
    {
        private static readonly List<Employee> _employees;

        static InMemoryEmployeeRepository()
        {
            _employees = new List<Employee>
            {
                new Employee { Id = 1, Email = "alice.jones.admin@cgi.com", FirstName = "Alice", LastName = "Jones" },
                new Employee { Id = 2, Email = "john.smith.employee@cgi.com", FirstName = "John", LastName = "Smith" },
                new Employee { Id = 3, Email = "pamela.rogers.pm@cgi.com", FirstName = "Pamela", LastName = "Rogers" },
                new Employee { Id = 4, Email = "carter.cruz.hr@cgi.com", FirstName = "Carter", LastName = "Cruz" }
            };
        }

        public Employee GetEmployeeByEmail(string email)
        {
            var employee = _employees.SingleOrDefault(e => e.Email.Equals(email, StringComparison.OrdinalIgnoreCase));

            return employee;
        }
    }
}
