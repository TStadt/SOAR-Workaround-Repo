using HMB.GAP2019.Intranet.Core.TimeEntries;
using HMB.GAP2019.Intranet.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HMB.GAP2019.Intranet.Data.TimeEntries
{
    public class TimeEntryRepository : ITimeEntryRepository
    {

        /* dependency injection */
        private readonly IntranetContext _context;

        public TimeEntryRepository(IntranetContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        public void Add(TimeEntry timeEntry)
        {
            _context.TimeEntries.Add(timeEntry);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public bool Delete(int id)
        {
            TimeEntry entity = _context.TimeEntries.Find(id);
            var result = _context.TimeEntries.Remove(entity).State;
            if (result.Equals(EntityState.Deleted))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IQueryable<TimeEntry> GetAll()
        {
            return _context.TimeEntries.AsQueryable();
        }

        public TimeEntry GetById(int id)
        {
            return _context.TimeEntries.Find(id);
        }

        public bool Update(TimeEntry timeEntry)
        {
            var result = _context.TimeEntries.Update(timeEntry).State;
            if (result.Equals(EntityState.Modified))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        void ITimeEntryRepository.Add(TimeEntry timeEntry)
        {
            throw new NotImplementedException();
        }

        IQueryable<TimeEntry> ITimeEntryRepository.GetAll()
        {
            throw new NotImplementedException();
        }

        TimeEntry ITimeEntryRepository.GetById(int id)
        {
            throw new NotImplementedException();
        }

        bool ITimeEntryRepository.Update(TimeEntry timeEntry)
        {
            throw new NotImplementedException();
        }
    }
}
