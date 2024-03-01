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

        [HttpGet]
        public IActionResult AddEdit() //This action returns the AddEdit page and populates the form with the data from the database
        {
            ViewBag.Tasks = _repo.Tasks.ToList();
            ViewBag.Categories = _repo.Categories
                .OrderBy(x => x.CategoryID)
                .ToList();
            return View(new Mission8_Grp1_6.Models.Task());
        }

        [HttpPost]
        public IActionResult AddEdit(Mission8_Grp1_6.Models.Task response) //This Post method allows the user to add a task and saves it
        {
            ViewBag.Tasks = _repo.Tasks.ToList();
            _repo.AddTask(response); //add record to database
            return RedirectToAction("Index");
        }

        public IActionResult Index(Mission8_Grp1_6.Models.Task response) //This get method returns the home page and populates the quadrant with whatever is in the database.
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
        public IActionResult Edit(int id) //This Get Method populates the form with the correct task to enable the user to edit the record.
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
        public IActionResult Edit(Mission8_Grp1_6.Models.Task updated) //This method saves the edited version of the task and returns the home page.
        {
            _repo.UpdateTask(updated);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id) //This Get method retrieves a confirmation page for the deletion of a record
        {
            // ViewBag.Tasks = _repo.Tasks.ToList();
            var recordToDelete = _repo.Tasks
                .Single(x => x.TaskID == id);

            return View("Confirmation", recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Mission8_Grp1_6.Models.Task deleted) //This Post Method deletes a task from the database
        {
            _repo.RemoveTask(deleted);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Check(int id) //This method allows users to check off tasks so that they don't appear on the page.
        {
            var task = _repo.Tasks
                .Single(x => x.TaskID == id);

            task.Completed = true;
            _repo.UpdateTask(task);
            return RedirectToAction("Index");
        }
    }
}