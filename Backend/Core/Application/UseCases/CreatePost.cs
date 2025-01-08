using Backend.Core.Domain;
using Backend.Core.Domain.Contracts;

namespace Backend.Core.Application.UseCases;

public class CreatePost
{
    private readonly IRepository<Post> _postRepository;

    public CreatePost(IRepository<Post> postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task ExecuteAsync(int userId, string content)
    {
        if (content.Length > 777)
            throw new Exception("Content exceeds maximum allowed length.");

        // Fetch today's posts by the user
        var today = DateTime.UtcNow.Date;
        var userPostsToday = await _postRepository
            .FindAsync(p => p.UserId == userId && p.CreatedAt.Date == today);

        if (userPostsToday.Count() >= 5)
            throw new Exception("Daily post limit reached.");

        var post = new Post
        {
            UserId = userId,
            Content = content,
            CreatedAt = DateTime.UtcNow
        };

        await _postRepository.AddAsync(post);
    }
}
