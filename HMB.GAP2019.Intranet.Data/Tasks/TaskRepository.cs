using HMB.GAP2019.Intranet.Core.Task;
using HMB.GAP2019.Intranet.Core.Tasks;
using HMB.GAP2019.Intranet.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HMB.GAP2019.Intranet.Data.Tasks
{
    public class TaskRepository : ITaskRepository
    {
        private readonly IntranetContext _context;
        public TaskRepository(IntranetContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public void Add(Task task)
        {
            _context.Task.Add(task);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public bool Delete(int id)
        {
            var currentTask = GetById(id);
            if(currentTask == null)
            {
                return false;
            }
            _context.Task.Remove(currentTask);
            return true;
        }

        public Core.Tasks.Task GetById(int id)
        {
            return _context.Task.Find(id);
        }

        public IEnumerable<Task> GetList()
        {
            return _context.Task.ToList();
        }

        public bool Update(Task task)
        {
            var existingTask = GetById(task.Id);
            if (existingTask == null)
            {
                return false;
            }
            existingTask.Name = task.Name;
            existingTask.IsNoteRequired = task.IsNoteRequired;

            _context.Task.Update(existingTask);
            return true;
        }
    }
}
