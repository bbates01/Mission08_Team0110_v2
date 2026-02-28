using Microsoft.AspNetCore.Mvc;
using Mission08_Team0110.Models;

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
    public IActionResult Quadrants()
    {
        return View();
    }
}