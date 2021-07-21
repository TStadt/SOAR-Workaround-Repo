using HMB.GAP2019.Intranet.Core.TimeEntry;
using HMB.GAP2019.Intranet.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HMB.GAP2019.Intranet.Data.TimeEntry
{
    public class TimeEntryRepository : ITimeEntryRepository
    {

        /* dependency injection */
        private readonly IntranetContext _context;

        public TimeEntryRepository(IntranetContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        public void Add(Core.TimeEntry.TimeEntry timeEntry)
        {
            _context.TimeEntry.Add(timeEntry);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public bool Delete(int id)
        {
            HMB.GAP2019.Intranet.Core.TimeEntry.TimeEntry entity = _context.TimeEntry.Find(id);
            var result = _context.TimeEntry.Remove(entity).State;
            if (result.Equals(EntityState.Deleted))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IQueryable<Core.TimeEntry.TimeEntry> GetAll()
        {
            return _context.TimeEntry.AsQueryable();
        }

        public Core.TimeEntry.TimeEntry GetById(int id)
        {
            return _context.TimeEntry.Find(id);
        }

        public bool Update(Core.TimeEntry.TimeEntry timeEntry)
        {
            var result = _context.TimeEntry.Update(timeEntry).State;
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
