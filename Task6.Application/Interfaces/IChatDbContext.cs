using Microsoft.EntityFrameworkCore;
using Task6.Domain;

namespace Task6.Application.Interfaces;

public interface IChatDbContext
{
    DbSet<User> Users { get; set; }
    DbSet<Message> Messages { get; set; }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}