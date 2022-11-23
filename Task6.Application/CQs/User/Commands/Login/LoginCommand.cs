using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Task6.Application.CQs.User.Commands.Login;

public class LoginCommand : IRequest<ClaimsIdentity>
{
    public string Name { get; set; }
}