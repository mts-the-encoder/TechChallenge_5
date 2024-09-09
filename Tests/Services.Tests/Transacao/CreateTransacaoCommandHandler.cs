using Application.Exceptions;
using Application.Services.Transacao.Commands;
using Application.Services.Transacao.Handlers;
using FluentAssertions;
using Tests.Utils.Entities;
using Tests.Utils.Mapper;
using Tests.Utils.Repositories;

namespace Tests.Services.Tests.Transacao;

public class CreateTransacaoCommandHandler
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

		result.Quantity.Should().BeGreaterThan(1);
		result.Should().NotBeNull();
	}

	[Fact]
	private async Task Should_Throw_Exception()
	{
		var command = new TransacaoCreateCommand();
		command.Price = 4;

		var repo = TransacaoRepositoryBuilder.Instance().Build();
		var mapper = MapperBuilder.Instance();

		var handler = new TransacaoCreateCommandHandler(repo, mapper);

		var action = async () => { await handler.Handle(command, default); };

		await action.Should().ThrowAsync<ValidationErrorsException>();
	}

	[Fact]
	private async Task Should_Throw_Exception_PortifolioId_Null()
	{
		var user = UserBuilder.Build();
		var portifolio = PortifolioBuilder.Build(user);
		var ativo = AtivoBuilder.Build();
		var transacao = TransacaoBuilder.Build(portifolio, ativo);

		var command = new TransacaoCreateCommand()
		{
			PortifolioId = Guid.Empty,
			AtivoId = transacao.PortifolioId,
			Quantity = transacao.Quantity,
			Price = transacao.Price
		};

		var repo = TransacaoRepositoryBuilder.Instance().Build();
		var mapper = MapperBuilder.Instance();

		var handler = new TransacaoCreateCommandHandler(repo, mapper);

		var action = async () => { await handler.Handle(command, default); };

		await action.Should().ThrowAsync<ValidationErrorsException>();
	}

	[Fact]
	private async Task Should_Throw_Exception_AtivoId_Null()
	{
		var user = UserBuilder.Build();
		var portifolio = PortifolioBuilder.Build(user);
		var ativo = AtivoBuilder.Build();
		var transacao = TransacaoBuilder.Build(portifolio, ativo);

		var command = new TransacaoCreateCommand()
		{
			PortifolioId = portifolio.Id,
			AtivoId = Guid.Empty,
			Quantity = transacao.Quantity,
			Price = transacao.Price
		};

		var repo = TransacaoRepositoryBuilder.Instance().Build();
		var mapper = MapperBuilder.Instance();

		var handler = new TransacaoCreateCommandHandler(repo, mapper);

		var action = async () => { await handler.Handle(command, default); };

		await action.Should().ThrowAsync<ValidationErrorsException>();
	}

	[Fact]
	private async Task Should_Throw_Exception_Price_Low()
	{
		var user = UserBuilder.Build();
		var portifolio = PortifolioBuilder.Build(user);
		var ativo = AtivoBuilder.Build();
		var transacao = TransacaoBuilder.Build(portifolio, ativo);

		var command = new TransacaoCreateCommand()
		{
			PortifolioId = portifolio.Id,
			AtivoId = ativo.Id,
			Quantity = transacao.Quantity,
			Price = 4
		};

		var repo = TransacaoRepositoryBuilder.Instance().Build();
		var mapper = MapperBuilder.Instance();

		var handler = new TransacaoCreateCommandHandler(repo, mapper);

		var action = async () => { await handler.Handle(command, default); };

		await action.Should().ThrowAsync<ValidationErrorsException>();
	}

	[Fact]
	private async Task Should_Throw_Exception_Quantity_Low()
	{
		var user = UserBuilder.Build();
		var portifolio = PortifolioBuilder.Build(user);
		var ativo = AtivoBuilder.Build();
		var transacao = TransacaoBuilder.Build(portifolio, ativo);

		var command = new TransacaoCreateCommand()
		{
			PortifolioId = portifolio.Id,
			AtivoId = ativo.Id,
			Quantity = 0,
			Price = transacao.Price
		};

		var repo = TransacaoRepositoryBuilder.Instance().Build();
		var mapper = MapperBuilder.Instance();

		var handler = new TransacaoCreateCommandHandler(repo, mapper);

		var action = async () => { await handler.Handle(command, default); };

		await action.Should().ThrowAsync<ValidationErrorsException>();
	}
}