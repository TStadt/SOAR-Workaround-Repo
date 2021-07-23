using System.Linq;
using CGI.SOAR.Intranet.Core.TimesSheets;
using CGI.SOAR.Intranet.Data.Contexts;

namespace CGI.SOAR.Intranet.Data.TimeSheets
{
    public class TaskRepository : ITaskRepository
    {
        private readonly IntranetContext _context;

        public TaskRepository(IntranetContext context)
        {
            _context = context;
        }

        public IQueryable<Task> GetAll() => _context.Tasks;
    }
}
