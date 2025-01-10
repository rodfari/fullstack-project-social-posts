using Core.Application.Dtos;

namespace Application.Reponses.PostsResponses;
public class GetPostAndUserResponse
{
    public int UserId { get; set; }
    public int PostId { get; set; }
    public PostDto postDto { get; set; }
    public string Content { get; set; }
    public string UserName { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsRepost { get; set; }
    public int? OriginalPostId { get; internal set; }
}