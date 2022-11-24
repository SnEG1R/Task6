using MediatR;
using Microsoft.EntityFrameworkCore;
using Task6.Application.Interfaces;

namespace Task6.Application.CQs.Message.Commands.CreateMessage;

public class CreateMessageCommandHandler : IRequestHandler<CreateMessageCommand, Unit>
{
    private readonly IChatDbContext _chatDbContext;

    public CreateMessageCommandHandler(IChatDbContext chatDbContext)
    {
        _chatDbContext = chatDbContext;
    }

    public async Task<Unit> Handle(CreateMessageCommand request,
        CancellationToken cancellationToken)
    {
        var user = await _chatDbContext.Users
            .FirstOrDefaultAsync(u => u.Name
                                      == request.UserName, cancellationToken);
        if (user is null)
            throw new NullReferenceException($"{nameof(user)} is null");

        var message = new Domain.Message()
        {
            // Owner = user,
            Header = request.Header,
            Body = request.Body,
            DateSend = DateTime.UtcNow
        };

        await _chatDbContext.Messages.AddAsync(message, cancellationToken);
        await _chatDbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}