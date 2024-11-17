using Microsoft.EntityFrameworkCore;
using WanderRoots_backend.Models;

namespace WanderRoots_backend.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Article> Articles { get; set; } = null!;
    public DbSet<Country> Countries { get; set; } = null!;
    public DbSet<ArticleImage> ArticleImages { get; set; } = null!;
    public DbSet<Review> Reviews { get; set; } = null!;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        ModelBuilderExtensions.Seed(builder);
    }
}

