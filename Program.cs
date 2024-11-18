using Microsoft.EntityFrameworkCore;
using WanderRoots_backend.Data;
using WanderRoots_backend.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddOpenApi();
builder.Services.AddControllers();

//add sqlite db
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Sqlite")));

// add csv import service
builder.Services.AddScoped<CsvImportService>();

var app = builder.Build();

// create db directory if not exists
if (!Directory.Exists("db"))
{
    Directory.CreateDirectory("db");
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();
        context.Database.EnsureCreated();

        var csvImportService = services.GetRequiredService<CsvImportService>();

        // load jokes from csv
        if (!context.Articles.Any())
        {
            await csvImportService.ImportJokesFromCsv("dataset/jokes.csv");
            await context.SaveChangesAsync();
        }

        // load seed data
        ModelBuilderExtensions.Seed(context);
        await context.SaveChangesAsync();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "error init db");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapControllers();

app.Run();
