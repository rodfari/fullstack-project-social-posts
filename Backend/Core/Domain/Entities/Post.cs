using System.Net.Security;

namespace Core.Domain.Entities;

public class Post: DefaultEntity
{
    public int UserId { get; set; }
    public string Content { get; set; }
    public User User { get; set; }
    public ICollection<Repost> Reposts { get; set; }

}

