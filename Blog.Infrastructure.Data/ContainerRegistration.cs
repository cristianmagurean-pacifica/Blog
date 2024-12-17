using Blog.Domain.Interfaces;
using Blog.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Blog.Infrastructure.Data;
public static class ContainerRegistration
{
    public static void RegisterInfrastructureData(this IServiceCollection services, string dbConnectionString)
    {
        services.AddDbContext<BlogDbContext>(options =>
        {
            options.EnableSensitiveDataLogging();
            options.UseSqlServer(dbConnectionString, builder =>
            {
                builder.MigrationsAssembly("Blog.Infrastructure.Data");
            });
        });

        services.AddScoped<IBlogPostRepository, BlogPostRepository>();
    }
}