namespace WanderRoots_backend.Models.Dto;

public class ReviewQueryDto
{
    public required string Uuid { get; set; }
    public int ArticleId { get; set; }
}