using Microsoft.Extensions.DependencyInjection;

namespace Blog.Application;
public static class ContainerRegistration
{
    public static void RegisterApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
        });
    }
}
