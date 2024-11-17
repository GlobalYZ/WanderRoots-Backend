using System.ComponentModel.DataAnnotations;
using WanderRoots_backend.Models;


public class Review
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "UUID is required.")]
    public string Uuid { get; set; } = string.Empty;

    [Range(1, 5, ErrorMessage = "Rate must be between 1 and 5.")]
    [Required]
    public int Rate { get; set; } // Rating value between 1 and 5

    [Required(ErrorMessage = "Content is required.")]
    [MaxLength(1000, ErrorMessage = "Content cannot exceed 1000 characters.")]
    [MinLength(1, ErrorMessage = "Content cannot be empty.")] // Ensures content has at least one character
    public string Content { get; set; } = string.Empty;

    // Foreign key
    public int ArticleId { get; set; }

    // Navigation property
    public Article Article { get; set; } = null!;
}