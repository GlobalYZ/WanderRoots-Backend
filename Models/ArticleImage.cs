using System.ComponentModel.DataAnnotations;

public class ArticleImage
{
    [Key]
    required public int Id { get; set; }

    required public string base64 { get; set; }

    public string contryName { get; set; } = "default";
}