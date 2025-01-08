namespace Backend.Core.Domain;

public class Post
{
    public int PostId { get; set; }
    public int UserId { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }

    public User User { get; set; }
    public ICollection<Repost> Reposts { get; set; }
}

