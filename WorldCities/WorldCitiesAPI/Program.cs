using WorldCitiesAPI.Data.Models;
using MySql.Data;
using MySql.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

Console.WriteLine($"We are in Program.cs");
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BlogDataContext>();
Console.WriteLine($"We just added DbContext");

using (var context = new BlogDataContext())
{
    /*
    var john = new Author { Name = "John T. Author", Email = "john@example.com" };
    context.Authors.Add(john);

    var jane = new Author { Name = "Jane Q. Hacker", Email = "jane@example.com" };
    context.Authors.Add(jane);

    var post = new Post { Title = "Hello World", Content = "I wrote an app using EF Core!", Author = jane };
    context.Posts.Add(post);
    post = new Post { Title = "How to use EF Core", Content = "It's pretty easy", Author = john };
    context.Posts.Add(post);
    */

    var john = new inform { num = 0};
    context.informs.Add(john);

    var tylor = new inform { num = 1};
    context.informs.Add(tylor);

    context.SaveChanges();
}

// query the blog posts, using a join between the two tables
using (var context = new BlogDataContext())
{
    var infomation = context.informs
        .ToList();

    foreach( var name in infomation)
    {
        Console.WriteLine(name);
    }
    /*
    var posts = context.Posts
        .Include(p => p.Author)
        .ToList();

    foreach (var post in posts)
    {
        Console.WriteLine($"{post.Title} by {post.Author.Name}");
    }
    */
}
Console.WriteLine($"asdf");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();