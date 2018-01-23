using System;
using System.ComponentModel.DataAnnotations;

namespace ToDo.Web.Models
{
    public class TaskItem
    {
        [Key]
        public int TaskId { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public bool IsCompleted { get; set; }
    }
}
