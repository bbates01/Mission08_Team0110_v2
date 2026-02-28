using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
// using Mission08_Team0110_v2.Models;

namespace Mission08_Team0110_v2.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}