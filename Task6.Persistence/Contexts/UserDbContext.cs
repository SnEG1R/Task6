using Microsoft.EntityFrameworkCore;
using Task6.Application.Interfaces;
using Task6.Domain;

namespace Task6.Persistence.Contexts;

public sealed class UserDbContext : DbContext, IUserDbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Message> Messages { get; set; }

    public UserDbContext(DbContextOptions<UserDbContext> options) 
        : base(options)
    {
        Database.EnsureCreated();
    }
}