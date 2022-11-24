using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Task6.Application.CQs.Message.Queries.GetMessagesUser;
using Task6.Application.CQs.User.Queries.GetAllName;

namespace Task6.Web.Controllers;

[Authorize]
public class ChatController : Controller
{
    private readonly IMediator _mediator;

    public ChatController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var userName = User.FindFirst(ClaimTypes.Name)!.Value;
        var query = new GetMessagesUser() { UserName = userName };

        var vm = await _mediator.Send(query);

        return View(vm.Messages);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllName()
    {
        var query = new GetAllNameQuery();
        var names = await _mediator.Send(query);

        return Ok(names);
    }
}