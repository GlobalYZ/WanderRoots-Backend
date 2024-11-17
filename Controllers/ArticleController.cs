using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WanderRoots_backend.Data;
using WanderRoots_backend.Models;

namespace WanderRoots_backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ArticleController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ArticleController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/country/{countryName}
    [HttpGet("country/{countryName}")]
    public async Task<ActionResult<IEnumerable<Article>>> GetArticlesByCountry(string countryName)
    {
        var country = await _context.Countries
            .Include(c => c.Articles)
            .FirstOrDefaultAsync(c => c.Name == countryName);

        if (country == null)
            return NotFound();

        return Ok(country.Articles);
    }

    // GET: api/article/countries
    [HttpGet("countries")]
    public async Task<ActionResult<IEnumerable<Country>>> GetCountries()
    {
        return await _context.Countries.ToListAsync();
    }

    // GET: api/article/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Article>> GetArticleById(int id)
    {
        var article = await _context.Articles.FindAsync(id);

        if (article == null)
            return NotFound();

        return article;
    }

    // GET: api/article/{id}/image
    [HttpGet("{id}/image")]
    public async Task<ActionResult<ArticleImage>> GetArticleImageByArticleId(int id)
    {
        var articleImage = await _context.ArticleImages.FirstOrDefaultAsync(ai => ai.ArticleId == id);

        if (articleImage == null)
        {
            var defaultImage = await _context.ArticleImages.FirstOrDefaultAsync(ai => ai.ArticleId == -1);
            if (defaultImage == null)
                return NotFound();
            return defaultImage;
        }

        return articleImage;
    }
}