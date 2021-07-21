using HMB.GAP2019.Intranet.Core.TimeSheets;
using HMB.GAP2019.Intranet.Core.Authentication;
using HMB.GAP2019.Intranet.Core.ModelValidation;
using Microsoft.Extensions.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using HMB.GAP2019.Intranet.Core.TimeEntry;
using HMB.GAP2019.Intranet.Core.Tasks;

namespace HMB.GAP2019.Intranet.Tests.TimeSheets
{
    [TestClass]
    public class TimeSheetServiceTest
    {
        private readonly ITimeSheetRepository _mockTimeSheetRepository;
        private readonly IEmployeeAuthenticationService _mockAuthenticationService;
        private readonly IModelValidationService _mockValidationService;
        private readonly ILogger<TimeSheetService> _mockLogger;
        private readonly ITimeSheetService _systemUnderTest;
        private readonly TimeSheet _invalidTimeSheet;
        public TimeSheetServiceTest()
        {
            _mockTimeSheetRepository = Substitute.For<ITimeSheetRepository>();
            //_mockEmployeeRepository = Substitute.For<IEmployeeRepository>();
            _mockAuthenticationService = Substitute.For<IEmployeeAuthenticationService>();
            _mockValidationService = Substitute.For<IModelValidationService>();
            _mockLogger = Substitute.For<ILogger<TimeSheetService>>();
            _invalidTimeSheet = new TimeSheet()
            {
                employee = new Employee()
                {
                    Email = "test@test.com",
                    FirstName = "John",
                    LastName = "Doe"
                },
                dateTime = DateTime.Now,
                timeEntries = new List<Core.TimeEntry.TimeEntry>()
                {
                    new TimeEntry() {
                        Monday = 20,
                        Tuesday = 20,
                        Wednesday = 20,
                        Thursday = 20,
                        Friday = 20,
                        Saturday = 20,
                        Sunday = 20,
                        Task = new Core.Tasks.TaskEntry() { Name = "Training" }
                    },
                    new TimeEntry() {
                        Monday = 10,
                        Tuesday = 10,
                        Wednesday = 10,
                        Thursday = 10,
                        Friday = 10,
                        Saturday = 10,
                        Task = new Core.Tasks.TaskEntry() { Name = "Training" }
                    }
                }
            };
            _systemUnderTest = new TimeSheetService(
                _mockTimeSheetRepository,
                _mockAuthenticationService,
                _mockValidationService,
                _mockLogger
            );
        }

