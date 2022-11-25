using MediatR;
using Task6.Application.Interfaces;

namespace Task6.Application.CQs.User.Queries.GetAllName;

public class GetAllNameQueryHandler 
    : IRequestHandler<GetAllNameQuery, IEnumerable<string>>
{
    private readonly IChatDbContext _chatDbContext;

    public GetAllNameQueryHandler(IChatDbContext chatDbContext)
    {
        _chatDbContext = chatDbContext;
    }

    public Task<IEnumerable<string>> Handle(GetAllNameQuery request, 
        CancellationToken cancellationToken)
    {
        var names = _chatDbContext.Users
            .Select(u => u.Name)
            .ToList();

        return Task.FromResult<IEnumerable<string>>(names);
    }
}