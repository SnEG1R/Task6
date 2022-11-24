using Microsoft.AspNetCore.SignalR;
using Task6.Application.CQs.Message.Commands.CreateMessage;

namespace Task6.Application.Hubs.Message;

public class ChatHub : Hub
{
    public async Task Send(string w)
    {
        var t = Context.ConnectionId;
        var a = Context.UserIdentifier;
        await Clients.All.SendAsync("Send", w); 
    }
}