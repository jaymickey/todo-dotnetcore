using System.Collections.Generic;
using ToDo.Web.Models;

namespace ToDo.Web.ViewModels
{
    public class IndexViewModel
    {
        public List<TaskItem> AllTasks { get; set; }
        public NewTaskViewModel NewTask { get; set; }
    }
}
