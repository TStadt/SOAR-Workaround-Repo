using HMB.GAP2019.Intranet.Core.Authentication;
using HMB.GAP2019.Intranet.Core.ModelValidation;
using HMB.GAP2019.Intranet.Core.TimeSheets;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace HMB.GAP2019.Intranet.Core.Tasks
{
    class TaskEntryService : ITaskEntryService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IEmployeeAuthenticationService _authenticationService;
        private readonly IModelValidationService _validator;
        private readonly ILogger<TimeSheetService> _logger;
        private readonly ITimeSheetRepository _timeSheetRepository;

        public TaskEntryService(ILogger<TimeSheetService> logger, ITaskRepository taskRepository, IEmployeeAuthenticationService employeeAuthenticationService, IModelValidationService modelValidationService, ITimeSheetRepository timeSheetRepository)
        {
            _taskRepository = taskRepository;
            _authenticationService = employeeAuthenticationService;
            _validator = modelValidationService;
            _logger = logger;
            _timeSheetRepository = timeSheetRepository;
        }

        public bool CreateTaskEntry(TaskEntry taskEntry)
        {
            if (!_validator.TryValidateModel(taskEntry, out var validationErrors))
            {
                _logger.LogError($"Tried to add invalid task entry. {taskEntry}. Errors are {@validationErrors}", taskEntry, validationErrors);

                return false;
            }

            _taskRepository.Add(taskEntry);
            _taskRepository.Commit();

            return true;
        }

        public TaskEntry GetTaskEntry(int id)
        {
            TaskEntry taskEntry = _taskRepository.GetById(id);
            if (taskEntry == null)
            {
                _logger.LogError($"No task entry found for id {id}.");
            }
            return taskEntry;
        }

        public bool RemoveTaskEntry(int id)
        {
            TaskEntry taskEntry = _taskRepository.GetById(id);
            if (taskEntry == null)
            {
                _logger.LogError($"No task entry found for id {id}.");
                return false;
            }
            _taskRepository.Delete(id);
            _taskRepository.Commit();
            return true;
        }

        public bool UpdateTaskEntry(TaskEntry taskEntry)
        {
            if (!_validator.TryValidateModel(taskEntry, out var validationErrors))
            {
                _logger.LogError($"Tried to add invalid task entry. {taskEntry}. Errors are {@validationErrors}", taskEntry, validationErrors);

                return false;
            }

            if(_taskRepository.GetById(taskEntry.Id) == null)
            {
                _logger.LogError($"No task entry found for id {taskEntry.Id}.");
                return false;
            }
            _taskRepository.Update(taskEntry);
            _taskRepository.Commit();
            return true;
        }

    }
}
