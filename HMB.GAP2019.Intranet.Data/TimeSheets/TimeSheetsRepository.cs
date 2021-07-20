using HMB.GAP2019.Intranet.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HMB.GAP2019.Intranet.Core.TimeSheets;

namespace HMB.GAP2019.Intranet.Data.TimeSheets
{
    public class TimeSheetsRepository : ITimeSheetRepository
    {
        /* dependency injection */
        private readonly IntranetContext _context;

        public TimeSheetsRepository(IntranetContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(TimeSheet timeSheet)
        {
            _context.Timesheet.Add(timeSheet);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public bool Delete(int id)
        {
            TimeSheet entity = _context.Timesheet.Find(id);
            var result = _context.Timesheet.Remove(entity).State;
            if (result.Equals(EntityState.Deleted))
            {
                return true;
            } else
            {
                return false;
            }
        }

        public IQueryable<TimeSheet> GetAll()
        {
            return _context.Timesheet.AsQueryable();
        }

        public TimeSheet GetById(int id)
        {
            return _context.Timesheet.Find(id);
        }

        public bool Update(TimeSheet timeSheet)
        {
            var result = _context.Timesheet.Update(timeSheet).State;
            if (result.Equals(EntityState.Modified))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }


}