using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Task6.Application.CQs.Message.Commands.CreateMessage;
using Task6.Application.Interfaces;

namespace Task6.Application.Hubs.Message;

public class ChatHub : Hub
{
    private readonly IChatDbContext _chatDbContext;
    private readonly IMediator _mediator;

    public ChatHub(IChatDbContext chatDbContext, IMediator mediator)
    {
        _chatDbContext = chatDbContext;
        _mediator = mediator;
    }

    public async Task Send(CreateMessageCommand messageCommand)
    {
        var recipient = await _chatDbContext.Users
            .FirstOrDefaultAsync(u => u.Name == messageCommand.RecipientName);
        if (recipient == null)
            throw new NullReferenceException($"{nameof(recipient)} is null");

        var message = await _mediator.Send(messageCommand);

        await Clients.User(recipient.Name)
            .SendAsync("GetMessage", message);
    }
}