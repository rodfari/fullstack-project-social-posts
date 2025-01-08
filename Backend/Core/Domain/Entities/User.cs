namespace Backend.Core.Domain;

public class User
{
    public int UserId { get; set; }
    public string Username { get; set; }
    
    public ICollection<Post> Posts { get; set; }
    public ICollection<Repost> Reposts { get; set; }
}

