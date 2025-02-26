using System.Linq.Expressions;
using Application.Feature.Posts.Queries;
using Core.Application.Feature.Posts.Queries;
using Core.Domain.Contracts;
using Core.Domain.Entities;
using Moq;
using Shouldly;

namespace ApplicationTests;

public class GetPostQueryHandlerTests
{
    [Fact]
    public async void Get_Should_Not_Trhow_Exception_When_Post_Is_Not_Found()
    {
        var _postRepositoryMock = new Mock<IPostsRepository>();

        _postRepositoryMock
            .Setup(x => x.GetAllAsync(It.IsAny<Expression<Func<Posts, bool>>>()));

        var handler = new GetAllPostsQueryHandler(_postRepositoryMock.Object);
        var result = await handler.Handle(new GetAllPostsQuery(), CancellationToken.None);

        result.Success.ShouldBeTrue();
        result.Data.Count.ShouldBe(0);
        
    }
}