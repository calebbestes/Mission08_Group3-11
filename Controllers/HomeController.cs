using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission08_Group3_11.Models;

namespace Mission08_Group3_11.Controllers
{
    public class HomeController : Controller
    {
        private ToDoListContext _context;

        public HomeController(ToDoListContext temp) // Constructor
        {
            _context = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddEditTask()
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("TASKADDER", new Application());
        }

        [HttpPost]
        public IActionResult AddEditTask(Application response)
        {
            if (ModelState.IsValid)
            {
                _context.ToDoList.Add(response); // Add record to the database
                _context.SaveChanges();

                return View("Quadrants", response);
            }
            else // Invalid data
            {
                ViewBag.Categories = _context.Categories
                    .OrderBy(x => x.CategoryName)
                    .ToList();

                return View(response);
            }
        }

        public IActionResult Quadrants()
        {
            // Linq
            var all_tasks = _context.ToDoList
                .Include(x => x.Category)
                .ToList();

            return View();// all_tasks);
        }

        // Edit a movie
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.ToDoList
                .Single(x => x.TaskId == id);

            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("AddEditTask", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(TASKSModel updatedInfo)
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();

            return RedirectToAction("Quadrants");
        }

        // Delete a movie
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.ToDoList
                .Single(x => x.TaskId == id);

            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(TASKSModel toDelete)
        {
            _context.ToDoList.Remove(toDelete);
            _context.SaveChanges();

            return RedirectToAction("Quadrants");
        }
    }
}
