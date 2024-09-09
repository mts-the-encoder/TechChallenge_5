using Application.Exceptions;
using Application.Services.Ativo.Commands;
using Application.Services.Ativo.Handlers;
using FluentAssertions;
using Tests.Utils.Entities;
using Tests.Utils.Mapper;
using Tests.Utils.Repositories;

namespace Tests.Services.Tests.Ativo;

public class AtivoUpdateCommandHandlerTest
{
	[Fact]
	private async Task Should_Update()
	{
		var ativo = AtivoBuilder.Build();

		var repo = AtivoRepositoryBuilder.Instance().Build();
		var mapper = MapperBuilder.Instance();

		var ativoCommand = mapper.Map<AtivoCreateCommand>(ativo);

		var handler = new AtivoCreateCommandHandler(repo, mapper);

		var result = await handler.Handle(ativoCommand, default);

		result.Codigo = "HGLG11";
		var updateCommand = mapper.Map<AtivoUpdateCommand>(result);

		var handlerUpdate = new AtivoUpdateCommandHandler(repo, mapper);
		var resultUpdate = await handlerUpdate.Handle(updateCommand, default);

		resultUpdate.Name.Should().NotBeEmpty();
		resultUpdate.Should().NotBeNull();
	}

	[Fact]
	private async Task Should_Throw_Exception()
	{
		var ativo = AtivoBuilder.Build();

		var repo = AtivoRepositoryBuilder.Instance().Build();
		var mapper = MapperBuilder.Instance();

		var ativoCommand = mapper.Map<AtivoCreateCommand>(ativo);

		var handler = new AtivoCreateCommandHandler(repo, mapper);

		var result = await handler.Handle(ativoCommand, default);

		result.Codigo = "HGLG11";
		var updateCommand = mapper.Map<AtivoUpdateCommand>(result);

		var handlerUpdate = new AtivoUpdateCommandHandler(repo, mapper);

		var action = async () => { await handlerUpdate.Handle(updateCommand, default); };

		await action.Should().ThrowAsync<ValidationErrorsException>();
	}
}