using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.Models.Entities
{
    public class ViewTodo
    {
        public Todo Td { get; set; }
        public List<Todo> Todos { get; set; }

        public ViewTodo()
        {
            Todos = new List<Todo>();
        }
    }
}
