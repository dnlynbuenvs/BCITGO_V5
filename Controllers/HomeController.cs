using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BCITGO_FINAL.Models;

namespace BCITGO_FINAL.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    // Constructor - ensures that logging is available within this controller, which may be useful for debugging or tracking the application behavior.
    // No relation to _Layout.cshtml
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    // Index action method - returns the Index view - this is a key-value pair that stores the page title you want to display.
    public IActionResult Index()
    {
        ViewData["Title"] = "Home";  // Set the page title here - ADDED
        return View();
    }

    // Privacy action method - returns the Privacy view - this is a key-value pair that stores the page title you want to display.
    // This title will be used when the Privacy view is loaded.
    public IActionResult Privacy()
    {
        ViewData["Title"] = "Privacy";  // Set the page title here - ADDED
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
