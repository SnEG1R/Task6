using Microsoft.AspNetCore.Mvc;

namespace Task6.Web.Controllers;

public class ChatController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}