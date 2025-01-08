namespace Backend.Core.Domain;

public class Repost
{
    public int RepostId { get; set; }
    public int UserId { get; set; }
    public int OriginalPostId { get; set; }
    public DateTime RepostedAt { get; set; }

    public User User { get; set; }
    public Post OriginalPost { get; set; }
}

