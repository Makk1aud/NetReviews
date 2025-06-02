using DataAccess;
using DataAccess.Interfaces;
using Domain.Implementation;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace NetReviews.Extensions;

public static class ServiceCollectionsExtensions
{
    public static IServiceCollection AddNetReviewsDbContext(this IServiceCollection services, ConfigurationManager configurationManager)
    {
        return services.AddDbContext<IDbContext, NetReviewsContext>(
            opt => opt.UseNpgsql(configurationManager.GetConnectionString("DefaultConnection")));
    }

    public static void EnsureDbCreated(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<NetReviewsContext>();
        dbContext.Database.Migrate();
    }
    
    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        services.AddScoped<IUserDomainService, UserDomainService>();
        return services;
    }
}   