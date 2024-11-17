using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WanderRoots_backend.Data;
using WanderRoots_backend.Models;

namespace WanderRoots_backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReviewController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ReviewController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/review/article/{articleId}
    [HttpGet("article/{articleId}")]
    public async Task<ActionResult<IEnumerable<Review>>> GetReviewsByArticle(int articleId)
    {
        return await _context.Reviews
            .Where(r => r.ArticleId == articleId)
            .ToListAsync();
    }

    // GET: api/review/article/{articleId}/{reviewId}
    [HttpGet("article/{articleId}/{reviewId}")]
    public async Task<ActionResult<Review>> GetReviewByArticleAndId(int articleId, int reviewId)
    {
        var review = await _context.Reviews
            .FirstOrDefaultAsync(r => r.ArticleId == articleId && r.Id == reviewId);

        if (review == null)
            return NotFound();

        return review;
    }

    // POST: api/review
    [HttpPost]
    public async Task<ActionResult<Review>> CreateReview(Review review)
    {
        _context.Reviews.Add(review);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetReviewByArticleAndId),
            new { articleId = review.ArticleId, reviewId = review.Id }, review);
    }

    // PUT: api/review/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> EditReview(int id, Review review)
    {
        if (id != review.Id)
            return BadRequest();

        _context.Entry(review).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ReviewExists(id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    // DELETE: api/review/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteReview(int id)
    {
        var review = await _context.Reviews.FindAsync(id);
        if (review == null)
            return NotFound();

        _context.Reviews.Remove(review);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ReviewExists(int id)
    {
        return _context.Reviews.Any(e => e.Id == id);
    }
}