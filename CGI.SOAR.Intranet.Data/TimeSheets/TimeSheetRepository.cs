using System;
using System.Collections.Generic;
using System.Linq;
using CGI.SOAR.Intranet.Core.Authentication;
using CGI.SOAR.Intranet.Core.TimesSheets;
using CGI.SOAR.Intranet.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CGI.SOAR.Intranet.Data.TimeSheets
{
    public class TimeSheetRepository : ITimeSheetRepository
    {
        private readonly IntranetContext _context;

        public TimeSheetRepository(IntranetContext context)
        {
            _context = context;
        }

        public TimeSheet GetByEmployeeAndStartOfWeek(Employee employee, DateTime startOfWeek)
        {
            var entries = GetEntriesForEmployee(employee.Id, startOfWeek);

            return ToApplicationObject(entries, employee, startOfWeek);
        }

        public void Submit(TimeSheet sheet)
        {
            var entries = GetEntriesForEmployee(sheet.Employee.Id, sheet.MondayOfWeek).ToList();
            foreach (var removedEntry in entries.Where(te => sheet.Entries.All(te2 => te2.AssignedTask.Id != te.AssignedTask.Id)))
            {
                _context.TimeEntries.Remove(removedEntry);
            }

            foreach (var addedEntry in sheet.Entries.Where(te => entries.All(te2 => te2.AssignedTask.Id != te.AssignedTask.Id)))
            {
                addedEntry.AssignedTask = _context.Tasks.Find(addedEntry.AssignedTask.Id);
                _context.TimeEntries.Add(ToDataAccessObject(addedEntry, sheet.Employee, sheet.MondayOfWeek));
            }

            foreach (var modifiedEntry in sheet.Entries)
            {
                var existingEntry = entries.FirstOrDefault(te => te.AssignedTask.Id == modifiedEntry.AssignedTask.Id);
                if (existingEntry == null)
                {
                    continue;
                }

                existingEntry = ToDataAccessObject(modifiedEntry, sheet.Employee, sheet.MondayOfWeek, existingEntry);

                _context.TimeEntries.Update(existingEntry);
            }

            _context.SaveChanges();
        }

        private IEnumerable<TimeEntryEntity> GetEntriesForEmployee(int employeeId, DateTime startOfWeek)
            => _context.TimeEntries
                .Include(te => te.AssignedEmployee)
                .Include(te => te.AssignedTask)
                .Where(te => te.AssignedEmployee.Id == employeeId && te.MondayOfWeek == startOfWeek)
                .AsEnumerable();

        private static TimeSheet ToApplicationObject(IEnumerable<TimeEntryEntity> entries, Employee employee, DateTime startOfWeek)
            => new TimeSheet
            {
                Employee = employee,
                MondayOfWeek = startOfWeek,
                Entries = entries.Select(ToApplicationObject)
            };

        private static TimeEntry ToApplicationObject(TimeEntryEntity entity)
            => new TimeEntry
            {
                AssignedTask = entity.AssignedTask,

                Monday = entity.Monday,
                Tuesday = entity.Tuesday,
                Wednesday = entity.Wednesday,
                Thursday = entity.Thursday,
                Friday = entity.Friday,
                Saturday = entity.Saturday,
                Sunday = entity.Sunday,

                Note = entity.Note
            };


        private static IEnumerable<TimeEntryEntity> ToDataAccessObject(TimeSheet sheet)
            => sheet.Entries.Select(entry => ToDataAccessObject(entry, sheet.Employee, sheet.MondayOfWeek));

        private static TimeEntryEntity ToDataAccessObject(TimeEntry entry, Employee employee, DateTime startOfWeek,
            TimeEntryEntity existingEntity = null)
        {
            existingEntity = existingEntity ?? new TimeEntryEntity();

            existingEntity.AssignedEmployee = existingEntity.AssignedEmployee ?? employee;
            existingEntity.AssignedTask = existingEntity.AssignedTask ?? entry.AssignedTask;

            existingEntity.MondayOfWeek = startOfWeek;

            existingEntity.Monday = entry.Monday;
            existingEntity.Tuesday = entry.Tuesday;
            existingEntity.Wednesday = entry.Wednesday;
            existingEntity.Thursday = entry.Thursday;
            existingEntity.Friday = entry.Friday;
            existingEntity.Saturday = entry.Saturday;
            existingEntity.Sunday = entry.Sunday;

            existingEntity.Note = entry.Note;

            return existingEntity;
        }
    }
}
