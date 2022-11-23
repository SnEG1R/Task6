using Microsoft.EntityFrameworkCore;
using Task6.Domain;

namespace Task6.Application.Interfaces;

public interface IUserDbContext
{
    DbSet<User> Users { get; set; }
    DbSet<Message> Messages { get; set; }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}