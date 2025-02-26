using System.Linq.Expressions;
using AutoFixture;
using Core.Domain.Contracts;
using Core.Domain.Entities;
using Infrastructure.Persistence.mySQL;
using Infrastructure.Persistence.mySQL.Repository;
using Microsoft.EntityFrameworkCore;
using PersistenceTests.Fixtures;
using Shouldly;

namespace PersistenceTests;

public class PostsRepositoryTests : IClassFixture<PostsRepositoryFixture>
{
    PostsRepositoryFixture _fixture;
    public PostsRepositoryTests(PostsRepositoryFixture fixture)
    {


        _fixture = fixture;
    }

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
    [InlineData("filter word", 1, 10, "desc", 3)]
    [InlineData("FiltEr WoRd", 1, 10, "desc", 3)]
    [InlineData("", 1, 10, "desc", 10)]
    [InlineData("", 2, 10, "desc", 5)]
    [InlineData("", 2, 10, "", 5)]
    public async Task GetAllAsync_With_Filter_Options(string keyword, int page, int pageSize, string sort, int expected)
    {
        // Arrange
        _fixture
        .InitDataContext()
        .setUser()
        .SetContent(12)
        .SetContentWithMatchWord(3);

        IPostsRepository postsRepository = new PostsRepository(_fixture.DataContext);
        
        //Act
        Expression<Func<Posts, bool>> condition = x => true;

        if (!string.IsNullOrEmpty(keyword))
            condition = x => x.Content.ToLower().Contains(keyword.ToLower());

        var result = await postsRepository.LoadTimeLineAsync(condition, page, pageSize, "desc") as List<Posts>;

        //assert
        result.ShouldNotBeNull();
        result.ShouldBeOfType<List<Posts>>();
        result.Count.ShouldBe(expected);
    }

    [Fact]
    public async Task ShouldReturnOrderedByTrending()
    {
        // Arrange
        _fixture
        .InitDataContext()
        .setUser()
        .SetContent(12)
        .setTrendingPost();
        
        IPostsRepository postsRepository = new PostsRepository(_fixture.DataContext);
        
        //Act
        var allPosts = await postsRepository.GetAllAsync();
        var result = await postsRepository.LoadTimeLineAsync(x => true, 1, 10, "trending") as List<Posts>;

        //assert
        result.ShouldNotBeNull();
        result.ShouldBeOfType<List<Posts>>();
        result.Count.ShouldBe(10);
        result[0].Content.ShouldBe("this is a trending post");
        result[1].Content.ShouldNotBe("this is a trending post");

    }
        
}