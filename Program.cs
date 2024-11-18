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

// change db path
var dbPath = app.Environment.ContentRootPath + "/db";
if (!Directory.Exists(dbPath))
{
    Directory.CreateDirectory(dbPath);
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();
        context.Database.EnsureCreated();

        var csvImportService = services.GetRequiredService<CsvImportService>();

        // change csv path
        var csvPath = Path.Combine(app.Environment.ContentRootPath, "dataset", "jokes.csv");

        // check if data exists
        if (!context.Articles.Any() && File.Exists(csvPath))
        {
            await csvImportService.ImportJokesFromCsv(csvPath);
            await context.SaveChangesAsync();
        }

        // add seed data only if db is empty
        if (!context.ArticleImages.Any())
        {
            ModelBuilderExtensions.Seed(context);
            await context.SaveChangesAsync();
        }
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Error initializing database");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapControllers();

app.Run();
