using NorthWind.BlazingPizza.Proxies;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddProxiesServices(this IServiceCollection services,
        Action<HttpClient> configureGetSpecialsProxy)
    {
        services.AddHttpClient<GetSpeacialsProxy>(configureGetSpecialsProxy);

        return services;
    }
}
