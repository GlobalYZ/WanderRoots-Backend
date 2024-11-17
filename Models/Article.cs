using System.ComponentModel.DataAnnotations;

namespace WanderRoots_backend.Models;

public class Article
{
    [Key]
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Context { get; set; }

    public required int CountryId { get; set; }
}
