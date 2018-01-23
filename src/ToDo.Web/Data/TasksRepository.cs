using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDo.Web.Models;

namespace ToDo.Web.Data
{
    public class TasksRepository : ITasksRepository
    {
        private readonly TaskDbContext _db;

        public TasksRepository(TaskDbContext dbContext)
        {
            _db = dbContext;
        }

        public Task<TaskItem> FindByIdAsync(int id)
        {
            return _db.Tasks.Where(task => task.TaskId == id).FirstAsync();

        }

        public Task<List<TaskItem>> ListAsync()
        {
            return _db.Tasks.ToListAsync();
        }

        public Task AddAsync(TaskItem task)
        {
            _db.Tasks.Add(task);
            return _db.SaveChangesAsync();
        }

        public Task UpdateAsync(TaskItem task)
        {
            _db.Entry(task).State = EntityState.Modified;
            return _db.SaveChangesAsync();
        }

        public Task DeleteAsync(TaskItem task)
        {
            _db.Tasks.Remove(task);
            return _db.SaveChangesAsync();
        }
    }
}
