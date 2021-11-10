using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.Models.Entities
{
    public class Assignee
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public List<Todo> Todos { get; set; }

        public Assignee(string name)
        {
            Name = name;
        }
    }
}
