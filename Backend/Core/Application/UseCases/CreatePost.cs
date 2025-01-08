using Backend.Core.Domain;
using Backend.Core.Domain.Contracts;
using Core.Application.Dtos.Requests;

namespace Backend.Core.Application.UseCases;

public class CreatePostUseCase
{
    private readonly IRepository<Post> _postRepository;
    private readonly IRepository<DailyPostLimit> _dailyPostLimitRepository;

    public CreatePostUseCase(
        IRepository<Post> postRepository,
        IRepository<DailyPostLimit> dailyPostLimitRepository)
    {
        _postRepository = postRepository;
        _dailyPostLimitRepository = dailyPostLimitRepository;
    }

    public async Task ExecuteAsync(CreatePostRequest request)
    {
        // 1. Validate the content length
        if (string.IsNullOrWhiteSpace(request.Content) || request.Content.Length > 777)
        {
            throw new ArgumentException("Post content must be between 1 and 777 characters.");
        }

        // 2. Check the daily post limit
        var today = DateTime.UtcNow.Date;

        var dailyLimit = await _dailyPostLimitRepository.FindAsync(
            d => d.UserId == request.UserId && d.PostDate == today
        );

        int postsToday = dailyLimit.FirstOrDefault()?.PostCount ?? 0;

        if (postsToday >= 5)
        {
            throw new InvalidOperationException("Daily post limit of 5 reached.");
        }

        // 3. Create the post
        var newPost = new Post
        {
            UserId = request.UserId,
            Content = request.Content,
            CreatedAt = DateTime.UtcNow,
        };

        await _postRepository.AddAsync(newPost);

        // 4. Update or create the DailyPostLimit
        var userDailyLimit = dailyLimit.FirstOrDefault();

        if (userDailyLimit == null)
        {
            // Create a new daily limit entry
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
            // Update the existing daily limit entry
            userDailyLimit.PostCount += 1;
            await _dailyPostLimitRepository.UpdateAsync(userDailyLimit);
        }
    }
}
