using Core.Application.Dtos;
using Core.Application.Reponses;
using Core.Application.Reponses.PostsResponses;
using MediatR;

namespace Core.Application.Feature.Posts.Queries.GetPorstById;
public record GetPostByIdQuery: IRequest<TResponse<PostDto>>
{
    public int Id { get; set; }
}