using Core.Application.Dtos;
using Core.Application.Dtos.Requests;

namespace Core.Application.Contracts;
public interface IRepostHandler
{
    Task<RepostDto> CreatePost(RepostRequest request);
    Task<RepostDto> GetPost(int id);
    Task<IEnumerable<RepostDto>> GetPosts();

}