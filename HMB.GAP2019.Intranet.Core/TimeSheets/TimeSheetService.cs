using HMB.GAP2019.Intranet.Core.Authentication;
using HMB.GAP2019.Intranet.Core.ModelValidation;
using HMB.GAP2019.Intranet.Core.TimeEntries;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace HMB.GAP2019.Intranet.Core.TimeSheets
{
    public class TimeSheetService : ITimeSheetService
    {
        private readonly ITimeSheetRepository _timeSheetRepository;
        private readonly IEmployeeAuthenticationService _authenticationService;
        private readonly IModelValidationService _validator;
        private readonly ILogger<TimeSheetService> _logger;

        public TimeSheetService(ITimeSheetRepository timeSheetRepository, IEmployeeAuthenticationService authenticationService, IModelValidationService validator,  ILogger<TimeSheetService> logger)
        {
            _timeSheetRepository = timeSheetRepository;
            _authenticationService = authenticationService;
            _validator = validator;
            _logger = logger;
        }


        public bool CreateTimeSheet(TimeSheet timeSheet)
        {
            var employee = _authenticationService.GetLoggedInEmployee();
            if (employee == null)
            {
                _logger.LogError("Could not add time sheet. There was no requesting employee.");
                return false;
            }

            if (!_validator.TryValidateModel(timeSheet, out var validationErrors))
            {
                _logger.LogError($"Tried to add invalid time sheet. {timeSheet}. Errors are {@validationErrors}", timeSheet, validationErrors);

                return false;
            }


            _timeSheetRepository.Add(timeSheet);
            _timeSheetRepository.Commit();

            return true;
        }

        public bool RemoveTimeSheet(int id)
        {
            var employee = _authenticationService.GetLoggedInEmployee();
            if (employee == null)
            {
                _logger.LogError("Could not remove time sheet. There was no requesting employee.");
                return false;
            }

            if (_timeSheetRepository.GetById(id) == null)
            {
                _logger.LogError($"Tried to remove time sheet that didn't exist. {id}");

                return false;
            }

            _logger.LogInformation($"Employee {employee.Email} removing time sheet {id}");

            _timeSheetRepository.Delete(id);
            _timeSheetRepository.Commit();

            return true;
        }

        public bool UpdateTimeSheet(TimeSheet timeSheet)
        {
            var employee = _authenticationService.GetLoggedInEmployee();
            if (employee == null)
            {
                _logger.LogError("Could not remove time sheet. There was no requesting employee.");
                return false;
            }

            if (!_validator.TryValidateModel(timeSheet, out var validationErrors))
            {
                _logger.LogError($"Tried to update invalid announcement. {timeSheet}");

                return false;
            }

            if (_timeSheetRepository.GetById(timeSheet.Id) == null)
            {
                _logger.LogError($"Tried to update announcement that didn't exist. {timeSheet}");

                return false;
            }

            _timeSheetRepository.Update(timeSheet);
            _timeSheetRepository.Commit();

            return true;
        }

        public bool ValidateTimeSheet(TimeSheet timeSheet)
        {
            bool valid = true;
            double[] weekByHours = new double[7];
            double weeklyTotal = 0;
            List<Core.Tasks.TaskEntry> taskList = new List<Core.Tasks.TaskEntry>();
            foreach (var t in timeSheet.TimeEntries)
            {
                weekByHours[0] += t.Sunday;
                weekByHours[1] += t.Monday;
                weekByHours[2] += t.Tuesday;
                weekByHours[3] += t.Wednesday;
                weekByHours[4] += t.Thursday;
                weekByHours[5] += t.Friday;
                weekByHours[6] += t.Saturday;
                taskList.Add(t.Task);
                if (t.Task.RequiresNote)
                {
                    if (t.Note == null || t.Note == "")
                    {
                        valid = false;
                        _logger.LogError($"Task {t.Task.Name} requires a note.");
                        return valid;
                    }
                }
            }
            foreach (double d in weekByHours)
            {
                weeklyTotal += d;
                if (d > 12)
                {
                    valid = false;
                    _logger.LogError($"Day {d} (Sunday = 0, Monday = 1, etc.) has more than 12 hours logged.");
                    return valid;
                }
            }
            if (weeklyTotal > 50)
            {
                valid = false;
                _logger.LogError($"Weekly total hours greater than 50. Weekly total hours is {weeklyTotal}");
                return valid;
            }
            var counter = taskList.GroupBy(t => t)
                .Where(g => g.Count() > 1)
                .Select(y => y.Key)
                .ToList();

            foreach (var t in counter)
            {
                valid = false;
                _logger.LogError($"There are multiple entries for {t.Name}");
                return valid;
            }

            return valid;
        }

        public TimeSheet GetTimeSheet(DateTime dateTime)
        {
            var employee = _authenticationService.GetLoggedInEmployee();
            if (employee == null)
            {
                _logger.LogError("Could not remove time sheet. There was no requesting employee.");
                return null;
            }

            TimeSheet timeSheet;

            timeSheet = _timeSheetRepository.GetAll()
                .Where(t => t.Week.DayOfYear == (dateTime.DayOfYear)   && employee.Id == t.Employee.Id).FirstOrDefault();
            return timeSheet;
        }
            
    }
}
