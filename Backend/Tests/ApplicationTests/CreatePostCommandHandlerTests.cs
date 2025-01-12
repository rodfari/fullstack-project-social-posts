using System.Linq.Expressions;
using AutoFixture;
using Core.Application.Feature.Posts.Commands.CreatePosts;
using Core.Domain.Contracts;
using Core.Domain.Entities;
using Core.Domain.Enums;
using Moq;

namespace ApplicationTests;

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
        var postRepositoryMock = new Mock<IPostRepository>();

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
        var postRepositoryMock = new Mock<IPostRepository>();

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
}