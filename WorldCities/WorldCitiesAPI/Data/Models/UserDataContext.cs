using Microsoft.EntityFrameworkCore;

namespace WorldCitiesAPI.Data.Models;

public class UserDataContext : DbContext
{
    public DbSet<User>? Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }
}

public class User
{
    public int UID { get; set; }
    public string? Name { get; set; }
}
