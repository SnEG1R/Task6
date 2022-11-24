using MediatR;

namespace Task6.Application.CQs.Message.Commands.CreateMessage;

public class CreateMessageCommand : IRequest<ReturnMessageDto>
{
    public string RecipientName { get; set; }
    public string Header { get; set; }
    public string Body { get; set; }
}