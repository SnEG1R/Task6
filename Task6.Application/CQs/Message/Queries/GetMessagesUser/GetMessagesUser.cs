using MediatR;

namespace Task6.Application.CQs.Message.Queries.GetMessagesUser;

public class GetMessagesUser : IRequest<MessageVm>
{
    public string UserName { get; set; }
}