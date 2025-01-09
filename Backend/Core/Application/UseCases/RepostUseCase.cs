using Backend.Core.Application.Dtos.Requests;
using Backend.Core.Domain;
using Backend.Core.Domain.Contracts;

namespace Backend.Core.Application.UseCases
{
    public class RepostUseCase
{
    private readonly IRepository<Post> _postRepository;
    private readonly IRepository<DailyPostLimit> _dailyPostLimitRepository;

    public RepostUseCase(IRepository<Post> postRepository, IRepository<DailyPostLimit> dailyPostLimitRepository)
    {
        _postRepository = postRepository;
        _dailyPostLimitRepository = dailyPostLimitRepository;
    }

    public async Task ExecuteAsync(RepostRequest request)
    {
        // Check the daily post limit
        var today = DateTime.UtcNow.Date;
        var dailyLimit = await _dailyPostLimitRepository.FindAsync(
            d => d.UserId == request.UserId && d.PostDate == today
        );
        int postsToday = dailyLimit.FirstOrDefault()?.PostCount ?? 0;

        if (postsToday >= 5)
        {
            throw new InvalidOperationException("Daily post limit of 5 reached.");
        }

        // Check that the original post exists
        var originalPost = await _postRepository.GetByIdAsync(request.OriginalPostId);
        if (originalPost == null)
        {
            throw new InvalidOperationException("Original post does not exist.");
        }

        // Ensure the original post is not itself a repost
        if (originalPost.IsRepost)
        {
            throw new InvalidOperationException("Cannot repost a repost.");
        }

        // Check that the user hasn't already reposted the original post
        var existingRepost = await _postRepository.FindAsync(
            p => p.UserId == request.UserId && p.PostId == request.OriginalPostId
        );
        if (existingRepost.Any())
        {
            throw new InvalidOperationException("You have already reposted this post.");
        }

        // Create the repost
        var newRepost = new Post
        {
            UserId = request.UserId,
            Content = originalPost.Content,
            CreatedAt = DateTime.UtcNow,
            IsRepost = true,
            //OriginalPostId = originalPost.Id
        };
        await _postRepository.AddAsync(newRepost);

        // Update or create the DailyPostLimit
        var userDailyLimit = dailyLimit.FirstOrDefault();
        if (userDailyLimit == null)
        {
            var newDailyLimit = new DailyPostLimit
            {
                UserId = request.UserId,
                PostDate = today,
                PostCount = 1
            };
            await _dailyPostLimitRepository.AddAsync(newDailyLimit);
        }
        else
        {
            userDailyLimit.PostCount += 1;
            await _dailyPostLimitRepository.UpdateAsync(userDailyLimit);
        }
    }
}

}