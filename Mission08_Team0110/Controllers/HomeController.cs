using Microsoft.AspNetCore.Mvc;
using Mission08_Team0110.Models;
using Microsoft.EntityFrameworkCore;


namespace Mission08_Team0110.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;

    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }
    
    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.Categories = _context.Categories
            .OrderBy(x => x.Name)
            .ToList();
        
        return View(new TaskItem());
    }

    [HttpPost]
    public IActionResult Create(TaskItem response)
    {
        if (ModelState.IsValid)
        {
            _context.Tasks.Add(response);
            _context.SaveChanges();
            
            return RedirectToAction("Quadrants");
        }
        else // invalid data entered
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.Name)
                .ToList();
            
            return View(response);
        }
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var recordToEdit = _context.Tasks
            .Single(x => x.TaskId == id);

        ViewBag.Categories = _context.Categories
            .OrderBy(x => x.Name)
            .ToList();
        
        return View("Create", recordToEdit);
    }

    [HttpPost]
    public IActionResult Edit(TaskItem updatedRecord)
    {
        if (ModelState.IsValid)
        {
            _context.Tasks.Update(updatedRecord);
            _context.SaveChanges();
            return RedirectToAction("Quadrants");
        }
        else
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(c => c.Name)
                .ToList();
            
            return View("Create", updatedRecord);
        }
    }
    public IActionResult Quadrants()
    {
        var incompleteTasks = _context.Tasks
            .Where(x => x.Completed == false)
            .Include(x => x.Category)
            .ToList();
        
        return View(incompleteTasks);
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var recordToDelete = _context.Tasks
            .Single(x => x.TaskId == id);

        _context.Tasks.Remove(recordToDelete);
        _context.SaveChanges();
        
        return RedirectToAction("Quadrants");
    }

    [HttpGet]
    public IActionResult MarkComplete(int id)
    {
        var recordToComplete = _context.Tasks
            .Single(x => x.TaskId == id);
        
        recordToComplete.Completed = true;
        _context.Tasks.Update(recordToComplete);
        _context.SaveChanges();
        
        return RedirectToAction("Quadrants");
    }
}