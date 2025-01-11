using Core.Application.Dtos;
using Core.Application.Dtos.Requests;
using Core.Domain.Contracts;
using Core.Domain.Entities;

namespace Core.Application.Handlers;
public class RepostHandler
{
    private readonly IRepostRepository _repostRepository;

    public RepostHandler(IRepostRepository repostRepository)
    {
        _repostRepository = repostRepository;
    }

    public async Task<RepostDto> CreateRepost(RepostRequest request)
    {
        Repost repost = new Repost
        {
            UserId = request.UserId,
            PostId = request.OriginalPostId
        };
        await _repostRepository.AddAsync(repost);
        return new RepostDto();
    }

    public async Task<RepostDto> GetRepost(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<RepostDto>> GetReposts()
    {
        throw new NotImplementedException();
    }
}
