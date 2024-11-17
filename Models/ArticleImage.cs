using System.ComponentModel.DataAnnotations;

public class ArticleImage
{
    [Key]
    required public int Id { get; set; }

    required public string base64 { get; set; }

    public int ArticleId { get; set; } = -1;
}