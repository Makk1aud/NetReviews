using DataAccess;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace NetReviews.Extensions;

public static class ServiceCollectionsExtensions
{
    public static IServiceCollection AddNetReviewsDbContext(this IServiceCollection services, ConfigurationManager configurationManager)
    {
        return services.AddDbContext<IDbContext, NetReviewsContext>(
            opt => opt.UseNpgsql(configurationManager.GetConnectionString("DefaultConnection")));
    }
}   