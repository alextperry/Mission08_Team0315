using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission08_Team0315.Models;

namespace Mission08_Team0315.Controllers
{
    // home controller that contains the backend code
    public class HomeController : Controller
    {
        private QuadrantContext _context;

        public HomeController(QuadrantContext temp) //constructor for Home controller
        {
            _context = temp;
        }


            // index view
            public IActionResult Index()
        {
            return View();
        }


        // quadrants view that lists out tasks into quadrants


        public IActionResult Quadrants()
        {
            var tasks = _context.Tasks
                .Include(x => x.Category)  // Include first
                .ToList();                 // Execute query after Include

            var task = _context.Tasks
                .Where(t => t.Completed == false || t.Completed == null) // Fetch only uncompleted tasks
                .ToList();


            return View(task);

        }


        // getting the db things necessary to add a task

        [HttpGet]
        public IActionResult AddTask()
        {
            ToDoListForm task = new ToDoListForm();


            ViewBag.QuadrantCategories = _context.QuadrantCategories

                .OrderBy(x => x.CategoryName)
                .ToList();

            ViewBag.Tasks = _context.Tasks
                .OrderBy(x => x.TaskName)
                .ToList();

            return View(task);
        }

        // posting the new task into the db

        [HttpPost]

        public IActionResult AddTask(ToDoListForm response)
        {

            ViewBag.QuadrantCategories = _context.QuadrantCategories

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


            ViewBag.QuadrantCategories = _context.QuadrantCategories

                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("AddTask", recordToEdit);
        }

        // post method to return an edited record to the db 

        [HttpPost]
        public IActionResult Edit(ToDoListForm updatedInfo)
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
        public IActionResult Delete(ToDoListForm task)
        {
            _context.Tasks.Remove(task);
            _context.SaveChanges();

            return RedirectToAction("Quadrants");
        }

    }
}
