using dctrly.Infrastructure.Data.Interfaces;
using dctrly.Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace dctrly.Infrastructure.Framework;

public static class RepositoryInjection
{
    public static void InjectRepositories(this IServiceCollection service)
    {
        service.AddScoped<IEventRepository, EventRepository>();
    }
}