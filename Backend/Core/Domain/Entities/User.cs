namespace Core.Domain.Entities;

public class User: BaseEntity
{
    public string Username { get; set; }
    
    public ICollection<Post> Posts { get; set; }
    public ICollection<Repost> Reposts { get; set; }
}

