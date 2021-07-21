using HMB.GAP2019.Intranet.Core.Authentication;
using HMB.GAP2019.Intranet.Core.ModelValidation;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HMB.GAP2019.Intranet.Core.Task
{
    public class TaskService : ITaskService
    {
        private readonly ILogger<TaskService> _logger;
        private readonly IEmployeeAuthenticationService _authenticationService;
        private readonly IModelValidationService _validator;
        private readonly ITaskRepository _repo;

        public TaskService(ITaskRepository repo, ILogger<TaskService> logger, IEmployeeAuthenticationService authenticationService, IModelValidationService validationService)
        {
            _logger = logger;
            _authenticationService = authenticationService;
            _validator = validationService;
            _repo = repo;
        }

        public bool CreateTask(Tasks.Task task)
        {
            IList<ValidationResult> list = new List<ValidationResult>();
            var result = _validator.TryValidateModel(task, out list);
            if (!result)
            {
                return false;
            }
            _repo.Add(task);
            return true;
        }

        public bool DeleteTask(int id)
        {
            var result = _repo.GetById(id);
            if (result == null)
            {
                return false;
            }
            _repo.Delete(result.Id);
            try
            {
                _repo.Commit();
            } catch (Exception e)
            {
                _logger.LogError("Error Deleting Task: " + e);
                return false;
            }
            return true;
        }

        public IEnumerable<Tasks.Task> GetList()
        {
            return _repo.GetList();
        }

        public bool UpdateTask(Tasks.Task task)
        {
            IList<ValidationResult> list = new List<ValidationResult>();
            var result = _validator.TryValidateModel(task, out list);
            if (!result)
            {
                return false;
            }
            _repo.Update(task);
            return true;
        }
    }
}
