using System;
using CGI.SOAR.Intranet.Core.Authentication;

namespace CGI.SOAR.Intranet.Core.TimesSheets
{
    public interface ITimeSheetRepository
    {
        TimeSheet GetByEmployeeAndStartOfWeek(Employee employee, DateTime startOfWeek);
        void Submit(TimeSheet sheet);
    }
}
