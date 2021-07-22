using HMB.GAP2019.Intranet.Core.Timesheet;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HMB.GAP2019.Intranet.API.Timesheets
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]

    public class TimeSheetController : ControllerBase
    {
        private readonly ITimeSheetService _timeSheetService;
        private readonly ITimeSheetRepository _repo;

        public TimeSheetController(ITimeSheetRepository repository, ITimeSheetService timeSheetService)
        {
            _timeSheetService = timeSheetService;
            _repo = repository;
        }

        [HttpPost("/submit")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Dictionary<string, string[]>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Create([FromBody] TimeSheet timeSheet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var validate = _timeSheetService.ValidateTimeSheet(timeSheet);
            if (validate.Any(l => l.Value.Count() > 0))
            {
                return BadRequest(validate);
            }
            var result = _timeSheetService.SubmitTimeSheet(timeSheet);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }


        // GET api/<TimeSheetController>/5
        [HttpGet("/get")]
        public IActionResult Get([FromQuery] DateTime startDate)
        {
            TimeSheet result = _timeSheetService.GetTimeSheet(startDate);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // DELETE api/<TimeSheetController>/5
        [HttpDelete("/delete")]
        public IActionResult Delete([FromQuery] DateTime startDate)
        {
            var result = _timeSheetService.DeleteTimeSheet(startDate);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
