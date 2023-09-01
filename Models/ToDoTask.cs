using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using ToDoList.Enums;

namespace ToDoList.Models
{
    public class ToDoTask
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }

        public bool IsCompleted { get; set; }

        public TaskStatus Status { get; set; }

        [Required(ErrorMessage = "Due Date is required.")]
        [Column(TypeName = "datetime2")]
        public DateTime DueDate { get; set; }

        public ApplicationUser User { get; set; }
    }
}