        [TestMethod]
        public void SpendOver12HoursPerDayTest()
        {
            // Arrange
             var timeSheet = new TimeSheet()
             {
                 employee = new Employee()
                 {
                     Email = "test@test.com",
                     FirstName = "John",
                     LastName = "Doe"
                 },
                 dateTime = DateTime.Now,
                 timeEntries = new List<Core.TimeEntry.TimeEntry>()
                {
                    new TimeEntry() {
                        Monday = 20,
                        Tuesday = 20,
                        Wednesday = 20,
                        Thursday = 20,
                        Friday = 20,
                        Saturday = 20,
                        Sunday = 20,
                        Task = new Core.Tasks.TaskEntry() { Name = "Training" }
                    }
                }
             };

             // Act
            var actual = _systemUnderTest.ValidateTimeSheet(timeSheet);

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void SpendOver50HoursTest()
        {
            // Arrange
            var timeSheet = new TimeSheet()
            {
                employee = new Employee()
                {
                    Email = "test@test.com",
                    FirstName = "John",
                    LastName = "Doe"
                },
                dateTime = DateTime.Now,
                timeEntries = new List<Core.TimeEntry.TimeEntry>()
                {
                    new TimeEntry() {
                        Monday = 10,
                        Tuesday = 10,
                        Wednesday = 10,
                        Thursday = 10,
                        Friday = 10,
                        Saturday = 10,
                        Sunday = 10,
                        Task = new Core.Tasks.TaskEntry() { Name = "Training" }
                    }
                }
            };

            // Act
            var actual = _systemUnderTest.ValidateTimeSheet(timeSheet);

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void GetTimeSheetTest()
        {
            // Arrange
            _mockAuthenticationService.GetLoggedInEmployee().Returns(new Employee()
            {
                Email = "test@test.com",
                FirstName = "John",
                LastName = "Doe",
                Id = 1
            });


            var timeSheet = new TimeSheet()
            {
                employee = new Employee()
                {
                    Email = "test@test.com",
                    FirstName = "Jane",
                    LastName = "Doe",
                    Id = 2
                },
                dateTime = DateTime.Now,
                Id = 2,
                timeEntries = new List<Core.TimeEntry.TimeEntry>()
                {
                    new TimeEntry() {
                        Monday = 10,
                        Tuesday = 10,
                        Wednesday = 10,
                        Thursday = 10,
                        Task = new Core.Tasks.TaskEntry() { Name = "Training" }
                    }
                }
            };
            List<TimeSheet> timeSheetsQuery = new List<TimeSheet>() { timeSheet };

            _mockTimeSheetRepository.GetAll().Returns(timeSheetsQuery.AsQueryable());

            // Act
            var actual = _systemUnderTest.GetTimeSheet(DateTime.Now);
            // Assert
            Assert.IsNull(actual);

            
        }
        [TestMethod]
        public void GetTimeSheetNoEmployeeTest()
        {
            //Arrange
            _mockAuthenticationService.GetLoggedInEmployee().Returns((Employee)null);
            //Act
            _systemUnderTest.GetTimeSheet(DateTime.Now);
            //Assert
            _mockLogger.LogError("Could not remove time sheet. There was no requesting employee.");
        }

        [TestMethod]
        public void OneTimeEntryPerTaskPerWeekPerEmployeeTest()
        {
            // Arrange
            var timeSheet = new TimeSheet()
            {
                employee = new Employee()
                {
                    Email = "test@test.com",
                    FirstName = "John",
                    LastName = "Doe"
                },
                dateTime = DateTime.Now,
                timeEntries = new List<Core.TimeEntry.TimeEntry>()
                {
                    new TimeEntry() {
                        Monday = 2,
                        Tuesday = 2,
                        Wednesday = 2,
                        Thursday = 2,
                        Friday = 2,
                        Saturday = 2,
                        Sunday = 2,
                        Task = new Core.Tasks.TaskEntry() { Name = "Training" }
                    },
                    new TimeEntry() {
                        Monday = 10,
                        Tuesday = 10,
                        Wednesday = 10,
                        Thursday = 10,
                        Friday = 10,
                        Saturday = 10,
                        Sunday = 10,
                        Task = new Core.Tasks.TaskEntry() { Name = "Training" }
                    }
                }
            };

            // Act
            var actual = _systemUnderTest.ValidateTimeSheet(timeSheet);

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void TaskHasANoteIfRequiredTest()
        {
            // Arrange
            TaskEntry task = new TaskEntry()
            {
                Name = "Training",
                RequiresNote = true
            };

            TimeEntry timeEntry = new TimeEntry()
            {
                 Monday = 2,
                 Tuesday = 2,
                 Wednesday = 2,
                 Thursday = 2,
                 Friday = 2,
                 Saturday = 2,
                 Sunday = 2,
                 Task = task,
                 Note = ""
            };
            TimeSheet timeSheet = new TimeSheet()
            {
                timeEntries = new List<TimeEntry> { timeEntry }
            };

            // Act
            var actual = _systemUnderTest.ValidateTimeSheet(timeSheet);

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void AuthenticationRequiredToCreateTimeSheetFailedTest()
        {
            // Arrange
             var timeSheet = new TimeSheet()
            {
                dateTime = DateTime.Now,
                timeEntries = new List<Core.TimeEntry.TimeEntry>()
                {
                    new TimeEntry() {
                        Monday = 2,
                        Tuesday = 2,
                        Wednesday = 2,
                        Thursday = 2,
                        Friday = 2,
                        Saturday = 2,
                        Sunday = 2,
                        Task = new Core.Tasks.TaskEntry() { Name = "Training" }
                    },
                    new TimeEntry() {
                        Monday = 10,
                        Tuesday = 10,
                        Wednesday = 10,
                        Thursday = 10,
                        Friday = 10,
                        Saturday = 10,
                        Sunday = 10,
                        Task = new Core.Tasks.TaskEntry() { Name = "Training" }
                    }
                }
            };

            // Act
            var actual = _systemUnderTest.CreateTimeSheet(timeSheet);

            // Assert
            Assert.IsFalse(actual);
        }

    }
}
