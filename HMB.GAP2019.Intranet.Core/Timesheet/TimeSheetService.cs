using HMB.GAP2019.Intranet.Core.Announcements;
using HMB.GAP2019.Intranet.Core.Authentication;
using HMB.GAP2019.Intranet.Core.ModelValidation;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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

        public bool DeleteTimeSheet(DateTime dateInWeek)
        {
            var result = GetTimeSheet(dateInWeek);
            if (result != null)
            {
                _repo.Delete(result.Id);
                try
                {
                    _repo.Commit();
                }
                catch (Exception e)
                {
                    _logger.LogError("Error deleting changes: " + e);
                    return false;
                }
                return true;
            }
            return false;
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
            var result = _repo.GetById(timeSheet.Id);
            if (result == null)
            {
                _repo.Add(timeSheet);
            }
            else
            {
                _repo.Update(timeSheet);
            }
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
                IList <ValidationResult> list  = new List<ValidationResult>();
                _validator.TryValidateModel(entry, out list);
                placeholder.Add(entry.Task.Name, list.Select(l => l.ToString()));

            }
            var totalHours = timeSheet.Entries.Sum(e => e.Monday + e.Tuesday + e.Wednesday + e.Thursday + e.Friday + e.Saturday + e.Sunday);
            if (totalHours > 50)
            {
                placeholder.Add("Exceed Hours", new List<String> { "The total number of hours needs to be <= 50" });
            }
            var totalMonday = timeSheet.Entries.Sum(e => e.Monday);
            return placeholder;
        }
    }
}
