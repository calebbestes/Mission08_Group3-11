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
            var importantData = _repo.Categories;

            var evenMoreImportantData = _repo.ToDoList;

            return View(importantData); //this might be wrong!
        }
        [HttpPost]
        public IActionResult Index(Application m)
        {
            _repo.DeleteApplication(m);
            return View("AddEditTask"); //not sure
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
                _repo.ToDoList.Add(response); // Add record to the database
                _repo.SaveChanges();

                return View("Confirmation", response);
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
            var all_tasks = _context.ToDoList
                .ToList();

            return View("Quadrants", all_tasks);// all_tasks);
        }

        // Edit a task
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
        public IActionResult Edit(Application updatedInfo)
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();

            return RedirectToAction("Quadrants");
        }

        // Delete a task
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.ToDoList
                .Single(x => x.TaskId == id);

            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Application toDelete)
        {
            _context.ToDoList.Remove(toDelete);
            _context.SaveChanges();

            return RedirectToAction("Quadrants");
        }
    }
}
