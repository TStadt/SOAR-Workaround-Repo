using System;
using System.Collections.Generic;
using System.Linq;
using CGI.SOAR.Intranet.Core.Authentication;
using CGI.SOAR.Intranet.Core.ModelValidation;
using Microsoft.Extensions.Logging;

namespace CGI.SOAR.Intranet.Core.TimesSheets
{
    public class TimeSheetService : ITimeSheetService
    {
        private readonly IEmployeeAuthenticationService _authenticationService;
        private readonly ITimeSheetRepository _repository;
        private readonly IModelValidationService _validator;
        private readonly ILogger<TimeSheetService> _logger;

        public TimeSheetService(IEmployeeAuthenticationService authenticationService, ITimeSheetRepository repository, IModelValidationService validator, ILogger<TimeSheetService> logger)
        {
            _authenticationService = authenticationService;
            _repository = repository;
            _validator = validator;
            _logger = logger;
        }

        public TimeSheet GetTimeSheet(DateTime dateInWeek)
        {
            var employee = _authenticationService.GetLoggedInEmployee();
            if (employee == null)
            {
                _logger.LogError("Could not get timesheet. There was no requesting employee.");
                return null;
            }

            return _repository.GetByEmployeeAndStartOfWeek(employee, GetMonday(dateInWeek));
        }

        public bool SubmitTimeSheet(TimeSheet timeSheet)
        {
            var employee = _authenticationService.GetLoggedInEmployee();
            if (employee == null)
            {
                _logger.LogError("Could not submit timesheet. There was no requesting employee.");
                return false;
            }

            var validationErrors = ValidateTimeSheet(timeSheet);
            if (validationErrors.Any())
            {
                _logger.LogError($"Tried to update invalid announcement. {timeSheet}");

                return false;
            }

            timeSheet.Employee = employee;
            _repository.Submit(timeSheet);

            return true;
        }

        public Dictionary<string, IEnumerable<string>> ValidateTimeSheet(TimeSheet timeSheet)
        {
            _validator.TryValidateModel(timeSheet, out var validationErrors);

            var returnValue = validationErrors.ToDictionary(error => error.ErrorMessage, error => error.MemberNames);

            foreach (var entry in timeSheet.Entries)
            {
                _validator.TryValidateModel(entry, out validationErrors);

                foreach (var error in validationErrors)
                {
                    returnValue.Add(error.ErrorMessage, error.MemberNames);
                }

                if (entry.AssignedTask.IsNoteRequired && string.IsNullOrWhiteSpace(entry.Note))
                {
                    returnValue.Add($"Task '{entry.AssignedTask.Name}' requires a note, but none was entered.", new[] { nameof(timeSheet.Entries) });
                }
            }

            var duplicateTasks = timeSheet.Entries.GroupBy(te => te.AssignedTask.Id)
                .Where(g => g.Count() > 1)
                .Select(g => g.First().AssignedTask);
            foreach (var duplicateTask in duplicateTasks)
            {
                returnValue.Add($"Multiple time entries exist for task '{duplicateTask.Name}'. Only one entry may exist per task", new[] { nameof(timeSheet.Entries) });
            }

            if (timeSheet.TotalFor(te => te.Monday) > 12)
            {
                returnValue.Add("Total hours for Monday exceeds 12 hours", new[] { nameof(timeSheet.Entries) });
            }

            if (timeSheet.TotalFor(te => te.Tuesday) > 12)
            {
                returnValue.Add("Total hours for Tuesday exceeds 12 hours", new[] { nameof(timeSheet.Entries) });
            }

            if (timeSheet.TotalFor(te => te.Wednesday) > 12)
            {
                returnValue.Add("Total hours for Wednesday exceeds 12 hours", new[] { nameof(timeSheet.Entries) });
            }

            if (timeSheet.TotalFor(te => te.Thursday) > 12)
            {
                returnValue.Add("Total hours for Thursday exceeds 12 hours", new[] { nameof(timeSheet.Entries) });
            }

            if (timeSheet.TotalFor(te => te.Friday) > 12)
            {
                returnValue.Add("Total hours for Friday exceeds 12 hours", new[] { nameof(timeSheet.Entries) });
            }

            if (timeSheet.TotalFor(te => te.Saturday) > 12)
            {
                returnValue.Add("Total hours for Saturday exceeds 12 hours", new[] { nameof(timeSheet.Entries) });
            }

            if (timeSheet.TotalFor(te => te.Sunday) > 12)
            {
                returnValue.Add("Total hours for Sunday exceeds 12 hours", new[] { nameof(timeSheet.Entries) });
            }

            if (timeSheet.TotalForWeek() > 50)
            {
                returnValue.Add("Total hours for week exceeds 50 hours", new[] { nameof(timeSheet.Entries) });
            }

            return returnValue;
        }

        private static DateTime GetMonday(DateTime dateInWeek)
        {
            var utcDate = dateInWeek.ToUniversalTime();
            return utcDate.DayOfWeek == DayOfWeek.Sunday ?
                utcDate.Date.AddDays(-6) :
                utcDate.Date.AddDays(DayOfWeek.Monday - utcDate.DayOfWeek);
        }
    }
}
