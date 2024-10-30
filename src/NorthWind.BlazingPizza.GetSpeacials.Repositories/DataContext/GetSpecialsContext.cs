namespace NorthWind.BlazingPizza.GetSpeacials.Repositories.DataContext
{
    public class GetSpecialsContext : DbContext
    {
        IOptions<GetSpecialsDBOptions> Options;

        

        public GetSpecialsContext(IOptions<GetSpecialsDBOptions> options)
        {
            Options = options;

            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(Options.Value.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PizzaSpecialConfiguration).Assembly);
        }

        public DbSet<PizzaSpecial> PizzaSpecial { get; set; }
    }
}