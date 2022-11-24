using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Task6.Application.Interfaces;

namespace Task6.Application.CQs.Message.Commands.CreateMessage;

public class CreateMessageCommandHandler 
    : IRequestHandler<CreateMessageCommand, ReturnMessageDto>
{
    private readonly IChatDbContext _chatDbContext;
    private readonly IMapper _mapper;

    public CreateMessageCommandHandler(IChatDbContext chatDbContext, IMapper mapper)
    {
        _chatDbContext = chatDbContext;
        _mapper = mapper;
    }

    public async Task<ReturnMessageDto> Handle(CreateMessageCommand request,
        CancellationToken cancellationToken)
    {
        var user = await _chatDbContext.Users
            .FirstOrDefaultAsync(u => u.Name
                                      == request.RecipientName, cancellationToken);
        if (user is null)
            throw new NullReferenceException($"{nameof(user)} is null");

        var message = new Domain.Message()
        {
            Owner = user,
            Header = request.Header,
            Body = request.Body,
            DateSend = DateTime.Now,
            RecipientName = request.RecipientName
        };

        await _chatDbContext.Messages.AddAsync(message, cancellationToken);
        await _chatDbContext.SaveChangesAsync(cancellationToken);

        return _mapper.Map<ReturnMessageDto>(message);
    }
}