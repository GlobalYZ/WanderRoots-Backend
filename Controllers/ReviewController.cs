using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WanderRoots_backend.Data;
using WanderRoots_backend.Models;
using WanderRoots_backend.Models.Dto;

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

    //make this a post method to get reviews by uuid and article id
    [HttpPost("article/{articleId}/user")]
    public async Task<ActionResult<Review>> GetReviewByUuidAndArticle(
        int articleId,
        [FromBody] ReviewQueryDto query)
    {
        //return reviews not one review
        var reviews = await _context.Reviews
            .Where(r =>
                r.ArticleId == articleId &&
                r.Uuid == query.Uuid)
            .ToListAsync();

        if (reviews.Count == 0)
            return NotFound($"No review found for article {articleId} and user {query.Uuid}");

        return Ok(reviews);
    }

    // POST: api/review
    [HttpPost]
    public async Task<ActionResult<Review>> CreateReview(Review review)
    {
        _context.Reviews.Add(review);
        await _context.SaveChangesAsync();

        return Ok(review);
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