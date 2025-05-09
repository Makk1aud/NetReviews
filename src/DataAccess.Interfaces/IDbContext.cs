using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Interfaces;

public interface IDbContext
{
    DbSet<User> Users { get; set; }
    DbSet<UserRank> UserRanks { get; set; }
}