using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.Models.Entities
{
    public class Todo
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public bool IsUrgent { get; set; }
        public bool IsDone { get; set; }
        public long? AssignedId { get; set; }
        public Assignee Assignee { get; set; }
        public Todo(string title)
        {
            Title = title;
            IsUrgent = false;
            IsDone = false;
        }
    }
}
