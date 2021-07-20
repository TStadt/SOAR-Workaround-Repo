using System;
using HMB.GAP2019.Intranet.Core.Tasks;
using HMB.GAP2019.Intranet.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HMB.GAP2019.Intranet.Data.Tasks
{
    public class TaskRepository : ITaskRepository
    {
        /* dependency injection */
        private readonly IntranetContext _context;
        public TaskRepository(IntranetContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(TaskEntry task)
        {
            _context.Tasks.Add(task);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public bool Delete(int id)
        {
            TaskEntry entity = _context.Tasks.Find(id);
            var result = _context.Tasks.Remove(entity).State;
            if (result.Equals(EntityState.Deleted))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public System.Linq.IQueryable<TaskEntry> GetAll()
        {
            return _context.Tasks.AsQueryable();
        }

        public TaskEntry GetById(int id)
        {
            return _context.Tasks.Find(id);
        }

        public bool Update(TaskEntry task)
        {
            var result = _context.Tasks.Update(task).State;
            if (result.Equals(EntityState.Modified))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
