using Application.Exceptions;
using Application.Services.Ativo.Commands;
using Application.Services.Ativo.Handlers;
using FluentAssertions;
using Tests.Utils.Entities;
using Tests.Utils.Mapper;
using Tests.Utils.Repositories;

namespace Tests.Services.Tests.Ativo;

public class AtivoCreateCommandHandlerTest
{
	[Fact]
	private async Task Should_Create()
	{
		var ativo = AtivoBuilder.Build();

		var repo = AtivoRepositoryBuilder.Instance().Build();
		var mapper = MapperBuilder.Instance();

		var ativoCommand = mapper.Map<AtivoCreateCommand>(ativo);

		var handler = new AtivoCreateCommandHandler(repo, mapper);

		var result = await handler.Handle(ativoCommand, default);

		result.Name.Should().NotBeEmpty();
		result.Should().NotBeNull();
	}

	[Fact]
	private async Task Should_Throw_Exception()
	{
		var command = new AtivoCreateCommand();

		var repo = AtivoRepositoryBuilder.Instance().Build();
		var mapper = MapperBuilder.Instance();

		var handler = new AtivoCreateCommandHandler(repo, mapper);

		var action = async () => { await handler.Handle(command, default); };

		await action.Should().ThrowAsync<ValidationErrorsException>();
	}

	[Fact]
	private async Task Should_Throw_Exception_Code_Null()
	{
		var ativo = AtivoBuilder.Build();
		ativo.Codigo = string.Empty;

		var repo = AtivoRepositoryBuilder.Instance().Build();
		var mapper = MapperBuilder.Instance();

		var ativoCommand = mapper.Map<AtivoCreateCommand>(ativo);

		var handler = new AtivoCreateCommandHandler(repo, mapper);

		var action = async () => { await handler.Handle(ativoCommand, default); };

		await action.Should().ThrowAsync<ValidationErrorsException>();

		ativoCommand.Codigo.Should().BeNullOrWhiteSpace();
	}

	[Fact]
	private async Task Should_Throw_Exception_Name_Null()
	{
		var ativo = AtivoBuilder.Build();
		ativo.Name = string.Empty;

		var repo = AtivoRepositoryBuilder.Instance().Build();
		var mapper = MapperBuilder.Instance();

		var ativoCommand = mapper.Map<AtivoCreateCommand>(ativo);

		var handler = new AtivoCreateCommandHandler(repo, mapper);

		var action = async () => { await handler.Handle(ativoCommand, default); };

		await action.Should().ThrowAsync<ValidationErrorsException>();

		ativoCommand.Name.Should().BeNullOrWhiteSpace();
	}
}