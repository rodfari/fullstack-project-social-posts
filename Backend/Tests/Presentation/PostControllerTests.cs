using Api.Controllers;
using Core.Application.Dtos;
using Core.Application.Feature.Posts.Queries;
using Core.Application.Reponses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Shouldly;


namespace Api;

public class PostControllerTests
{
    [Fact]
    public async Task getPostsTest()
    {
        // Arrange
        var mediator = Substitute.For<IMediator>();
        mediator.Send(Arg.Any<GetAllPostsQuery>(), Arg.Any<CancellationToken>()).Returns(new TResponse<List<PostDto>>());
        var controller = new PostsController(mediator);
        
        // Act
        var result = await controller.GetPosts(1, 10, "keyword", "trending");

        // Assert
        result.ShouldBeOfType<OkObjectResult>();
    }
}