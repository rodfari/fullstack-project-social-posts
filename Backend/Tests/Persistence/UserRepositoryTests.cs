using AutoFixture;
using Core.Domain.Entities;
using Infrastructure.Persistence.mySQL;
using Infrastructure.Persistence.mySQL.Repository;
using Microsoft.EntityFrameworkCore;
using Shouldly;

namespace PersistenceTests;

public class UserRepositoryTests
{
    [Fact]
    public async void Create_User_Success()
    {
        var options = new DbContextOptionsBuilder<DataContext>()
           .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
           .Options;

        var dataContext = new DataContext(options);
        var userRepository = new UserRepository(dataContext);

        Fixture builders = new Fixture();
        var user = builders.Create<User>();
        var createUser = await userRepository.AddAsync(user);

        user.ShouldNotBeNull();
        user.Username.ShouldBe(createUser.Username);
        user.CreatedAt.ShouldBe(createUser.CreatedAt);
    }
    

    // [Fact]
    // public async void Should_Throw_Exception_When_Trying_Adding_Same_User_Name_Twice()
    // {
    //     var options = new DbContextOptionsBuilder<DataContext>()
    //        .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
    //        .Options;
        

    //     var dataContext = new DataContext(options);
    //     var userRepository = new UserRepository(dataContext);

    //     Fixture builders = new Fixture();
    //     builders.Customize<User>(composer => composer.With(p => p.Username, "SameUsername"));
    //     var user = builders.CreateMany<User>(2).ToList();
        
    //     user.ForEach(async x => await userRepository.AddAsync(x));


    // }


    [Fact]
    public async void GetUserById()
    {
        var options = new DbContextOptionsBuilder<DataContext>()
           .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
           .Options;

        var dataContext = new DataContext(options);
        var userRepository = new UserRepository(dataContext);

        Fixture builders = new Fixture();
        var user = builders.Create<User>();
        await userRepository.AddAsync(user);
        var createUser = await userRepository.GetByIdAsync(user.Id);

        user.ShouldNotBeNull();
        user.Username.ShouldBe(createUser.Username);
        user.CreatedAt.ShouldBe(createUser.CreatedAt);
    }
}