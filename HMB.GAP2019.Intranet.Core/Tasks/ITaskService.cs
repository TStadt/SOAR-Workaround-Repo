using System;
using System.Collections.Generic;
using System.Text;

namespace HMB.GAP2019.Intranet.Core.Task
{
    public interface ITaskService
    {
        IEnumerable<Core.Tasks.Task> GetList();
        bool DeleteTask(int id);
        bool CreateTask(Core.Tasks.Task task);
        bool UpdateTask(Core.Tasks.Task task);
    }
}
