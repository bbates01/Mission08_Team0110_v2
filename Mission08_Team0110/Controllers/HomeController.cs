using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
// using Mission08_Team0110.Models;
using Mission08_Team0110.Models;
namespace Mission08_Team0110.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Create()
    {
        return View();
    }
    public IActionResult Quadrants()
    {
        return View(new List<TaskItem>());
    }
}