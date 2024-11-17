using Microsoft.EntityFrameworkCore;
using WanderRoots_backend.Models;

[Index(nameof(Name), IsUnique = true)]
public class Country
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public ICollection<Article> Articles { get; set; } = new List<Article>();

    public ICollection<Review> Reviews { get; set; } = new List<Review>();
}