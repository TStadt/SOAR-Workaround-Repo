using System.Collections.Generic;
using System.Linq;
using HMB.GAP2019.Intranet.Core.Authentication;
using HMB.GAP2019.Intranet.Core.ModelValidation;
using Microsoft.Extensions.Internal;
using Microsoft.Extensions.Logging;

namespace HMB.GAP2019.Intranet.Core.Announcements
{
    public class AnnouncementService : IAnnouncementService
    {
        private readonly IAnnouncementRepository _announcementRepository;
        private readonly IEmployeeAuthenticationService _authenticationService;
        private readonly IModelValidationService _validator;
        private readonly ISystemClock _clock;
        private readonly ILogger<AnnouncementService> _logger;

        public AnnouncementService(IAnnouncementRepository announcementRepository, IEmployeeAuthenticationService authenticationService, IModelValidationService validator, ISystemClock clock, ILogger<AnnouncementService> logger)
        {
            _announcementRepository = announcementRepository;
            _authenticationService = authenticationService;
            _validator = validator;
            _clock = clock;
            _logger = logger;
        }

        public bool CreateAnnouncement(Announcement announcement)
        {
            var employee = _authenticationService.GetLoggedInEmployee();
            if (employee == null)
            {
                _logger.LogError("Could not add announcement. There was no requesting employee.");
                return false;
            }

            if (!_validator.TryValidateModel(announcement, out var validationErrors))
            {
                _logger.LogError($"Tried to add invalid announcement. {announcement}. Errors are {@validationErrors}", announcement, validationErrors);

                return false;
            }

            announcement.StartDate = announcement.StartDate.ToUniversalTime().Date;
            announcement.EndDate = announcement.EndDate.ToUniversalTime().AddDays(1).Date;

            _announcementRepository.Add(announcement);
            _announcementRepository.Commit();

            return true;
        }

        public bool UpdateAnnouncement(Announcement announcement)
        {
            var employee = _authenticationService.GetLoggedInEmployee();
            if (employee == null)
            {
                _logger.LogError("Could not update announcement. There was no requesting employee.");
                return false;
            }

            if (!_validator.TryValidateModel(announcement, out var validationErrors))
            {
                _logger.LogError($"Tried to update invalid announcement. {announcement}");

                return false;
            }

            if (_announcementRepository.GetById(announcement.Id) == null)
            {
                _logger.LogError($"Tried to update announcement that didn't exist. {announcement}");

                return false;
            }

            _announcementRepository.Update(announcement);
            _announcementRepository.Commit();

            return true;
        }

        public bool RemoveAnnouncement(int id)
        {
            var employee = _authenticationService.GetLoggedInEmployee();
            if (employee == null)
            {
                _logger.LogError("Could not remove announcement. There was no requesting employee.");
                return false;
            }

            if (_announcementRepository.GetById(id) == null)
            {
                _logger.LogError($"Tried to remove announcement that didn't exist. {id}");

                return false;
            }

            _logger.LogInformation($"Employee {employee.Email} removing announcement {id}");

            _announcementRepository.Delete(id);
            _announcementRepository.Commit();

            return true;
        }

        public IEnumerable<Announcement> GetActiveAnnouncements()
            => _announcementRepository.GetAll()
                .Where(a => _clock.UtcNow >= a.StartDate && _clock.UtcNow <= a.EndDate)
                .OrderByDescending(a => a.IsHighPriority)
                .ThenByDescending(a => a.StartDate)
                .Take(5)
                .ToList();

        public IEnumerable<Announcement> GetAllAnnouncements()
            => _announcementRepository.GetAll()
                .OrderByDescending(a => a.IsHighPriority)
                .ThenByDescending(a => a.StartDate)
                .ToList();
    }
}
