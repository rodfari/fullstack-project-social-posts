using AutoFixture;
using Core.Domain.Entities;
using System.Linq.Expressions;

namespace PersistenceTests;
public class PostFixture
{
    public static List<Posts> Fixture_GetAllAsync_With_Filter_Options()
    {
        var fixture = new Fixture();
        fixture.Customize<Posts>(
            composer =>
            composer.Without(x => x.User)
            .Without(x => x.Id)
            .Without(x => x.Reposts)
            .Without(x => x.Author)
            .Without(x => x.OriginalPostId)
            .Without(x => x.AuthorId)
        );
        var post = fixture.CreateMany<Posts>(100).ToList();

        for (var i = 0; i < post.Count; i++)
        {
            post[i].Content = $"{ post[i].Content } -- Number: { i }";
        }
        return post;
    }
}