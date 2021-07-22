using HMB.GAP2019.Intranet.Core.Announcements;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HMB.GAP2019.Intranet.API.Announcements
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementService _announcementService;
        private readonly IAnnouncementRepository _repository;

        public AnnouncementController(IAnnouncementService announcementService, IAnnouncementRepository repository)
        {
            _announcementService = announcementService;
            _repository = repository;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Dictionary<string, string[]>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Create([FromBody] Announcement announcement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _announcementService.CreateAnnouncement(announcement);
            if (!result)
            {
                return Unauthorized();
            }

            return Ok();
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Dictionary<string, string[]>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Update([FromBody] Announcement announcement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (_repository.GetById(announcement.Id) == null)
            {
                return NotFound();
            }

            var result = _announcementService.UpdateAnnouncement(announcement);
            if (!result)
            {
                return Unauthorized();
            }

            return NoContent();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{id:int}")]
        public IActionResult Delete(int id)
        {
            if (_repository.GetById(id) == null)
            {
                return NotFound();
            }

            var result = _announcementService.RemoveAnnouncement(id);
            if (!result)
            {
                return Unauthorized();
            }

            return NoContent();
        }

        [HttpGet]
        [ProducesResponseType(typeof(Announcement), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{id:int}")]
        public IActionResult Get(int id)
        {
            var announcement = _repository.GetById(id);
            if (announcement == null)
            {

                return NotFound();
            }

            return Ok(announcement);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Announcement>), StatusCodes.Status200OK)]
        [Route("active")]
        public IActionResult GetActive()
            => Ok(_announcementService.GetActiveAnnouncements());

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Announcement>), StatusCodes.Status200OK)]
        public IActionResult GetAll()
            => Ok(_announcementService.GetAllAnnouncements());
    }
}