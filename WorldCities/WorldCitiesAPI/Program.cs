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

// 자꾸 널 가능 참조라고 해서 그냥 connectionString 쑤셔넣었음
// 원래는 appsettings에 있어야 되는 건데...
builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseMySQL(
        "server=127.0.0.1;uid=root;pwd=azsx1324;database=WorldCities"
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

// Invoke the UseForwardedHeaders middleware and configure it
// to forward the X-Forwarded-For and X-Forwarded-Proto headers.
// NOTE: This must be put BEFORE calling UseAuthentication
// and other authentication scheme middlewares.
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor
|ForwardedHeaders.XForwardedProto
});

app.UseAuthorization();

app.MapControllers();

app.Run();