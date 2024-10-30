using NorthWind.BlazingPizza.ViewModels.GetSpecials;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddViewModelsServices(this IServiceCollection services)
    {

        services.AddScoped<GetSpecialViewModel>();
        return services;
    }
}
