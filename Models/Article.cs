using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace WanderRoots_backend.Models;

[Index(nameof(Id))]
public class Article
{
    [Key]
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Context { get; set; }

    public required int CountryId { get; set; }

    // Navigation property
    public ICollection<Review> Reviews { get; set; } = new List<Review>();
}
