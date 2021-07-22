using System.Linq;

namespace HMB.GAP2019.Intranet.Core.TimeEntries
{
    public interface ITimeEntryRepository
    {
        void Add(TimeEntry timeEntry);
        bool Update(TimeEntry timeEntry);
        bool Delete(int id);
        TimeEntry GetById(int id);
        IQueryable<TimeEntry> GetAll();
        void Commit();
    }
}
