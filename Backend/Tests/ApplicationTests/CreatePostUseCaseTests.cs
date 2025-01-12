using System.Linq.Expressions;
using AutoFixture;
using Core.Application.Handlers;
using Core.Domain.Contracts;
using Core.Domain.Entities;
using Moq;

namespace ApplicationTests;

public class CreatePostUseCaseTests
{
    // [Fact]
    // public async Task Should_CreatePost_When_ValidRequest()
    // {
    //     // Arrange
    //     var postRepositoryMock = new Mock<IPostRepository>();
    //     postRepositoryMock.
    //         Setup(x => x.GetAllAsync(It.IsAny<Expression<Func<Post, bool>>>()))
    //         .ReturnsAsync(new List<Post>());

    //     var request = new CreatePostRequest
    //     {
    //         UserId = 1,
    //         Content = "Hello, world!"
    //     };

    //     postRepositoryMock.Setup(x => x.AddAsync(It.IsAny<Post>()))
    //         .ReturnsAsync(new Post
    //         {
    //             Id = 1,
    //             UserId = request.UserId,
    //             Content = request.Content
    //         });

    //     var useCase = new PostHandlers(postRepositoryMock.Object);

    //     // Act
    //     var newPost = await useCase.CreatePostAsync(request);

    //     // Assert
    //     postRepositoryMock.Verify(repo => repo.AddAsync(It.IsAny<Post>()), Times.Once);
    //     Assert.True(newPost.Success);
    //     Assert.Equal(request.UserId, newPost.Data.UserId);
    // }


    // [Fact]
    // public async Task Should_ThrowInvalidOperationException_When_Daily_Post_Limit_Reached()
    // {
    //     // Arrange
    //     var postRepositoryMock = new Mock<IPostRepository>();

    //     // Simulate that the user already has 5 posts today
    //     var fixture = new Fixture();
    //     fixture.Customize<Post>(composer => composer.Without(x => x.Repost));
    //     var limit = fixture.CreateMany<Post>(5).ToList();

    //     postRepositoryMock.
    //         Setup(x => x.GetAllAsync(It.IsAny<Expression<Func<Post, bool>>>()))
    //         .ReturnsAsync(limit);
    //     var request = new CreatePostRequest
    //     {
    //         UserId = 1,
    //         Content = "Hello, world!"
    //     };
    //     var useCase = new PostHandlers(postRepositoryMock.Object);
    //     var newPost = await useCase.CreatePostAsync(request);

    //     // Act & Assert
    //     Assert.False(newPost.Success);
    //     Assert.Contains(newPost.Errors, x => x.Message == "You have reached the daily post limit.");
    //     Assert.Contains(newPost.Errors, x => x.Code == "POST_LIMIT");
    // }

    // [Fact]
    // public async void Should_Have_Error_When_Content_Exceeds_Max_Length()
    // {
    //     // Arrange
    //     var postRepositoryMock = new Mock<IPostRepository>();

    //     // Simulate that the user already has 5 posts today
    //     var fixture = new Fixture();
    //     fixture.Customize<Post>(composer => composer.Without(x => x.Repost));
    //     var limit = fixture.CreateMany<Post>(2).ToList();

    //     var request = new Fixture();
    //     request.Customize<CreatePostRequest>(composer => composer.With(x => x.Content, new string('A', 778)));
    //     var requestExceeded = request.Create<CreatePostRequest>();

    //     postRepositoryMock.
    //         Setup(x => x.GetAllAsync(It.IsAny<Expression<Func<Post, bool>>>()))
    //         .ReturnsAsync(limit);

    //     var useCase = new PostHandlers(postRepositoryMock.Object);
    //     var newPost = await useCase.CreatePostAsync(requestExceeded);

    //     // Act & Assert
    //     Assert.False(newPost.Success);
    //     Assert.Contains(newPost.Errors, x => x.Message == "Post content must be between 1 and 777 characters.");
    //     Assert.Contains(newPost.Errors, x => x.Code == "CONTENT_LENGTH");
    // }

    // [Fact]
    // public async void Should_Have_Error_When_Content_Is_Empty()
    // {
    //     // Arrange
    //     var postRepositoryMock = new Mock<IPostRepository>();

    //     // Simulate that the user already has 5 posts today
    //     var fixture = new Fixture();
    //     fixture.Customize<Post>(composer => composer.Without(x => x.Repost));
    //     var limit = fixture.CreateMany<Post>(2).ToList();

    //     postRepositoryMock.
    //         Setup(x => x.GetAllAsync(It.IsAny<Expression<Func<Post, bool>>>()))
    //         .ReturnsAsync(limit);
    //     var request = new CreatePostRequest
    //     {
    //         UserId = 1,
    //         Content = string.Empty
    //     };
    //     var useCase = new PostHandlers(postRepositoryMock.Object);
    //     var newPost = await useCase.CreatePostAsync(request);

    //     // Act & Assert
    //     Assert.False(newPost.Success);
    //     Assert.Contains(newPost.Errors, x => x.Message == "Post content is required.");
    //     Assert.Contains(newPost.Errors, x => x.Code == "CONTENT_REQUIRED");
    // }
}