using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Models.Entities;
using ToDoApp.Services;

namespace ToDoApp.Controllers
{
    [Route("todo")]
    public class TodoController : Controller
    {
        public TodoService TS { get; set; }
        public AssigneeService AS { get; set; }
        public Todo TD { get; set; }
        public TodoController(TodoService todoService, AssigneeService assigneeService)
        {
            TS = todoService;
            AS = assigneeService;
        }

        [HttpGet("list")]
        [HttpGet("")]
        public IActionResult List()
        {
            ViewTodo model = new ViewTodo();
            model.Todos = TS.FindAll();
            return View(model);
        }

        [HttpGet("new")]
        public IActionResult NewTask()
        {
            return View();
        }

        [HttpPost("add")]
        public IActionResult Add(string task, bool isUrgent)
        {
            TS.Add(task, isUrgent);
            return RedirectToAction("List");
        }

        [HttpPost("delete")]
        public IActionResult Delete(long id)
        {
            TS.Delete(TS.FindById(id));
            return RedirectToAction("List");
        }

        [HttpPost("edit")]
        public IActionResult Edit(long id)
        {
            ViewAssignee model = new ViewAssignee();
            model.Todo = TS.FindById(id);
            model.Assignees = AS.FindAll();
            return View(model);
        }

        [HttpPost("change")]
        public IActionResult Change(long id, string task, bool urgent, bool done, long assignee)
        {
            TS.Change(id, task, urgent, done, assignee);
            AS.AddTodo(assignee, TS.FindById(id));
            return RedirectToAction("List");
        }

        [HttpPost("find")]
        public IActionResult Find(string word)
        {
            ViewTodo model = new ViewTodo();
            model.Todos = TS.FindAll().Where(x => x.Title.Contains(word)).ToList();
            return View("List", model);
        }
    }
}
