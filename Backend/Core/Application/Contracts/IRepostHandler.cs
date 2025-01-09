using Core.Application.Dtos;
using Core.Application.Dtos.Requests;

namespace Core.Application.Contracts;
public interface IRepostHandler
{
    Task<RepostDto> CreateRepost(RepostRequest request);
    Task<RepostDto> GetRepost(int id);
    Task<IEnumerable<RepostDto>> GetReposts();

}