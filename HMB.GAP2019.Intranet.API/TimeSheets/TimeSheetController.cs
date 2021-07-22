using HMB.GAP2019.Intranet.Core.TimeSheets;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMB.GAP2019.Intranet.API.TimeSheets
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TimeSheetController : Controller
    {
        private readonly ITimeSheetService _timeSheetService;
        private readonly ITimeSheetRepository _repository;

        public TimeSheetController(ITimeSheetRepository timeSheetRepository, ITimeSheetService timeSheetService)
        {
            _timeSheetService = timeSheetService;
            _repository = timeSheetRepository;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Dictionary<string, string[]>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult CreateTimeSheet([FromBody] TimeSheet timeSheet)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = _timeSheetService.CreateTimeSheet(timeSheet);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Dictionary<string, string[]>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult UpdateTimeSheet([FromBody] TimeSheet timeSheet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (_repository.GetById(timeSheet.Id) == null)
            {
                return NotFound();
            }
            var result = _timeSheetService.UpdateTimeSheet(timeSheet);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Dictionary<string, string[]>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult RemoveTimeSheet([FromBody] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (_repository.GetById(id) == null)
            {
                return NotFound();
            }
            var result = _timeSheetService.RemoveTimeSheet(id);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Dictionary<string, string[]>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("{dateTime}")]
        public IActionResult GetTimeSheet(DateTime week)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = _timeSheetService.GetTimeSheet(week);
            if(result == null)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Dictionary<string, string[]>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("validate")]
        public IActionResult ValidateTimeSheet([FromBody] TimeSheet timeSheet)
        {if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = _timeSheetService.ValidateTimeSheet(timeSheet);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
