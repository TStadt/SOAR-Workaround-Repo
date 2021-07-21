using HMB.GAP2019.Intranet.Core.Task;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using 

namespace HMB.GAP2019.Intranet.API.Tasks
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private readonly ITaskRepository _repo;

        public TaskController(ITaskRepository repository, ITaskService taskService)
        {
            _taskService = taskService;
            _repo = repository;
        }

        [HttpPost("/submit")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Dictionary<string, string[]>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Create([FromBody] Core.Tasks.Task task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createTask = _taskService.CreateTask(task);
            if (!createTask)
            {
                return BadRequest();
            }
            return Ok();
        }


        // GET api/<TimeSheetController>/5
        [HttpGet("/get")]
        public IActionResult Get()
        {
            var result = _taskService.GetList();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // DELETE api/<TimeSheetController>/5
        [HttpDelete("/delete")]
        public IActionResult Delete([FromQuery] int id)
        {
            var result = _taskService.DeleteTask(id);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
