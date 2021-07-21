using System.Linq;

namespace HMB.GAP2019.Intranet.Core.Tasks
{
    public interface ITaskRepository
    {
        void Add(TaskEntry task);
        bool Update(TaskEntry task);
        bool Delete(int id);
        TaskEntry GetById(int id);
        IQueryable<TaskEntry> GetAll();
        void Commit();
    }
}
