using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.Models.Entities
{
    public class ViewAssignee
    {
        public Assignee Asgn { get; set; }
        public List<Assignee> Assignees { get; set; }
        public Todo Todo { get; set; }
    }
}
