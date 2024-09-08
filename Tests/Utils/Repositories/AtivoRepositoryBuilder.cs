using Domain.Entities;
using Domain.Repositories;
using Moq;

namespace Tests.Utils.Repositories;

public class AtivoRepositoryBuilder
{
	private static AtivoRepositoryBuilder _instance;
	private readonly Mock<IAtivoRepository> _repository;

	private AtivoRepositoryBuilder()
	{
		_repository ??= new Mock<IAtivoRepository>();
	}

	public static AtivoRepositoryBuilder Instance()
	{
		_instance = new AtivoRepositoryBuilder();
		return _instance;
	}

	public IAtivoRepository Build()
	{
		return _repository.Object;
	}

	public AtivoRepositoryBuilder GetById(Ativo Ativo)
	{
		if (!string.IsNullOrWhiteSpace(Ativo.Id.ToString()))
			_repository.Setup(i => i.GetById(Ativo.Id)).ReturnsAsync(Ativo);

		return this;
	}

	public AtivoRepositoryBuilder Create(Ativo Ativo)
	{
		_repository.Setup(x => x.Create(Ativo));

		return this;
	}
}