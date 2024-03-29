using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PlayPals.Models;

namespace PlayPals.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Login()
    {
        return View();
    }

     public IActionResult Signup()
    {
        return View();
    }

    public IActionResult ProfileAvatar()
    {
        return View();
    }

    public IActionResult Activities()
    {
        return View();
    }

    public IActionResult MatchingBrowser()
    {
        return View(); 
    }

    public IActionResult Chatbox()
    {
        return View(); 
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
   
}


