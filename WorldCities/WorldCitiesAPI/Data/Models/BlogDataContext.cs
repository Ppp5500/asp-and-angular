using Microsoft.EntityFrameworkCore;
using MySql.Data;
using MySql.EntityFrameworkCore;

namespace WorldCitiesAPI.Data.Models;

public class BlogDataContext : DbContext
{
    MySql.Data.MySqlClient.MySqlConnection conn;
    static readonly string connectionString = "server=127.0.0.1;uid=root;pwd=azsx1324;database=my_database";

    public DbSet<inform> informs { get; set; } = null!;

    /*
    public BlogDataContext(DbContextOptions options) : base(options)
    {

    }
    */

    /*
    public DbSet<Author>? Authors { get; set; }
    public DbSet<Post>? Posts { get; set; }
    */

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();
            var connectionString = configuration.GetConnectionString("ConnectionString");
            optionsBuilder.UseMySQL(connectionString);
            Console.WriteLine($"conn opened!");
        }
    }
}

public class inform
{
    public int num { get; set; }
    public string Uname { get; set; }
}

public class Post
{
    public int PostId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public Author Author { get; set; }
}

public class Author
{
    public int AuthorId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }

    public List<Post> Posts { get; set; }
}
