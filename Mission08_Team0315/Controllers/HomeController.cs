using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission08_Team0315.Models;

namespace Mission08_Team0315.Controllers
{
    // home controller that contains the backend code
    public class HomeController : Controller
    {
        private QuadrantContext _QuadrantContext;

        public HomeController(QuadrantContext temp) //constructor for Home controller
        {
            _quadrantContext = temp;
        }

        // index view
        public IActionResult Index()
        {
            return View();
        }

        // quadrants view that lists out tasks into quadrants
        public IActionResult Quadrants()
        {

            var task = _quadrantContext.Tasks
                .ToList()
                .Include(x => x.Category);


            return View(task);
        }

        // getting the db things necessary to add a task

        [HttpGet]
        public IActionResult AddTask()
        {
            Task task = new Task();

            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            ViewBag.Tasks = _context.Tasks
                .OrderBy(x => x.TaskName)
                .ToList();

            return View();
        }

        // posting the new task into the db

        [HttpPost]

        public IActionResult AddTask(Task response)
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            if (ModelState.IsValid)
            {
                _context.Tasks.Add(response); // whatever was passed this adds the record to the db 

                _context.SaveChanges();
                
                return View(response); // returns the view and the data to be passed to the db 
            }
            else // invalid data
            {
                return View(response);
            }
        }

        // get method for the edit page to get all records and create a viewbag

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Tasks // querying the db with Linq
                .Single(x => x.TaskId == id);

            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("AddTask", recordToEdit);
        }

        // post method to return an edited record to the db 

        [HttpPost]
        public IActionResult Edit(Task updatedInfo)
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();

            return RedirectToAction("Quadrants");
        }


        // getting the method to delete

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Tasks
                .Single(x => x.TaskId == id);

            return View("Delete", recordToDelete);
        }

        // posting the updated db without the record that was deleted

        [HttpPost]
        public IActionResult Delete(Task task)
        {
            _context.Tasks.Remove(task);
            _context.SaveChanges();

            return RedirectToAction("Quadrants");
        }


    }
}
