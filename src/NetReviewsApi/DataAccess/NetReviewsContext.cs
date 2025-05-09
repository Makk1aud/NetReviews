using DataAccess.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class NetReviewsContext : DbContext, IDbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<UserRank> UserRanks { get; set; }

    public NetReviewsContext(DbContextOptions<NetReviewsContext> options) 
        : base(options) { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Configure Users table
        modelBuilder.Entity<User>().ToTable("Users");

        modelBuilder.Entity<User>().HasKey(x => x.UserId);
        
        modelBuilder.Entity<User>().Property(x => x.Nickname)
            .HasMaxLength(25)
            .IsRequired();

        modelBuilder.Entity<User>().Property(x => x.Email)
            .HasMaxLength(30)
            .IsRequired();
        
        modelBuilder.Entity<User>().Property(x => x.Password)
            .HasMaxLength(20)
            .IsRequired();
        
        modelBuilder.Entity<User>()
            .HasOne(x => x.UserRank)
            .WithMany(v => v.Users)
            .HasForeignKey(x => x.UserRankId);
        
        //Configure UserRank table
        modelBuilder.Entity<UserRank>().ToTable("UserRanks");
        
        modelBuilder.Entity<UserRank>().HasKey(x => x.UserRankId);
        
        modelBuilder.Entity<UserRank>()
            .Property(x => x.Title)
            .HasMaxLength(30)
            .IsRequired();
        
        modelBuilder.Entity<UserRank>()
            .Property(x => x.Description)
            .HasMaxLength(100)
            .IsRequired();
    }
}