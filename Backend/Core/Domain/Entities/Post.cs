using System.Net.Security;

namespace Core.Domain.Entities;

public class Post: DefaultEntity
{
    public int UserId { get; set; }
    public string Content { get; set; }
    public User User { get; set; }
    public bool IsRepost { get; set; }
    public int? IdAuthor { get; set; }
    public string Author { get; set; }
    public int? OriginalPostId { get; set; }
    public Post Repost { get; set; }
    public int RepostCount { get; set; }
}

