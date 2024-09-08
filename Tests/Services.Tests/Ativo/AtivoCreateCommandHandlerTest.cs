using Application.Exceptions;
using Application.Services.Ativo.Commands;
using Application.Services.Ativo.Handlers;
using Application.Services.Portifolio.Commands;
using Application.Services.Portifolio.Handlers;
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

		var command = new AtivoCommand()
		{
			Name = ativo.Name,
			TipoAtivo = ativo.TipoAtivo,
			Codigo = ativo.Codigo
		};

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
}