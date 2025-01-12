namespace Core.Application.Reponses.PostsResponses;

public class CreatePostResponse
{
    public int PostId { get; set; }
    public int UserId { get; set; }
    public string? Content { get; set; }
}