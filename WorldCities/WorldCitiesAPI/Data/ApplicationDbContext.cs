using Microsoft.EntityFrameworkCore;
using WorldCitiesAPI.Data.Models;

namespace WorldCitiesAPI.Data;

public class ApplicationDbContext :DbContext
{
    public ApplicationDbContext(): base() {    }

    public ApplicationDbContext(DbContextOptions options) : base(options) { }

    public DbSet<City> Cities => Set<City>();
    public DbSet<Country> Countries => Set<Country>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // add the EntityTypeConfiguration classes
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(ApplicationDbContext).Assembly);
    }
}
