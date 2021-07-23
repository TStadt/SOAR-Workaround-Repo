using CGI.SOAR.Intranet.Core.Announcements;
using CGI.SOAR.Intranet.Core.Authentication;
using CGI.SOAR.Intranet.Core.ModelValidation;
using Microsoft.Extensions.Internal;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit;

namespace CGI.SOAR.Intranet.Tests.Announcements
{
    public class AnnouncementServiceShould
    {
        private readonly IAnnouncementRepository _mockAnnouncementRepository;
        private readonly IEmployeeAuthenticationService _mockAuthenticationService;
        private readonly IModelValidationService _mockValidationService;
        private readonly ILogger<AnnouncementService> _mockLogger;
        private readonly ISystemClock _clock;
        private readonly IAnnouncementService _systemUnderTest;

        public AnnouncementServiceShould()
        {
            _mockAnnouncementRepository = Substitute.For<IAnnouncementRepository>();
            _mockAuthenticationService = Substitute.For<IEmployeeAuthenticationService>();
            _mockValidationService = Substitute.For<IModelValidationService>();
            _clock = Substitute.For<ISystemClock>();
            _mockLogger = Substitute.For<ILogger<AnnouncementService>>();
            
            _systemUnderTest = new AnnouncementService(
                _mockAnnouncementRepository,
                _mockAuthenticationService,
                _mockValidationService,
                _clock,
                _mockLogger
            );
        }

        [Fact]
        public void RequireALoggedInUserWhenCreatingAnAnnouncement()
        {
            // Arrange
            _mockAuthenticationService
               .GetLoggedInEmployee()
               .Returns(null as Employee);

            // Act
            var actual = _systemUnderTest.CreateAnnouncement(new Announcement());

            // Assert
            Assert.False(actual);
            _mockAnnouncementRepository
               .DidNotReceive()
               .Add(Arg.Any<Announcement>());
        }
    }
}
