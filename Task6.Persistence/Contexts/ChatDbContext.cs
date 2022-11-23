using Microsoft.EntityFrameworkCore;
using Task6.Application.Interfaces;
using Task6.Domain;

namespace Task6.Persistence.Contexts;

public sealed class ChatDbContext : DbContext, IChatDbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Message> Messages { get; set; }

    public ChatDbContext(DbContextOptions<ChatDbContext> options) 
        : base(options)
    {
        Database.EnsureCreated();
    }
}