using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Task6.Application.Interfaces;

namespace Task6.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());

        return services;
    }
}