using System;
using System.Collections.Generic;
using System.Text;

namespace HMB.GAP2019.Intranet.Core.Task
{
    public interface ITaskRepository
    {
        void Add(Core.Tasks.Task task);
        bool Update(Core.Tasks.Task task);
        bool Delete(int id);
        void Commit();
        IEnumerable<Tasks.Task> GetList();
        Core.Tasks.Task GetById(int id);
    }
}
