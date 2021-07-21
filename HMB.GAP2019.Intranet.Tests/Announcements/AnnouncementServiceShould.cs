using HMB.GAP2019.Intranet.Core.Announcements;
using HMB.GAP2019.Intranet.Core.Authentication;
using HMB.GAP2019.Intranet.Core.ModelValidation;
using Microsoft.Extensions.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HMB.GAP2019.Intranet.Tests.Announcements
{
    [TestClass]
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

        [TestMethod]
        public void RequireALoggedInUserWhenCreatingAnAnnouncement()
        {
            // Arrange
            _mockAuthenticationService
               .GetLoggedInEmployee()
               .Returns(null as Employee);

            // Act
            var actual = _systemUnderTest.CreateAnnouncement(new Announcement());

            // Assert
            Assert.IsFalse(actual);
            _mockAnnouncementRepository
               .DidNotReceive()
               .Add(Arg.Any<Announcement>());
        }

        [TestMethod]
        public void GetFiveActiveAnnouncements()
        {
            // Arrange
            List<Announcement> announcements = new List<Announcement>()
            {
                new Announcement{Id=1, StartDate=System.DateTime.Now.AddDays(-1), EndDate=System.DateTime.Now.AddDays(1), IsHighPriority=true, Title="test 1", Body="test 1"},
                new Announcement{Id=2, StartDate=System.DateTime.Now.AddDays(-1), EndDate=System.DateTime.Now.AddDays(1), IsHighPriority=true, Title="test 2", Body="test 2"},
                new Announcement{Id=3, StartDate=System.DateTime.Now.AddDays(-1), EndDate=System.DateTime.Now.AddDays(1), IsHighPriority=true, Title="test 3", Body="test 3"},
                new Announcement{Id=4, StartDate=System.DateTime.Now.AddDays(-1), EndDate=System.DateTime.Now.AddDays(1), IsHighPriority=true, Title="test 4", Body="test 4"},
                new Announcement{Id=5, StartDate=System.DateTime.Now.AddDays(-1), EndDate=System.DateTime.Now.AddDays(1), IsHighPriority=true, Title="test 5", Body="test 5"},
                new Announcement{Id=6, StartDate=System.DateTime.Now.AddDays(-1), EndDate=System.DateTime.Now.AddDays(1), IsHighPriority=true, Title="test 6", Body="test 6"}
            };
            _mockAnnouncementRepository.GetAll().Returns(announcements.AsQueryable());
            _clock.UtcNow.Returns(new DateTimeOffset(DateTime.Now));
            // Act
            var actual = _systemUnderTest.GetActiveAnnouncements();
            // Assert
            Assert.AreEqual(5, actual.Count());
        }


        [TestMethod]
        public void SortFiveActiveAnnouncementsByHighPriorityAndDate()
        {
            // Arrange
            List<Announcement> announcements = new List<Announcement>()
            {
                new Announcement{Id=1, StartDate=System.DateTime.Now.AddDays(-1), EndDate=System.DateTime.Now.AddDays(1), IsHighPriority=false, Title="test 1 hp false", Body="test 1 hp false"},
                new Announcement{Id=2, StartDate=System.DateTime.Now.AddDays(-2), EndDate=System.DateTime.Now.AddDays(2), IsHighPriority=true, Title="test 2 hp true", Body="test 2 hp true"},
                new Announcement{Id=3, StartDate=System.DateTime.Now.AddDays(-3), EndDate=System.DateTime.Now.AddDays(3), IsHighPriority=false, Title="test 3 hp false", Body="test 3 hp false"},
                new Announcement{Id=4, StartDate=System.DateTime.Now.AddDays(-1), EndDate=System.DateTime.Now.AddDays(1), IsHighPriority=true, Title="test 1 hp true", Body="test 1 hp true"},
                new Announcement{Id=5, StartDate=System.DateTime.Now.AddDays(-2), EndDate=System.DateTime.Now.AddDays(2), IsHighPriority=false, Title="test 2 hp false", Body="test 2 hp flase"},
                new Announcement{Id=6, StartDate=System.DateTime.Now.AddDays(-3), EndDate=System.DateTime.Now.AddDays(3), IsHighPriority=true, Title="test 3 hp true", Body="test 3 true"}
            };
            List<Announcement> expected = new List<Announcement>()
            {
                new Announcement{Id=4, StartDate=System.DateTime.Now.AddDays(-1), EndDate=System.DateTime.Now.AddDays(1), IsHighPriority=true, Title="test 1 hp true", Body="test 1 hp true"},
                new Announcement{Id=2, StartDate=System.DateTime.Now.AddDays(-2), EndDate=System.DateTime.Now.AddDays(2), IsHighPriority=true, Title="test 2 hp true", Body="test 2 hp true"},
                new Announcement{Id=6, StartDate=System.DateTime.Now.AddDays(-3), EndDate=System.DateTime.Now.AddDays(3), IsHighPriority=true, Title="test 3 hp true", Body="test 3 true"},
                new Announcement{Id=1, StartDate=System.DateTime.Now.AddDays(-1), EndDate=System.DateTime.Now.AddDays(1), IsHighPriority=false, Title="test 1 hp false", Body="test 1 hp false"},
                new Announcement{Id=5, StartDate=System.DateTime.Now.AddDays(-2), EndDate=System.DateTime.Now.AddDays(2), IsHighPriority=false, Title="test 2 hp false", Body="test 2 hp flase"}
            };
            _mockAnnouncementRepository.GetAll().Returns(announcements.AsQueryable());
            _clock.UtcNow.Returns(new DateTimeOffset(DateTime.Now));

            // Act
            var actual = _systemUnderTest.GetActiveAnnouncements();

            // Assert
            for (int i = 0; i < 5; i++)
            {
                Assert.AreEqual(actual.ToArray()[i].Id, expected.ToArray()[i].Id);

            }
        }
    }
}
