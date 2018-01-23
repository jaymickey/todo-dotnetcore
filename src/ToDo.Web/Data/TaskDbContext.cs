using Microsoft.EntityFrameworkCore;
using ToDo.Web.Models;

namespace ToDo.Web.Data
{

    public class TaskDbContext : DbContext {
        public TaskDbContext (DbContextOptions<TaskDbContext> options)
            : base(options)
        {
        }

        public DbSet<TaskItem> Tasks { get; set; }
    }

}
