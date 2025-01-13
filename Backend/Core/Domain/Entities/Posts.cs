
namespace Core.Domain.Entities;
public class Posts: DefaultEntity
{
    public int? OriginalPostId { get; set; }
    public Posts? Reposts { get; set; }

    public int UserId { get; set; }
    public User User { get; set; } = null!;

    public int? AuthorId { get; set; }
    public User? Author { get; set; }

    
    public string? Content { get; set; }
    public bool IsRepost { get; set; }
    public int RepostCount { get; set; }
}