using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Task6.Application.Interfaces;

namespace Task6.Application.CQs.Message.Queries.GetMessagesUser;

public class GetMessagesUserHandler : IRequestHandler<GetMessagesUser, MessageVm>
{
    private readonly IChatDbContext _chatDbContext;
    private readonly IMapper _mapper;

    public GetMessagesUserHandler(IChatDbContext chatDbContext, IMapper mapper)
    {
        _chatDbContext = chatDbContext;
        _mapper = mapper;
    }

    public Task<MessageVm> Handle(GetMessagesUser request,
        CancellationToken cancellationToken)
    {
        var messages = _chatDbContext.Messages
            .Where(m => m.RecipientName == request.UserName)
            .ProjectTo<MessageDto>(_mapper.ConfigurationProvider)
            .OrderByDescending(m => m.DateSend);

        return Task.FromResult(new MessageVm() { Messages = messages });
    }
}