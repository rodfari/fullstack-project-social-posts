using Core.Application.Dtos;

namespace Core.Application.Reponses.PostsResponses;
public class GetAllPostAndUserResponse
{
    public int UserId { get; set; }
    public int PostId { get; set; }
    public PostDto postDto { get; set; }
    public string Content { get; set; }
    public string UserName { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsRepost { get; set; }
    public int? OriginalPostId { get;  set; }
    public string Author { get;  set; }
}