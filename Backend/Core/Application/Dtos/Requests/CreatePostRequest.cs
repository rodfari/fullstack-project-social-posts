namespace Core.Application.Dtos.Requests;
public class CreatePostRequest
{
    public int UserId { get; set; }
    public string Content { get; set; } = string.Empty;
}