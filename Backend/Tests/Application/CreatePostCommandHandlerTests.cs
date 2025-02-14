using System.Linq.Expressions;
using AutoFixture;
using Core.Application.Feature.Posts.Commands.CreatePosts;
using Core.Domain.Contracts;
using Core.Domain.Entities;
using Core.Domain.Enums;
using Moq;
using Shouldly;

namespace ApplicationTests;


// Posts

// Posts are the equivalent of Twitter's tweets. They are text-only, user-generated content. Users can write original posts and interact with other users' posts by reposting content. For this project, you should implement both — original posts, and reposts.

// A user is not allowed to post more than 5 posts in one day (including reposts) - OK - tested
// Posts can have a maximum of 777 characters - OK - tested
// The post rendering should include the author's username and creation date, in addition to the content. - OK
// Users cannot update or delete their posts - OK
// Users can change the sorting between "latest" and "trending". When choosing "latest" (default), the posts will be rendered in descending order of their creation date. For "trending" posts, those with more reposts should come first.
// When filtering results using keywords, only exact matches for post content are expected. - OK - not tested
// Only original posts are expected as a result of the keywords filtering
// Reposting

// Users can repost other users' posts (like Twitter Retweet), limited to original posts
// Users must confirm their intention when reposting. - OK
// It should not be possible to repost the same post twice - NOT implemented

public class CreatePostCommandHandlerTests
{
    public CreatePostCommandHandlerTests()
    {
    }

    [Fact]
    public async Task CreatePostUseCase_WhenPostIsValid_ShouldCreatePost()
    {
        // Arrange
        var _postRepositoryMock = new Mock<IPostsRepository>();
        var fixture = new Fixture();
        fixture.Customize<Posts>(
            composer =>
            composer.Without(x => x.User)
            .Without(x => x.Reposts)
            .Without(x => x.Author));

        var posts = fixture.Create<Posts>();

        _postRepositoryMock
            .Setup(x => x.AddAsync(It.IsAny<Posts>()))
            .ReturnsAsync(posts);
        _postRepositoryMock
            .Setup(x => x.GetAllAsync(It.IsAny<Expression<Func<Posts, bool>>>()))
            .ReturnsAsync(new List<Posts>());
        // Act
        var handler = new CreatePostCommandHandler(_postRepositoryMock.Object);

        var result = await handler.Handle(new CreatePostCommand
        {
            UserId = posts.UserId,
            Content = posts.Content,
        }, CancellationToken.None);

        // Assert
        Assert.True(result.Success);
        Assert.Equal(posts.UserId, result.Data.UserId);
        Assert.Equal(posts.Content, result.Data.Content);
    }

    [Fact]
    public async void Should_Have_Error_When_Content_Exceeds_Max_Length()
    {
        // Arrange
        var _postRepositoryMock = new Mock<IPostsRepository>();

        var fixture = new Fixture();
        fixture.Customize<Posts>(
            composer =>
            composer.Without(x => x.User)
            .Without(x => x.Reposts)
            .Without(x => x.Author));

        var posts = fixture.Create<Posts>();

        _postRepositoryMock
            .Setup(x => x.AddAsync(It.IsAny<Posts>()))
            .ReturnsAsync(posts);
        _postRepositoryMock
            .Setup(x => x.GetAllAsync(It.IsAny<Expression<Func<Posts, bool>>>()))
            .ReturnsAsync(new List<Posts>());

        var handler = new CreatePostCommandHandler(_postRepositoryMock.Object);

        var createPostCmdFixture = new Fixture();
        createPostCmdFixture.Customize<CreatePostCommand>(
            composer =>
            composer.With(x => x.Content, new string('A', 778))
            .With(x => x.IsRepost, false));

        var requestExceeded = createPostCmdFixture.Create<CreatePostCommand>();
        var result = await handler.Handle(requestExceeded, CancellationToken.None);


        // Act & Assert
        Assert.False(result.Success);
        Assert.Contains(result.Errors, x => x.Message == "Post content must be between 1 and 777 characters.");
        Assert.Contains(result.Errors, x => x.Code == Enum.GetName(ErrorCodes.CONTENT_LENGTH));
    }

    [Fact]
    public async void Should_Have_Error_When_Content_Is_Empty()
    {
        var _postRepositoryMock = new Mock<IPostsRepository>();

        var fixture = new Fixture();
        fixture.Customize<Posts>(
            composer =>
            composer.Without(x => x.User)
            .Without(x => x.Reposts)
            .Without(x => x.Author));

        var posts = fixture.Create<Posts>();

        _postRepositoryMock
            .Setup(x => x.AddAsync(It.IsAny<Posts>()))
            .ReturnsAsync(posts);
        _postRepositoryMock
            .Setup(x => x.GetAllAsync(It.IsAny<Expression<Func<Posts, bool>>>()))
            .ReturnsAsync(new List<Posts>());

        var handler = new CreatePostCommandHandler(_postRepositoryMock.Object);

        var createPostCmdFixture = new Fixture();
        createPostCmdFixture.Customize<CreatePostCommand>(
            composer =>
            composer.With(x => x.Content, string.Empty)
            .With(x => x.IsRepost, false));

        var requestExceeded = createPostCmdFixture.Create<CreatePostCommand>();
        var result = await handler.Handle(requestExceeded, CancellationToken.None);

        // Act & Assert
        Assert.False(result.Success);
        Assert.Contains(result.Errors, x => x.Message == "Post content is required.");
        Assert.Contains(result.Errors, x => x.Code == Enum.GetName(ErrorCodes.CONTENT_REQUIRED));

    }

    [Fact]
    public async Task Should_Have_Error_When_User_Posts_More_Than_Five_Posts_In_One_Day()
    {
        // Arrange
        var _postRepositoryMock = new Mock<IPostsRepository>();
        var fixture = new Fixture();
        fixture.Customize<Posts>(
            composer =>
            composer.Without(x => x.User)
            .Without(x => x.Reposts)
            .Without(x => x.Author)
            .With(x => x.CreatedAt, DateTime.UtcNow.Date));

        var posts = fixture.CreateMany<Posts>(5).ToList();

        _postRepositoryMock
            .Setup(x => x.GetAllAsync(It.IsAny<Expression<Func<Posts, bool>>>()))
            .ReturnsAsync(posts);

        var handler = new CreatePostCommandHandler(_postRepositoryMock.Object);

        var createPostCmdFixture = new Fixture();
        createPostCmdFixture.Customize<CreatePostCommand>(
            composer =>
            composer.With(x => x.Content, "This is a new post")
            .With(x => x.IsRepost, false));

        var request = createPostCmdFixture.Create<CreatePostCommand>();

        // Act
        var result = await handler.Handle(request, CancellationToken.None);

        // Assert
        Assert.False(result.Success);
        Assert.Contains(result.Errors, x => x.Message == "You have reached your 5 post limit per day.");
        Assert.Contains(result.Errors, x => x.Code == Enum.GetName(ErrorCodes.POST_LIMIT_EXCEEDED));
    }

}