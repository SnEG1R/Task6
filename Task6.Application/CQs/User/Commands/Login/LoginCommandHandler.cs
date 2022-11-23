using System.Security.Claims;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Task6.Application.Interfaces;

namespace Task6.Application.CQs.User.Commands.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, ClaimsIdentity>
{
    private readonly IChatDbContext _chatDbContext;

    public LoginCommandHandler(IChatDbContext chatDbContext)
    {
        _chatDbContext = chatDbContext;
    }

    public async Task<ClaimsIdentity> Handle(LoginCommand request,
        CancellationToken cancellationToken)
    {
        var user = await _chatDbContext.Users
            .FirstOrDefaultAsync(u => u.Name == request.Name,
                cancellationToken: cancellationToken);
        
        if (user is null)
        {
            user = new Domain.User()
            {
                Name = request.Name
            };

            await _chatDbContext.Users.AddAsync(user, cancellationToken);
            await _chatDbContext.SaveChangesAsync(cancellationToken);
        }
        
        var claims = new List<Claim>
        {
            new(ClaimsIdentity.DefaultNameClaimType, user.Name),
        };
        
        var identity = new ClaimsIdentity(claims, "ApplicationCookie", 
            ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

        return identity;
    }
}