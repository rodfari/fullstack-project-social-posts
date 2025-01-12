namespace Core.Domain.Entities;

public class Repost: DefaultEntity
{
    public int RepostAuthorId { get; set; }
    public User User { get; set; }
    public int PostAuthorId { get; set; }
    public int PostId { get; set; }
    public Post Post { get; set; }
}

