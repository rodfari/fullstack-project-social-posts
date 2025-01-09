using Backend.Core.Application.Dtos.Requests;
using Core.Domain.Contracts;
using Core.Domain.Entities;
using Domain.Contracts;

namespace Backend.Core.Application.UseCases
{
    public class RepostUseCase
{
    private readonly IPostRepository _postRepository;
    private readonly IDailyPostLimitRepository _dailyPostLimitRepository;

    public RepostUseCase(IPostRepository postRepository, IDailyPostLimitRepository dailyPostLimitRepository)
    {
        _postRepository = postRepository;
        _dailyPostLimitRepository = dailyPostLimitRepository;
    }

    public async Task ExecuteAsync(RepostRequest request)
    {
        // Check the daily post limit
        var today = DateTime.UtcNow.Date;
        var dailyLimit = await _dailyPostLimitRepository.FindAsync(
            d => d.Id == request.UserId && d.CreatedAt == today
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
            p => p.UserId == request.UserId && p.Id == request.OriginalPostId
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
                Id = request.UserId,
                CreatedAt = today,
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