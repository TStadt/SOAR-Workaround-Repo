using HMB.GAP2019.Intranet.Core.Announcements;
using HMB.GAP2019.Intranet.Core.Authentication;
using HMB.GAP2019.Intranet.Core.ModelValidation;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace HMB.GAP2019.Intranet.Core.Timesheet
{
    public class TimeSheetService : ITimeSheetService
    {
        private readonly ILogger<TimeSheetService> _logger;
        private readonly IEmployeeAuthenticationService _authenticationService;
        private readonly IModelValidationService _validator;

        public TimeSheetService(ILogger<TimeSheetService> logger, IEmployeeAuthenticationService authenticationService, IModelValidationService validationService)
        {
            _logger = logger;
            _authenticationService = authenticationService;
            _validator = validationService;
        }
        public TimeSheet GetTimeSheet(DateTime dateInWeek)
        {
            var placeholder = new TimeSheet();

            var currentEmp = _authenticationService.GetLoggedInEmployee();
            if (currentEmp == null)
            {
                _logger.LogError("No User logged in");
                return null;
            }



            return placeholder;
        }

        public bool SubmitTimeSheet(TimeSheet timeSheet)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, IEnumerable<string>> ValidateTimeSheet(TimeSheet timeSheet)
        {
            var placeholder = new Dictionary<String, IEnumerable<String>>();
            
            foreach(var entry in timeSheet.Entries)
            {
                
            }



            return placeholder;
        }
    }
}
