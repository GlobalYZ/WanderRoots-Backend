using System.ComponentModel.DataAnnotations;


public class Review
{

    [Key]
    public int Id { get; set; }

    required public string uuid { get; set; }

    [Range(1, 5, ErrorMessage = "Rate must be between 1 and 5.")]
    required public int Rate { get; set; } // Rating value between 1 and 5


    [Required(ErrorMessage = "Content is required.")]
    [MaxLength(1000, ErrorMessage = "Content cannot exceed 1000 characters.")]
    [MinLength(1, ErrorMessage = "Content cannot be empty.")] // Ensures content has at least one character
    public string Content { get; set; } = string.Empty; // Review content

    public Country Country { get; set; } = null!;
}