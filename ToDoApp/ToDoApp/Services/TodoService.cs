using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Database;
using ToDoApp.Models.Entities;

namespace ToDoApp.Services
{
    public class TodoService
    {
        private ApplicationDbContext DbContext { get; }
        public Todo Task { get; set; }
        public TodoService(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
            //Add("Start the day", true);
            //Add("Finish H2 workshop");
            //Add("Finish JPA workshop");
            //Add("Create a CRUD project");
        }

        public List<Todo> FindAll()
        {
            return DbContext.Todos.ToList();
        }

        public void Add(string task, bool isUrgent)
        {
            Task = new Todo(task);
            Task.IsUrgent = isUrgent;
            DbContext.Todos.Add(Task);
            DbContext.SaveChanges();
        }

        public void Add(string task)
        {
            DbContext.Todos.Add(new Todo(task));
            DbContext.SaveChanges();
        }

        public Todo FindById(long id)
        {
            return DbContext.Todos.Find(id);
        }

        public void Delete(Todo todo)
        {
            DbContext.Remove(todo);
            DbContext.SaveChanges();
        }

        public void Change(long id, string task, bool urgent, bool done, long assignee)
        {
            Task = DbContext.Todos.Find(id);
            if (task != null)
            {
                Task.Title = task; 
            }
            Task.IsUrgent = urgent; 
            Task.IsDone = done;
            Task.AssignedId = assignee;
            DbContext.SaveChanges();
        }
    }
}
