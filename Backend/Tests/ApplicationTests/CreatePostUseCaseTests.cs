using Core.Application.Handlers;
using Core.Application.Requests;
using Core.Domain.Contracts;
using Core.Domain.Entities;
using Moq;

namespace ApplicationTests;

public class CreatePostUseCaseTests
{
    [Fact]
    public async Task Should_CreatePost_When_ValidRequest()
    {
        // Arrange
        // var postRepositoryMock = new Mock<IPostRepository>();

        

        // var useCase =  new PostHandlers(postRepositoryMock.Object);

        // var request = new CreatePostRequest
        // {
        //     UserId = 1,
        //     Content = "Hello, world!"
        // };

        // // Act
        // await useCase.ExecuteAsync(request);

        // // Assert
        // postRepositoryMock.Verify(repo => repo.AddAsync(It.IsAny<Post>()), Times.Once);
        // dailyPostLimitRepositoryMock.Verify(repo => repo.AddAsync(It.IsAny<DailyPostLimit>()), Times.Once);
    }


    [Fact]
    public async Task Should_ThrowInvalidOperationException_When_DailyPostLimitReached()
    {
        // Arrange
        // var postRepositoryMock = new Mock<IPostRepository>();
        // var dailyPostLimitRepositoryMock = new Mock<IDailyPostLimitRepository>();

        // // Simulate that the user already has 5 posts today
        // dailyPostLimitRepositoryMock
        //     .Setup(repo => repo.FindAsync(It.IsAny<Func<DailyPostLimit, bool>>()))
        //     .ReturnsAsync(new List<DailyPostLimit>
        //     {
        //         new DailyPostLimit
        //         {
        //             Id = 1,
        //             CreatedAt = DateTime.UtcNow.Date,
        //             PostCount = 5 // Maximum limit reached
        //         }
        //     });

        // var useCase = new PostHandlers(postRepositoryMock.Object, dailyPostLimitRepositoryMock.Object);

        // var request = new CreatePostRequest
        // {
        //     UserId = 1,
        //     Content = "This is a test post."
        // };

        // // Act & Assert
        // var exception = await Assert.ThrowsAsync<InvalidOperationException>(() => useCase.ExecuteAsync(request));
        // Assert.Equal("Daily post limit of 5 reached.", exception.Message);
    }
}