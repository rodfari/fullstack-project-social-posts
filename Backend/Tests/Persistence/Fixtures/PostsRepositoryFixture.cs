using System.Threading.Tasks;
using Bogus;
using Core.Domain.Entities;
using Infrastructure.Persistence.mySQL;
using Microsoft.EntityFrameworkCore;

namespace PersistenceTests.Fixtures;

public class PostsRepositoryFixture : IDisposable
{
    private int userId {get;set;}
    public DataContext DataContext { get; private set; }

    public PostsRepositoryFixture setUser()
    {
        var faker = new Faker<User>()
            .RuleFor(x => x.Username, f => f.Internet.UserName())
            .RuleFor(x => x.IsDeleted, false)
            .RuleFor(x => x.CreatedAt, DateTime.Now)
            .RuleFor(x => x.UpdatedAt, DateTime.Now);

        var user = faker.Generate();
        if (DataContext == null) { throw new Exception("DataContext must be initiated"); }
        DataContext.Add(user);
        DataContext.SaveChanges();
        this.userId = user.Id;
        return this;
    }
    public PostsRepositoryFixture SetContentWithMatchWord(int amount = 1)
    {
        var fake = new Faker<Posts>()
            .RuleFor(p => p.UserId, this.userId)
            .RuleFor(p => p.CreatedAt, DateTime.Now)
            .RuleFor(p => p.UpdatedAt, DateTime.Now)
            .RuleFor(p => p.IsDeleted, false)
            .RuleFor(p => p.IsRepost, false)
            .RuleFor(p => p.Content, f => $"filter word {f.Lorem.Sentence()}")
            .RuleFor(p => p.RepostCount, 0);

        var posts = fake.Generate(amount);
        if (DataContext == null) { throw new Exception("DataContext must be initiated"); }
        DataContext.AddRange(posts);
        DataContext.SaveChanges();
        return this;
    }

    public PostsRepositoryFixture SetContent(int amount = 1)
    {
        var fake = new Faker<Posts>()
            .RuleFor(p => p.UserId, this.userId)
            .RuleFor(p => p.CreatedAt, DateTime.Now)
            .RuleFor(p => p.UpdatedAt, DateTime.Now)
            .RuleFor(p => p.IsDeleted, false)
            .RuleFor(p => p.IsRepost, false)
            .RuleFor(p => p.Content, f => $"{f.Lorem.Sentence()}")
            .RuleFor(p => p.RepostCount, 0);

        var posts = fake.Generate(amount);
        if (DataContext == null) { throw new Exception("DataContext must be initiated"); }
        DataContext.AddRange(posts);
        DataContext.SaveChanges();
        return this;
    }

    public async Task<PostsRepositoryFixture> setTrendingPost(){
        var trending = new Faker<Posts>()
        .RuleFor(c => c.Content, "this is a trending post")
        .RuleFor(c => c.UserId, this.userId)
        .RuleFor(c => c.CreatedAt, DateTime.Now)
        .RuleFor(c => c.UpdatedAt, DateTime.Now)
        .RuleFor(c => c.IsDeleted, false)
        .RuleFor(c => c.IsRepost, false)
        .RuleFor(c => c.RepostCount, 102)
        .Generate();
        if (DataContext == null) { throw new Exception("DataContext must be initiated"); }
        DataContext.Add(trending);
        DataContext.SaveChanges();

        return this;
    }
    public PostsRepositoryFixture InitDataContext()
    {
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        DataContext = new DataContext(options);

        return this;
    }

    public void Dispose()
    {
        DataContext?.Dispose();
    }
}