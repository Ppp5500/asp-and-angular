using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.HttpOverrides;
using WorldCitiesAPI.Data;

var builder = WebApplication.CreateBuilder(args);

Console.WriteLine($"We are in Program.cs");
// Add services to the container.

builder.Services.AddControllers();
    //.AddJsonOptions(opsions => { opsions.JsonSerializerOptions.WriteIndented = true; });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
        )
    );


// Add ApplicationDbContext and SQL Server support
/*
builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
        )
    );
*/

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Error");
    app.MapGet("/Error", () => Results.Problem());
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();