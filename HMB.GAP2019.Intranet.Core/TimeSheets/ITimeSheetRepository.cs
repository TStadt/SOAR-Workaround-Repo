using System.Linq;

namespace HMB.GAP2019.Intranet.Core.TimeSheets
{
    public interface ITimeSheetRepository
    {
        void Add(TimeSheet timeSheet);
        bool Update(TimeSheet timeSheet);
        bool Delete(int id);
        TimeSheet GetById(int id);
        IQueryable<TimeSheet> GetAll();
        void Commit();
    }
}