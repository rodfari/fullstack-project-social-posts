namespace Core.Application.Dtos;
public class PostDto
{
    public int PostId { get; set; }
    public string Username { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
}