using NorthWind.BlazingPizza.GetSpeacials.Core;
using NorthWind.BlazingPizza.GetSpeacials.Repositories.options;
using NothWind.BlazingPizza.GetSpecials.BusinnesObjects.Options;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddGetSpecialMainServices(this IServiceCollection services,
                                                                   Action<GetSpecialsOptions> configureSpecialOptions,
                                                                   Action<GetSpecialsDBOptions> configureDbOptions)
        {

            services.AddGetSpecialCoreServices(configureSpecialOptions);
            services.AddRepositoryServices(configureDbOptions);
            return services;
        }
    }
}
// Es recomendable cuando tenemos varios servicios