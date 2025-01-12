namespace Core.Application.Reponses.PostsResponses;
public class GetPostByIdResponse
{
    public int UserId { get; set; }
    public int PostId { get; set; }
    public string Content { get; set; }
    public string UserName { get; set; }
    public DateTime CreatedAt { get; set; }
}

