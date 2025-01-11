using Core.Application.Dtos;
using Core.Application.Reponses;
using MediatR;

namespace Core.Application.Feature.Posts.Queries;
public class GetAllPostsQuery: IRequest<ResponseBase<List<PostDto>>>
{
    public string Keyword { get; set; }
    public string Sort { get; set; }
}