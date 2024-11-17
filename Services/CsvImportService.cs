using CsvHelper;
using System.Globalization;
using WanderRoots_backend.Models;
using WanderRoots_backend.Data;
using Microsoft.EntityFrameworkCore;
namespace WanderRoots_backend.Services;

public class CsvImportService
{
    private readonly ApplicationDbContext _context;

    public CsvImportService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task ImportJokesFromCsv(string filePath)
    {
        Console.WriteLine($"Attempting to import CSV from: {filePath}");
        using var reader = new StreamReader(filePath);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        var records = csv.GetRecords<JokeRecord>().ToList();
        var shouldImportCountries = await _context.Countries.AnyAsync();
        var shouldImportArticles = await _context.Articles.AnyAsync();

        if (!shouldImportCountries)
        {
            var uniqueCountries = records
                .Select(r => r.country)
                .Distinct()
                .Where(c => !string.IsNullOrEmpty(c))
                .Select(name => new Country { Name = name });

            await _context.Countries.AddRangeAsync(uniqueCountries);
            var savedCount = await _context.SaveChangesAsync();
            Console.WriteLine($"Saved {savedCount} countries to database");
        }
        else
        {
            Console.WriteLine("Countries table is not empty, skipping import");
        }

        if (!shouldImportArticles)
        {
            var countryDict = await _context.Countries
                .ToDictionaryAsync(c => c.Name, c => c.Id);

            var articles = records.Select(r => new Article
            {
                Title = $"{r.country} Joke",
                Context = $"{r.question}\n\n{r.answer}",
                CountryId = countryDict[r.country]
            }).ToList();

            await _context.Articles.AddRangeAsync(articles);
            var savedCount = await _context.SaveChangesAsync();
            Console.WriteLine($"Saved {savedCount} articles to database");
        }
        else
        {
            Console.WriteLine("Articles table is not empty, skipping import");
        }





    }


}

public class JokeRecord
{
    public required string country { get; set; }
    public required string question { get; set; }
    public required string answer { get; set; }
}