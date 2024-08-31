using Application.Exceptions;
using Application.Services.User.Commands;
using Application.Services.User.Handlers;
using FluentAssertions;
using Tests.Utils.Entities;
using Tests.Utils.Mapper;
using Tests.Utils.Repositories;

namespace Tests.Services.Tests.User;

public class CreateUserCommandHandlerTests
{
    [Fact]
    private async Task Should_Create()
    {
        var user = UserBuilder.Build();

        var command = new UserCreateCommand
        {
            Name = user.Name,
            Email = user.Email,
            Password = user.Password
        };

        var repo = UserRepositoryBuilder.Instance().Build();
        var mapper = MapperBuilder.Instance();

        var handler = new UserCreateCommandHandler(repo, mapper);

        var result = await handler.Handle(command, default);

        result.Name.Should().NotBeEmpty();
        result.Should().NotBeNull();
    }

    [Fact]
    private async Task Should_Throw_Exception()
    {
	    var command = new UserCreateCommand();

	    var repo = UserRepositoryBuilder.Instance().Build();
	    var mapper = MapperBuilder.Instance();

	    var handler = new UserCreateCommandHandler(repo, mapper);

	    var action = async () => { await handler.Handle(command, default); };

	    await action.Should().ThrowAsync<ValidationErrorsException>();
    }
}