using System;
using System.Linq;
using CGI.SOAR.Intranet.Core.Authentication;
using CGI.SOAR.Intranet.Data.Contexts;

namespace CGI.SOAR.Intranet.Data.Authentication
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IntranetContext _context;

        public EmployeeRepository(IntranetContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Employee GetEmployeeByEmail(string email)
            => _context.Employees.SingleOrDefault(e => e.Email == email);
    }
}
