using Core.Domain.Entities;

namespace Core.Application.Dtos;
public class PostDto
{
    public int PostId { get; set; }
    public string Username { get; set; } = string.Empty;
    public string? Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsRepost { get; set; }
    public string? Author { get; set; }
}