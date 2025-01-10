using Core.Domain.Entities;

namespace Core.Application.Reponses.PostsResponses;

public class CreatePostResponse
{
    public int PostId { get; set; }
    public int UserId { get; set; }
    public string Content { get; set; }
    public string UserName { get; set; }
    public bool IsRepost { get; set; }
    public int? IdAuthor { get; set; }
    public string Author { get; set; }
    public int? OriginalPostId { get; set; }
}