using Application.Exceptions;
using Application.Services.Portifolio.Commands;
using Application.Services.Portifolio.Handlers;
using FluentAssertions;
using Tests.Utils.Entities;
using Tests.Utils.Mapper;
using Tests.Utils.Repositories;

namespace Tests.Services.Tests.Potifolio;

public class CreatePortifolioCommandHandlerTest
{
	[Fact]
	private async Task Should_Create()
	{
		var user = UserBuilder.Build();
		var portifolio = PortifolioBuilder.Build(user);

		var command = new PortifolioCreateCommand()
		{
			UserId = user.Id,
			Name = portifolio.Name,
			Description = portifolio.Description
		};

		var repo = PortifolioRepositoryBuilder.Instance().Build();
		var mapper = MapperBuilder.Instance();

		var handler = new PortifolioCreateCommandHandler(repo, mapper);

		var result = await handler.Handle(command, default);

		result.Name.Should().NotBeEmpty();
		result.Should().NotBeNull();
	}

	[Fact]
	private async Task Should_Throw_Exception()
	{
		var command = new PortifolioCreateCommand();

		var repo = PortifolioRepositoryBuilder.Instance().Build();
		var mapper = MapperBuilder.Instance();

		var handler = new PortifolioCreateCommandHandler(repo, mapper);

		var action = async () => { await handler.Handle(command, default); };

		await action.Should().ThrowAsync<ValidationErrorsException>();
	}

	[Fact]
	private async Task Should_Throw_Exception_UserId_Null()
	{
		var user = UserBuilder.Build();
		var portifolio = PortifolioBuilder.Build(user);

		var command = new PortifolioCreateCommand()
		{
			UserId = Guid.Empty,
			Name = portifolio.Name,
			Description = portifolio.Description
		};

		var repo = PortifolioRepositoryBuilder.Instance().Build();
		var mapper = MapperBuilder.Instance();

		var handler = new PortifolioCreateCommandHandler(repo, mapper);

		var action = async () => { await handler.Handle(command, default); };

		await action.Should().ThrowAsync<ValidationErrorsException>();

		command.UserId.Should().BeEmpty();
	}

	[Fact]
	private async Task Should_Throw_Exception_Name_Null()
	{
		var user = UserBuilder.Build();
		var portifolio = PortifolioBuilder.Build(user);

		var command = new PortifolioCreateCommand()
		{
			UserId = user.Id,
			Name = string.Empty,
			Description = portifolio.Description
		};

		var repo = PortifolioRepositoryBuilder.Instance().Build();
		var mapper = MapperBuilder.Instance();

		var handler = new PortifolioCreateCommandHandler(repo, mapper);

		var action = async () => { await handler.Handle(command, default); };

		await action.Should().ThrowAsync<ValidationErrorsException>();

		command.Name.Should().BeNullOrWhiteSpace();
	}
}