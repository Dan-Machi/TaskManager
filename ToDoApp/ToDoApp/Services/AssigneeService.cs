using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Database;
using ToDoApp.Models.Entities;

namespace ToDoApp.Services
{
    public class AssigneeService
    {
        private ApplicationDbContext DbContext { get; }
        public Assignee Asgne{ get; set; }
        public AssigneeService(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public List<Assignee> FindAll()
        {
            return DbContext.Assignees.ToList();
        }
        public void Add(string name, string email)
        {
            Asgne = new Assignee(name);
            Asgne.Email = email;
            DbContext.Assignees.Add(Asgne);
            DbContext.SaveChanges();
        }

        public void Add(string name)
        {
            DbContext.Assignees.Add(new Assignee(name));
            DbContext.SaveChanges();
        }

        public Assignee FindById(long id)
        {
            return DbContext.Assignees.Find(id);
        }

        public void Delete(Assignee asgne)
        {
            DbContext.Remove(asgne);
            DbContext.SaveChanges();
        }

        public void Change(long id, string name, string email)
        {
            Asgne = DbContext.Assignees.Find(id);
            Asgne.Name = name;
            Asgne.Email = email;
            DbContext.SaveChanges();
        }

        public void AddTodo(long id, Todo todo)
        {
            DbContext.Assignees.Find(id).Todos.Add(todo);
            DbContext.SaveChanges();
        }
    }
}
