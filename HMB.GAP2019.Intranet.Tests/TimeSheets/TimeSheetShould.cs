using HMB.GAP2019.Intranet.Core.Authentication;
using HMB.GAP2019.Intranet.Core.ModelValidation;
using HMB.GAP2019.Intranet.Core.Timesheet;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace HMB.GAP2019.Intranet.Tests.TimeSheets
{
    public class TimeSheetShould
    {
        private readonly ILogger<TimeSheetService> _mockLogger;
        private readonly IEmployeeAuthenticationService _mockAuthenticationService;
        private readonly IModelValidationService _mockValidator;
        private readonly ITimeSheetRepository _mockRepo;
        private readonly ITimeSheetService _systemUnderTest;

        public TimeSheetShould()
        {
            _mockRepo = Substitute.For<ITimeSheetRepository>();
            _mockAuthenticationService = Substitute.For<IEmployeeAuthenticationService>();
            _mockValidator = Substitute.For<IModelValidationService>();
            _mockLogger = Substitute.For<ILogger<TimeSheetService>>();

            _systemUnderTest = new TimeSheetService(
                _mockRepo, _mockLogger, _mockAuthenticationService, _mockValidator
                );
        }

        [Fact]
        public void RequireATimeSheetToNotGoOver50Hours()
        {
            //Arrange
            var timeSheet = new TimeSheet();
            IList<TimeEntry> list = new List<TimeEntry>();
            timeSheet.Entries = list;
            list.Add(new TimeEntry { Monday = 10, Tuesday = 10, Wednesday = 10, Thursday = 12, Friday = 12, Task = new Core.Tasks.Task{ Name = "Develop"} });


            //Act
            var actual = _systemUnderTest.ValidateTimeSheet(timeSheet);

            //Assert
            Assert.True(actual.Any(l => l.Value.Count() > 0));
        }
    }
}
