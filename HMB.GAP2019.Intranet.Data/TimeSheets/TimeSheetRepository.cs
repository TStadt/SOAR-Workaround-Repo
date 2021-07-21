using HMB.GAP2019.Intranet.Core.Timesheet;
using HMB.GAP2019.Intranet.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HMB.GAP2019.Intranet.Data.TimeSheets
{
    
    public class TimeSheetRepository : ITimeSheetRepository
    {
        private readonly IntranetContext _context;

        public TimeSheetRepository(IntranetContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(TimeSheet timeSheet)
        {
            _context.TimeSheet.Add(timeSheet);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public bool Delete(int id)
        {
            var timeSheet = GetById(id);
            if (timeSheet == null)
            {
                return false;
            }
            _context.TimeSheet.Remove(timeSheet);
            return true;

        }

        public bool Update(TimeSheet timeSheet)
        {
            var existingTimeSheet = GetById(timeSheet.Id);
            if (existingTimeSheet == null)
            {
                return false;
            }
            existingTimeSheet.Entries = timeSheet.Entries;
            existingTimeSheet.Employee = timeSheet.Employee;
            existingTimeSheet.MondayOfWeek = timeSheet.MondayOfWeek;

            _context.TimeSheet.Update(existingTimeSheet);
            return true;
        }

        public TimeSheet GetById(int id)
        {
            return _context.TimeSheet.Find(id); ;
        }

        public TimeSheet GetByEmployee(int id, DateTime dayOfWeek)
        {
            return _context.TimeSheet.Where(t => t.Employee.Id == id && t.MondayOfWeek == dayOfWeek)
                .ToList()
                .FirstOrDefault();
   
        }
    }
}
