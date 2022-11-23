using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Task6.Application.CQs.User.Commands.Login;
using Task6.Web.Models;

namespace Task6.Web.Controllers;

public class LoginController : Controller
{
    private readonly IMediator _mediator;

    public LoginController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Index(UserVm model)
    {
        var command = new LoginCommand()
        {
            Name = model.Name
        };
        var identity = await _mediator.Send(command);
        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, 
            new ClaimsPrincipal(identity));
        
        return RedirectToAction("Index", "Chat");
    }
}