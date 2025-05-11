using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Interfaces;

public interface IDbContext
{
    DbSet<User> Users { get; set; }
    DbSet<UserRank> UserRanks { get; set; }
    DbSet<Author> Authors { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}