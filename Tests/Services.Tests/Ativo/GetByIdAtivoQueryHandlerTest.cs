using Application.Services.Ativo.Commands;
using Application.Services.Ativo.Handlers;
using Application.Services.Ativo.Queries;
using FluentAssertions;
using Tests.Utils.Entities;
using Tests.Utils.Mapper;
using Tests.Utils.Repositories;

namespace Tests.Services.Tests.Ativo;

public class GetByIdAtivoQueryHandlerTest
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

		var query = new GetAtivoByIdQuery(result.Id);
		var getHandler = new GetAtivoByIdQueryHandler(repo);

		var action = async () => { await getHandler.Handle(query, default); };

		await action.Should().NotThrowAsync();
	}
}