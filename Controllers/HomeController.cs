using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
//using Mission08_Group3_11.Models;

namespace Mission08_Group3_11.Controllers
{
    public class HomeController : Controller
    {
        //private BlahContext _context;

        //public HomeController(BlahContext temp) // Constructor
        //{
        //    _context = temp;
        //}

        public IActionResult Index()
        {
            return View();
        }

        //[HttpGet]
        //public IActionResult TASKADDER()
        //{
        //    ViewBag.TABLENAMEquad = _context.TABLENAMEquad
        //        .OrderBy(x => x.COLUMNNAME)
        //        .ToList();

        //    return View("TASKADDER", new TASKMODEL());
        //}

        //[HttpPost]
        //public IActionResult TASKADDER(TASKMODEL response)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.TABLENAMEtasks.Add(response); // Add record to the database
        //        _context.SaveChanges();

        //        return View("Confirmation", response);
        //    }
        //    else // Invalid data
        //    {
        //        ViewBag.TABLENAMEquad = _context.TABKENAMEquad
        //            .OrderBy(x => x.COLUMNNAME)
        //            .ToList();

        //        return View(response);
        //    }
        //}

        //public IActionResult TASKS()
        //{
        //    // Linq
        //    var all_movies = _context.TABLENAMEtask
        //        .Include(x => x.TABLENAMEquad)
        //        .ToList();

        //    return View(all_movies);
        //}

        //// Edit a movie
        //[HttpGet]
        //public IActionResult Edit(int id)
        //{
        //    var recordToEdit = _context.Movies
        //        .Single(x => x.MovieId == id);

        //    ViewBag.Categories = _context.Categories
        //        .OrderBy(x => x.CategoryName)
        //        .ToList();

        //    return View("MovieAdder", recordToEdit);
        //}

        //[HttpPost]
        //public IActionResult Edit(MovieViewModel updatedInfo)
        //{
        //    _context.Update(updatedInfo);
        //    _context.SaveChanges();

        //    return RedirectToAction("Movies");
        //}

        //// Delete a movie
        //[HttpGet]
        //public IActionResult Delete(int id)
        //{
        //    var recordToDelete = _context.Movies
        //        .Single(x => x.MovieId == id);

        //    return View(recordToDelete);
        //}

        //[HttpPost]
        //public IActionResult Delete(MovieViewModel toDelete)
        //{
        //    _context.Movies.Remove(toDelete);
        //    _context.SaveChanges();

        //    return RedirectToAction("Movies");
        //}
    }
}
