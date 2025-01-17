using System.Linq.Expressions;
using Core.Application.Dtos;
using Core.Application.Reponses;
using MediatR;


namespace Core.Application.Feature.Posts.Queries;
public class GetAllPostsQuery: IRequest<TResponse<List<PostDto>>>
{
    public string Keyword { get; set; } = string.Empty;
    public string Sort { get; set; } = "desc";
    public Expression<Func<Domain.Entities.Posts, bool>> predicate { get; set; }
    public bool Trending { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
    
}