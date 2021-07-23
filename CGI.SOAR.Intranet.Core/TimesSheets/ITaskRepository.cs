using System.Linq;

namespace CGI.SOAR.Intranet.Core.TimesSheets
{
    public interface ITaskRepository
    {
        IQueryable<Task> GetAll();
    }
}