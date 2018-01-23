using System.ComponentModel.DataAnnotations;

namespace ToDo.Web.ViewModels
{
    public class NewTaskViewModel
    {
        [Required]
        [Display(Name = "New Task:")]
        public string Description { get; set; }
    }
}
