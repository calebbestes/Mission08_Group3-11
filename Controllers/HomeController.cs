using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Mission08_Group3_11.Models;

namespace Mission08_Group3_11.Controllers
{
    public class HomeController : Controller
    {
        private ITaskRepository _repo;

        public HomeController(ITaskRepository temp) // Constructor
        {
            _repo = temp;
        }

        public IActionResult Index()
        {
            return View(new Application());
        }

        [HttpGet]
        public IActionResult AddEditTask()
        {
            ViewBag.Categories = _repo.Categories.ToList();
                //.OrderBy(x => x.CategoryName)
                //.ToList();

            return View("AddEditTask", new Application());
        }

        [HttpPost]
        public IActionResult AddEditTask(Application response)
        {
            if (ModelState.IsValid)
            {
                _repo.AddTask(response); // Add record to the database

                return View("Confirmation", new Application());
            }
            else // Invalid data
            {
                ViewBag.Categories = _repo.Categories
                    .OrderBy(x => x.CategoryName)
                    .ToList();

                return View(response);
            }
        }

        public IActionResult Quadrants()
        {
            // Linq
            var all_tasks = _repo.ToDoList
                .ToList();

            return View("Quadrants", all_tasks);// all_tasks);
        }

        // Edit a task
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _repo.ToDoList
                .Single(x => x.TaskId == id);

            ViewBag.Categories = _repo.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("AddEditTask", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Application updatedInfo)
        {
            _repo.Update(updatedInfo);
            _repo.SaveChanges();

            return RedirectToAction("Quadrants");
        }

        // Delete a task
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _repo.ToDoList
                .Single(x => x.TaskId == id);

            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Application toDelete)
        {
            _repo.AddTask(toDelete);
            _repo.SaveChanges();

            return RedirectToAction("Quadrants");
        }
    }
}
