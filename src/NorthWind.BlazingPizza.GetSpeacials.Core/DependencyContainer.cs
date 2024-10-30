using NorthWind.BlazingPizza.GetSpeacials.Core.Cache;

namespace NorthWind.BlazingPizza.GetSpeacials.Core
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddGetSpecialCoreServices(this IServiceCollection services,
                                                               Action<GetSpecialsOptions> configure)
        {
            services.AddScoped<IGetSpecialInputPort, GetSpecialsInteractor>();
            services.AddScoped<IGetSpecialsOutputPort, GetSpecialPresenter>();
            services.AddScoped<IGetSpecialsController, GetSpecialsController>();
            services.AddSingleton<IGetSpecialsCache, GetSpecialsCache>();
            services.Configure(configure);
            return services;
        }
    }
}