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
        //await ExecuteAsync(request);
        return new RepostDto();
    }

    //public async Task ExecuteAsync(RepostRequest request)
    // {
    //     // Check the daily post limit
    //     var today = DateTime.UtcNow.Date;
    //     var dailyLimit = await _dailyPostLimitRepository.FindAsync(
    //         d => d.Id == request.UserId && d.CreatedAt == today
    //     );
    //     int postsToday = dailyLimit.FirstOrDefault()?.PostCount ?? 0;

    //     if (postsToday >= 5)
    //     {
    //         throw new InvalidOperationException("Daily post limit of 5 reached.");
    //     }

    //     // Check that the original post exists
    //     var originalPost = await _postRepository.GetByIdAsync(request.OriginalPostId);
    //     if (originalPost == null)
    //     {
    //         throw new InvalidOperationException("Original post does not exist.");
    //     }



    //     // Check that the user hasn't already reposted the original post
    //     var existingRepost = await _postRepository.FindAsync(
    //         p => p.UserId == request.UserId && p.Id == request.OriginalPostId
    //     );
    //     if (existingRepost.Any())
    //     {
    //         throw new InvalidOperationException("You have already reposted this post.");
    //     }

    //     // Create the repost
    //     var newRepost = new Post
    //     {
    //         UserId = request.UserId,
    //         Content = originalPost.Content,
    //         CreatedAt = DateTime.UtcNow,
    //         //OriginalPostId = originalPost.Id
    //     };
    //     await _postRepository.AddAsync(newRepost);

    //     // Update or create the DailyPostLimit
    //     var userDailyLimit = dailyLimit.FirstOrDefault();
    //     if (userDailyLimit == null)
    //     {
    //         var newDailyLimit = new DailyPostLimit
    //         {
    //             Id = request.UserId,
    //             CreatedAt = today,
    //             PostCount = 1
    //         };
    //         await _dailyPostLimitRepository.AddAsync(newDailyLimit);
    //     }
    //     else
    //     {
    //         userDailyLimit.PostCount += 1;
    //         await _dailyPostLimitRepository.UpdateAsync(userDailyLimit);
    //     }
    // }

    public async Task<RepostDto> GetRepost(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<RepostDto>> GetReposts()
    {
        throw new NotImplementedException();
    }
}
