namespace Core.Domain.Entities;

public class Repost: BaseEntity
{
    public int UserId { get; set; }
    public User User { get; set; }
    
    public int PostId { get; set; }
    public Post Post { get; set; }
}

