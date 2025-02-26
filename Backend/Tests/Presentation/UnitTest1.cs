using Api.Controllers;
using Core.Application.Feature.Posts.Queries;
using MediatR;
using NSubstitute;

namespace Api;

public class PostControllerTests
{
    // [Fact]
    // public void getPostsTest()
    // {
    //     // Arrange
    //     var mediator = Substitute.For<IMediator>();
    //     var controller = new PostsController(mediator);
    //     var query = new GetAllPostsQuery { Page = 1, PageSize = 10, Keyword = "keyword", Sort = "sort" };
    //     var result = new List<GetAllPostsResponse> { new GetAllPostsResponse { Id = 1, Content = "content" } };
    //     //mediator.Setup(x => x.Send(query, It.IsAny<CancellationToken>())).ReturnsAsync(result);
    //     mediator.Send(query, Arg.Any<CancellationToken>()).Returns(result);
    //     // Act
    //     var response = controller.GetPosts(1, 10, "keyword", "sort").Result as OkObjectResult;

    //     // Assert
    //     response.ShouldNotBeNull();
    //     response.Value.ShouldBe(result);   
    // }
}