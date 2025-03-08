using Microsoft.Extensions.DependencyInjection;

namespace dctrly.Application.Framework;

public static class RegisterMediatR
{
    public static IServiceCollection RegisterMediatRHandlers(this IServiceCollection services)
    {
        return services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(typeof(RegisterMediatR).Assembly));
    }
}