using System;
using System.Collections.Generic;
using System.Text;

namespace HMB.GAP2019.Intranet.Core.Tasks
{
    public interface ITaskEntryService
    {
        bool CreateTaskEntry(TaskEntry taskEntry);
        bool UpdateTaskEntry(TaskEntry taskEntry);
        bool RemoveTaskEntry(int id);
        TaskEntry GetTaskEntry(int id);
    }
}
