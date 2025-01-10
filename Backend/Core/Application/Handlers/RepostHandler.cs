using Core.Application.Contracts;
using Core.Application.Dtos;
using Core.Application.Dtos.Requests;
using Core.Domain.Contracts;
using Core.Domain.Entities;

namespace Core.Application.Handlers;
public class RepostHandler: IRepostHandler
{
    private readonly IRepostRepository _repostRepository;
    private readonly IDailyPostLimitRepository _dailyPostLimitRepository;

    public RepostHandler(IRepostRepository repostRepository, IDailyPostLimitRepository dailyPostLimitRepository)
    {
        _repostRepository = repostRepository;
        _dailyPostLimitRepository = dailyPostLimitRepository;
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
