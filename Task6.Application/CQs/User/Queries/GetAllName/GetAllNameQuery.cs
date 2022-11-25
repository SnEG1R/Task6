using MediatR;

namespace Task6.Application.CQs.User.Queries.GetAllName;

public class GetAllNameQuery : IRequest<IEnumerable<string>>
{
}