using Application.Services.Portifolio.Handlers;
using Application.Services.Portifolio.Queries;
using Application.Services.Transacao.Commands;
using Application.Services.Transacao.Handlers;
using Application.Services.Transacao.Queries;
using FluentAssertions;
using Tests.Utils.Entities;
using Tests.Utils.Mapper;
using Tests.Utils.Repositories;

namespace Tests.Services.Tests.Transacao;

public class GetByIdTransacaoQueryHandlerTest
{
	[Fact]
	private async Task Should_Create()
	{
		var user = UserBuilder.Build();
		var portifolio = PortifolioBuilder.Build(user);
		var ativo = AtivoBuilder.Build();
		var transacao = TransacaoBuilder.Build(portifolio, ativo);

		var command = new TransacaoCreateCommand()
		{
			PortifolioId = transacao.PortifolioId,
			AtivoId = transacao.AtivoId,
			Quantity = transacao.Quantity,
			Price = transacao.Price
		};

		var repo = TransacaoRepositoryBuilder.Instance().Build();
		var mapper = MapperBuilder.Instance();

		var handler = new TransacaoCreateCommandHandler(repo, mapper);

		var result = await handler.Handle(command, default);
		var query = new GetTransacaoByIdQuery(result.Id);
		var getHandler = new GetTransacaoByIdQueryHandler(repo);

		var action = async () => { await getHandler.Handle(query, default); };

		await action.Should().NotThrowAsync();
	}
}