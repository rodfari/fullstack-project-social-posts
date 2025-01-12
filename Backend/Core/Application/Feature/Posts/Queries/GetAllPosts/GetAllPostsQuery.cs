using Core.Application.Dtos;
using Core.Application.Reponses;
using MediatR;

namespace Core.Application.Feature.Posts.Queries;
public class GetAllPostsQuery: IRequest<TResponse<List<PostDto>>>
{
    public string Keyword { get; set; } = string.Empty;
    public string Sort { get; set; } = "desc";
    public bool Trending { get; set; }
}