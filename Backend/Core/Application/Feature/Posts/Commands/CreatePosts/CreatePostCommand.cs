using Core.Application.Reponses;
using Core.Application.Reponses.PostsResponses;
using MediatR;

namespace Core.Application.Feature.Posts.Commands.CreatePosts;
public class CreatePostCommand: IRequest<TResponse<CreatePostResponse>>
{
    public int UserId { get; set; }
    public string? Content { get; set; }
    public int? AuthorId { get; set; }
    public int? OriginalPostId { get; set; }
    public bool IsRepost { get; set; } = false;
}