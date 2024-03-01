using Microsoft.AspNetCore.Mvc;
using Mission8_Grp1_6.Models;
using System.Diagnostics;

namespace Mission8_Grp1_6.Controllers
{

    public class HomeController : Controller
    {
        private TaskContext _context;

        public HomeController(TaskContext temp)
        {
            _context = temp;
        }

        // [HttpGet]
        // public IActionResult Index()
        // {
        //     return View();
        // }
        //[HttpGet]
        //public IActionResult Index()
        //{
        //    // ViewBag.Tasks = _context.Tasks.ToList();
        //    var tasks = _context.Tasks
        //        .ToList();

        //    return View(tasks);
        //}


        [HttpGet]
        public IActionResult AddEdit()
        {
            ViewBag.Tasks = _context.Tasks.ToList();
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryID)
                .ToList();
            return View(new Mission8_Grp1_6.Models.Task());
        }

        [HttpPost]
        public IActionResult AddEdit(Mission8_Grp1_6.Models.Task response) //form -> AddEdit
        {
            ViewBag.Tasks = _context.Tasks.ToList();
            _context.Tasks.Add(response); //add record to database
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Index(Mission8_Grp1_6.Models.Task response)
        {
            ViewBag.Tasks = _context.Tasks.ToList();
            var tasks = _context.Tasks
                .ToList();

            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryID)
                .ToList();

            return View(tasks);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Tasks
                .Single(x => x.TaskID == id);
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryID)
                .ToList();

            ViewBag.Tasks = _context.Tasks.ToList();
            return View("AddEdit", recordToEdit); //addedit
        }

        [HttpPost]
        public IActionResult Edit(Mission8_Grp1_6.Models.Task updated)
        {
            _context.Update(updated);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            ViewBag.Tasks = _context.Tasks.ToList();
            var recordToDelete = _context.Tasks
                .Single(x => x.TaskID == id);

            return View("Confirmation", recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Mission8_Grp1_6.Models.Task deleted)
        {
            _context.Remove(deleted);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}