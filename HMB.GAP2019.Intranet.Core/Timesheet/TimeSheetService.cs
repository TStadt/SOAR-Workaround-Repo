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
        private readonly ITimeSheetRepository _repo;

        public TimeSheetService(ITimeSheetRepository repo, ILogger<TimeSheetService> logger, IEmployeeAuthenticationService authenticationService, IModelValidationService validationService)
        {
            _logger = logger;
            _authenticationService = authenticationService;
            _validator = validationService;
            _repo = repo;
        }
        public TimeSheet GetTimeSheet(DateTime dateInWeek)
        {
            
            var currentEmp = _authenticationService.GetLoggedInEmployee();
            if (currentEmp == null)
            {
                _logger.LogError("No User logged in");
                return null;
            }
            var currentTimeSheet = _repo.GetByEmployee(currentEmp.Id, dateInWeek);
            


            return currentTimeSheet;
        }

        public bool SubmitTimeSheet(TimeSheet timeSheet)
        {
            _repo.Add(timeSheet);
            try {
                _repo.Commit();
            }
            catch(Exception e)
            {
                _logger.LogError("Error submiting changes: " + e);
                return false;
            }
            return true;
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
