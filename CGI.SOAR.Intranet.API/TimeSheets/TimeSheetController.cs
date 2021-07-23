using System;
using System.Collections.Generic;
using System.Linq;
using CGI.SOAR.Intranet.Core.TimesSheets;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace CGI.SOAR.Intranet.API.TimeSheets
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TimeSheetController : Controller
    {
        private readonly ITimeSheetService _service;
        private readonly ITaskRepository _taskRepository;

        public TimeSheetController(ITimeSheetService service, ITaskRepository taskRepository)
        {
            _service = service;
            _taskRepository = taskRepository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(TimeSheet), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("{dateInWeek}")]
        public IActionResult Get(DateTime dateInWeek)
        {
            var timeSheet = _service.GetTimeSheet(dateInWeek.ToUniversalTime().Date);
            if (timeSheet == null)
            {
                return Unauthorized();
            }

            return Ok(timeSheet);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Dictionary<string, string[]>), StatusCodes.Status400BadRequest)]
        [Route("validate")]
        public IActionResult Validate([FromBody] TimeSheet timeSheet)
        {
            timeSheet.MondayOfWeek = timeSheet.MondayOfWeek.ToUniversalTime().Date;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var returnValue = _service.ValidateTimeSheet(timeSheet);
            if (returnValue.Any())
            {
                return BadRequest(returnValue);
            }

            return NoContent();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Dictionary<string, string[]>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Submit([FromBody] TimeSheet timeSheet)
        {
            timeSheet.MondayOfWeek = timeSheet.MondayOfWeek.ToUniversalTime().Date;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var returnValue = _service.ValidateTimeSheet(timeSheet);
            if (returnValue.Any())
            {
                return BadRequest(returnValue);
            }

            if (!_service.SubmitTimeSheet(timeSheet))
            {
                return Unauthorized();
            }

            return NoContent();
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Task>), StatusCodes.Status200OK)]
        [Route("tasks")]
        public IActionResult GetTasks()
            => Ok(_taskRepository.GetAll().ToList());
    }
}