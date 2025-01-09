namespace Core.Domain.Entities;

public class Post: BaseEntity
{
    public int UserId { get; set; }
    public string Content { get; set; }
    public User User { get; set; }
}

