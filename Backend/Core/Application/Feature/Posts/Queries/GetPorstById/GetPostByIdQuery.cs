using Core.Application.Reponses;
using Core.Application.Reponses.PostsResponses;
using MediatR;

namespace Core.Application.Feature.Posts.Queries.GetPorstById;
public class GetPostByIdQuery: IRequest<TResponse<GetPostByIdResponse>>
{
    public int Id { get; set; }
}