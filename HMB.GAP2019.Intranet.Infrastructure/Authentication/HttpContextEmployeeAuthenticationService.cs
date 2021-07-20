using HMB.GAP2019.Intranet.Core.Authentication;
using Microsoft.Extensions.Logging;

namespace HMB.GAP2019.Intranet.Infrastructure.Authentication
{
    public class HttpContextEmployeeAuthenticationService : IEmployeeAuthenticationService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<HttpContextEmployeeAuthenticationService> _logger;

        public HttpContextEmployeeAuthenticationService(IEmployeeRepository employeeRepository, ILogger<HttpContextEmployeeAuthenticationService> logger)
        {
            _employeeRepository = employeeRepository;
            _logger = logger;
        }

        public Employee GetLoggedInEmployee()
        {
            var email = "alice.jones.admin@hmbnet.com";
            var employee = _employeeRepository.GetEmployeeByEmail(email);

            return employee;
        }
    }
}
