using System;
using System.Linq;
using HMB.GAP2019.Intranet.Core.Authentication;
using HMB.GAP2019.Intranet.Data.Contexts;

namespace HMB.GAP2019.Intranet.Data.Authentication
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
