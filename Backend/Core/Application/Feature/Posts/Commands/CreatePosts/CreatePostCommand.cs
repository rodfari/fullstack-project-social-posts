using Core.Application.Reponses;
using Core.Application.Reponses.PostsResponses;
using MediatR;

namespace Core.Application.Feature.Posts.Commands.CreatePosts;
public class CreatePostCommand: IRequest<ResponseBase<CreatePostResponse>>
{
    public int UserId { get; set; }
    public string Content { get; set; }
}