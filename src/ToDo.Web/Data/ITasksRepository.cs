using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Web.Models;

namespace ToDo.Web.Data
{
    public interface ITasksRepository
    {
        Task<TaskItem> FindByIdAsync(int id);
        Task<List<TaskItem>> ListAsync();
        Task AddAsync(TaskItem task);
        Task UpdateAsync(TaskItem task);
        Task DeleteAsync(TaskItem task);
    }
}
