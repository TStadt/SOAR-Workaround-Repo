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
            _context.Timesheets.Add(timeSheet);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public bool Delete(int id)
        {
            TimeSheet entity = _context.Timesheets.Find(id);
            var result = _context.Timesheets.Remove(entity).State;
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
            return _context.Timesheets.AsQueryable();
        }

        public TimeSheet GetById(int id)
        {
            return _context.Timesheets.Find(id);
        }

        public bool Update(TimeSheet timeSheet)
        {
            var result = _context.Timesheets.Update(timeSheet).State;
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