using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Models.Entities;
using ToDoApp.Services;

namespace ToDoApp.Controllers
{
    [Route("assignee")]
    public class AssigneeController : Controller
    {
        AssigneeService AS { get; set; }
        public AssigneeController(AssigneeService assigneeService)
        {
            AS = assigneeService;
        }
        public IActionResult Index()
        {
            ViewAssignee model = new ViewAssignee();
            model.Assignees = AS.FindAll();
            return View(model);
        }

        [HttpPost("edit")]
        public IActionResult Edit(long id)
        {
            return View(id);
        }

        [HttpPost("change")]
        public IActionResult Change(long id, string name, string email)
        {
            AS.Change(id, name, email);
            return RedirectToAction("Index");
        }

        [HttpPost("delete")]
        public IActionResult Delete(long id)
        {
            AS.Delete(AS.FindById(id));
            return RedirectToAction("Index");
        }

        [HttpGet("new")]
        public IActionResult NewAssignee()
        {
            return View();
        }

        [HttpPost("add")]
        public IActionResult Add(string name, string email)
        {
            AS.Add(name, email);
            return RedirectToAction("Index");
        }
    }
}
