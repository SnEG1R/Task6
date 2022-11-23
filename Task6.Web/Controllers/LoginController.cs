using Microsoft.AspNetCore.Mvc;
using Task6.Web.Models;

namespace Task6.Web.Controllers;

public class LoginController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Index(UserVm model)
    {
        return View();
    }
}