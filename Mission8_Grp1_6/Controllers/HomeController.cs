using Microsoft.AspNetCore.Mvc;
using Mission8_Grp1_6.Models;
using System.Diagnostics;

namespace Mission8_Grp1_6.Controllers
{

    public class HomeController : Controller
    {
        private ITaskRepository _repo;

        public HomeController(ITaskRepository temp)
        {
            _repo = temp;
        }
        public IActionResult Index(Mission8_Grp1_6.Models.Task response)
        {
            // ViewBag.Tasks = _repo.Tasks.ToList();
            var tasks = _repo.Tasks
                .ToList();

            ViewBag.Categories = _repo.Categories
                .OrderBy(x => x.CategoryID)
                .ToList();

            return View(tasks);
        }

        [HttpGet]
        public IActionResult AddEdit()
        {
            // ViewBag.Tasks = _repo.Tasks.ToList();
            ViewBag.Categories = _repo.Categories
                .OrderBy(x => x.CategoryID)
                .ToList();
            return View(new Mission8_Grp1_6.Models.Task());
        }

        [HttpPost]
        public IActionResult AddEdit(Mission8_Grp1_6.Models.Task response) //form -> AddEdit
        {
            // ViewBag.Tasks = _repo.Tasks.ToList();
            _repo.AddTask(response); //add record to database
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _repo.Tasks
                .Single(x => x.TaskID == id);
            ViewBag.Categories = _repo.Categories
                .OrderBy(x => x.CategoryID)
                .ToList();

            // ViewBag.Tasks = _repo.Tasks.ToList();
            return View("AddEdit", recordToEdit); //addedit
        }

        [HttpPost]
        public IActionResult Edit(Mission8_Grp1_6.Models.Task updated)
        {
            _repo.UpdateTask(updated);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            // ViewBag.Tasks = _repo.Tasks.ToList();
            var recordToDelete = _repo.Tasks
                .Single(x => x.TaskID == id);

            return View("Confirmation", recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Mission8_Grp1_6.Models.Task deleted)
        {
            _repo.RemoveTask(deleted);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Check(int id)
        {
            var task = _repo.Tasks
                .Single(x => x.TaskID == id);

            task.Completed = true;
            _repo.UpdateTask(task);
            return RedirectToAction("Index");
        }
    }
}