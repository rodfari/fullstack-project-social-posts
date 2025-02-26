using AutoFixture;
using Core.Domain.Entities;
using Infrastructure.Persistence.mySQL;
using Infrastructure.Persistence.mySQL.Repository;
using Microsoft.EntityFrameworkCore;
using Shouldly;

namespace PersistenceTests;

public class PostsRepositoryTests
{
    [Fact]
    public async Task CreatePostAsync_ShouldCreatePost()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: "CreatePostAsync_ShouldCreatePost")
            .Options;

        using var context = new DataContext(options);
        var postFix = new Fixture();
        postFix.Customize<Posts>(
            x => x
            .Without(p => p.User)
            .Without(p => p.Author)
            .Without(p => p.Reposts)
            .Without(p => p.OriginalPostId)
            .Without(p => p.AuthorId)
        );

        var post = postFix.Create<Posts>();
        var repository = new PostsRepository(context);

        // Act
        await repository.AddAsync(post);
        var result = await context.Posts.FirstOrDefaultAsync(x => x.Id == post.Id);

        // Assert
        result.ShouldNotBeNull();
        result.ShouldBeOfType<Posts>();
        result.Id.ShouldBe(post.Id);
        result.Content.ShouldBe(post.Content);
        result.UserId.ShouldBe(post.UserId);
        result.CreatedAt.ShouldBe(post.CreatedAt);
    }

    [Fact]
    public async Task GetPostByIdAsync_ShouldReturnPost()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: "GetPostByIdAsync_ShouldReturnPost")
            .Options;

        using var context = new DataContext(options);
        var postFix = new Fixture();
        postFix.Customize<Posts>(
            x => x
            .Without(p => p.User)
            .Without(p => p.Author)
            .Without(p => p.Reposts)
            .Without(p => p.OriginalPostId)
            .Without(p => p.AuthorId)
        );

        var post = postFix.Create<Posts>();
        var repository = new PostsRepository(context);

        // Act
        var result = await repository.AddAsync(post);

        // Assert
        result.ShouldNotBeNull();
        result.ShouldBeOfType<Posts>();
        result.Id.ShouldBe(post.Id);
        result.Content.ShouldBe(post.Content);
        result.UserId.ShouldBe(post.UserId);
        result.CreatedAt.ShouldBe(post.CreatedAt);
    }

    [Fact]
    public async Task GetPostByUserIdAsync_ShouldReturnPosts()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: "GetPostByUserIdAsync_ShouldReturnPosts")
            .Options;

        using var context = new DataContext(options);
        var postFix = new Fixture();
        postFix.Customize<Posts>(
            x => x
            .Without(p => p.User)
            .Without(p => p.Author)
            .Without(p => p.Reposts)
            .Without(p => p.OriginalPostId)
            .Without(p => p.AuthorId)
        );

        var post = postFix.Create<Posts>();
        var repository = new PostsRepository(context);

        // Act
        await repository.AddAsync(post);
        var result = await repository.FilterAsync(x => x.UserId == post.UserId) as List<Posts>;

        // Assert
        result.ShouldNotBeNull();
        result.ShouldBeOfType<List<Posts>>();
        result.Count.ShouldBe(1);
        result[0].Id.ShouldBe(post.Id);
        result[0].Content.ShouldBe(post.Content);
        result[0].UserId.ShouldBe(post.UserId);
        result[0].CreatedAt.ShouldBe(post.CreatedAt);
    }

    [Fact]
    public async Task GetPostByOriginalPostIdAsync_ShouldReturnPosts()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: "GetPostByOriginalPostIdAsync_ShouldReturnPosts")
            .Options;

        using var context = new DataContext(options);
        var postFix = new Fixture();
        postFix.Customize<Posts>(
            x => x
            .Without(p => p.User)
            .Without(p => p.Author)
            .Without(p => p.Reposts)
        );

        var post = postFix.Create<Posts>();
        var repository = new PostsRepository(context);

        // Act
        await repository.AddAsync(post);
        var result = await repository.FilterAsync(x => x.OriginalPostId == post.OriginalPostId) as List<Posts>;

        // Assert
        result.ShouldNotBeNull();
        result.ShouldBeOfType<List<Posts>>();
        result.Count.ShouldBe(1);
        result[0].Id.ShouldBe(post.Id);
        result[0].Content.ShouldBe(post.Content);
        result[0].UserId.ShouldBe(post.UserId);
        result[0].CreatedAt.ShouldBe(post.CreatedAt);
    }

    [Fact]
    public async Task GetPostByAuthorIdAsync_ShouldReturnPosts()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: "GetPostByAuthorIdAsync_ShouldReturnPosts")
            .Options;

        using var context = new DataContext(options);
        var postFix = new Fixture();
        postFix.Customize<Posts>(
            x => x
            .Without(p => p.User)
            .Without(p => p.Author)
            .Without(p => p.Reposts)
        );

        var post = postFix.Create<Posts>();
        var repository = new PostsRepository(context);

        // Act
        await repository.AddAsync(post);
        var result = await repository.FilterAsync(x => x.AuthorId == post.AuthorId) as List<Posts>;

        // Assert
        result.ShouldNotBeNull();
        result.ShouldBeOfType<List<Posts>>();
        result.Count.ShouldBe(1);
        result[0].Id.ShouldBe(post.Id);
        result[0].Content.ShouldBe(post.Content);
        result[0].UserId.ShouldBe(post.UserId);
        result[0].CreatedAt.ShouldBe(post.CreatedAt);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnAllPosts()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: "GetAllAsync_ShouldReturnAllPosts")
            .Options;

        using var context = new DataContext(options);
        var postFix = new Fixture();
        postFix.Customize<Posts>(
            x => x
            .Without(p => p.User)
            .Without(p => p.Author)
            .Without(p => p.Reposts)
            .Without(p => p.OriginalPostId)
            .Without(p => p.AuthorId)
        );

        var posts = postFix.CreateMany<Posts>(5).ToList();
        var repository = new PostsRepository(context);

        foreach (var post in posts)
        {
            await repository.AddAsync(post);
        }

        // Act
        var result = await repository.GetAllAsync() as List<Posts>;

        // Assert
        result.ShouldNotBeNull();
        result.ShouldBeOfType<List<Posts>>();
        result.Count.ShouldBe(5);
        foreach (var post in posts)
        {
            var retrievedPost = result.FirstOrDefault(x => x.Id == post.Id);
            retrievedPost.ShouldNotBeNull();
            retrievedPost.Content.ShouldBe(post.Content);
            retrievedPost.UserId.ShouldBe(post.UserId);
            retrievedPost.CreatedAt.ShouldBe(post.CreatedAt);
        }
    }

    [Theory(DisplayName = "GetAllAsync_With_Filter_Options")]
    [InlineData("", 1, 15, "desc", true)]
    [InlineData("", 1, 15, "", false)]
    [InlineData("Number: 5", 1, 15, "desc", false)]
    [InlineData("Number: 55", 1, 15, "desc", false)]
    [InlineData("", 0, 0, "", false)]
    [InlineData("", 0, 0, "", true)]
    public async Task GetAllAsync_With_Filter_Options(string keyword, int page, int pageSize, string sort, bool trending)
    {
        // Arrange
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: "GetAllAsync_With_Filter_Options")
            .Options;
        var posts = PostFixture.Fixture_GetAllAsync_With_Filter_Options();
        using var context = new DataContext(options);
        await context.AddRangeAsync(posts);
        await context.SaveChangesAsync();
        
        var query = context.Posts as IQueryable<Posts>;
        //filter by keyword
        if (!string.IsNullOrEmpty(keyword))
        {
            query = query.Where(x => x.Content.Contains(keyword));
        }

        //sort by trending
        if (trending)
        {
            query = query.OrderByDescending(x => x.RepostCount).ThenByDescending(x => x.CreatedAt);
        }
        else
        {
            query = sort switch
            {
                "asc" => query.OrderBy(x => x.CreatedAt),
                "desc" => query.OrderByDescending(x => x.CreatedAt),
                _ => query.OrderByDescending(x => x.CreatedAt)
            };
        }
        int postsCount = await query.CountAsync();
        //paginate
        query = query.Skip((page - 1) * pageSize).Take(pageSize);

        // Act
        var result = await query.ToListAsync();

        //assert
        result.ShouldNotBeNull();
        result.ShouldBeOfType<List<Posts>>();
        
        if(postsCount >= pageSize)
            result.Count.ShouldBe(pageSize);

        if (string.IsNullOrEmpty(keyword) && string.IsNullOrEmpty(sort) && !trending)
        {
            for (int i = 0; i < result.Count - 1; i++)
            {
                result[i].CreatedAt.ShouldBeGreaterThanOrEqualTo(result[i + 1].CreatedAt);
            }
        }

        if (!string.IsNullOrEmpty(keyword))
        {
            result.ShouldContain(x => x.Content.Contains(keyword));
        }

    }
}