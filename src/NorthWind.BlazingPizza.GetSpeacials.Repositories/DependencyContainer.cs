namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddRepositoryServices(
                                                    this IServiceCollection services,
                                                    Action<GetSpecialsDBOptions> configureGetSpecialsDBOptions)
        {

            services.AddDbContext<GetSpecialsContext>();
            services.AddScoped<IGetSpecialsRepository, GetSpeacialsRepository>();
            services.Configure(configureGetSpecialsDBOptions);
            return services;
        }
        public static IHost InitializeDb(this IHost app)
        {
            using IServiceScope scope = app.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<GetSpecialsContext>();

            context.Database.EnsureCreated();
            return app;
        }
    }
}