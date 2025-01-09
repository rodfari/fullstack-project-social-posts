namespace Core.Domain.Entities;

public class Repost: BaseEntity
{
    public int UserId { get; set; }
    public User User { get; set; }
    
    public int OriginalPostId { get; set; }
    public Post OriginalPost { get; set; }
}

