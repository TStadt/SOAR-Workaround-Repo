using System;
using System.Collections.Generic;
using System.Text;

namespace HMB.GAP2019.Intranet.Core.Timesheet
{
    public interface ITimeSheetRepository
    {
        void Add(TimeSheet timeSheet);
        bool Update(TimeSheet timeSheet);
        bool Delete(int id);
        void Commit();
        TimeSheet GetByEmployee(int id, DateTime dayOfWeek);
        TimeSheet GetById(int id);
    }
}
