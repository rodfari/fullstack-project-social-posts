namespace Core.Domain.Entities;

public class Post: BaseEntity
{
    public int UserId { get; set; }
    public string Content { get; set; }
    public User User { get; set; }
    // public ICollection<Repost> Reposts { get; set; }
    public bool IsRepost { get; set; }
    public int? OriginalPostId { get; set; }
    public Post Repost { get; set; }
}

