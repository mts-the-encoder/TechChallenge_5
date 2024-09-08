using Domain.Entities;
using Domain.Repositories;
using Moq;

namespace Tests.Utils.Repositories;

public class TransacaoRepositoryBuilder
{
	private static TransacaoRepositoryBuilder _instance;
	private readonly Mock<ITransacaoRepository> _repository;

	private TransacaoRepositoryBuilder()
	{
		_repository ??= new Mock<ITransacaoRepository>();
	}

	public static TransacaoRepositoryBuilder Instance()
	{
		_instance = new TransacaoRepositoryBuilder();
		return _instance;
	}

	public ITransacaoRepository Build()
	{
		return _repository.Object;
	}

	public TransacaoRepositoryBuilder GetById(Transacao Transacao)
	{
		if (!string.IsNullOrWhiteSpace(Transacao.Id.ToString()))
			_repository.Setup(i => i.GetById(Transacao.Id)).ReturnsAsync(Transacao);

		return this;
	}

	public TransacaoRepositoryBuilder Create(Transacao Transacao)
	{
		_repository.Setup(x => x.Create(Transacao));

		return this;
	}
}