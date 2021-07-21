using HMB.GAP2019.Intranet.Core.ModelValidation;
using HMB.GAP2019.Intranet.Core.Timesheet;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace HMB.GAP2019.Intranet.Core.Authentication
{
    public class EmployeeAuthenticationService : IEmployeeAuthenticationService
    {
        private readonly ILogger<EmployeeAuthenticationService> _logger;
        private readonly IEmployeeAuthenticationService _authenticationService;
        private readonly IModelValidationService _validator;
        private readonly IEmployeeRepository _repo;

        //public EmployeeAuthenticationService(IEmployeeRepository repo, ILogger<TimeSheetService> logger, IEmployeeAuthenticationService authenticationService, IModelValidationService validationService)
        //{
        //    _logger = logger;
        //    _authenticationService = authenticationService;
        //    _validator = validationService;
        //    _repo = repo;
        //}


        public Employee GetLoggedInEmployee()
        {
            throw new NotImplementedException();
        }
    }
}
