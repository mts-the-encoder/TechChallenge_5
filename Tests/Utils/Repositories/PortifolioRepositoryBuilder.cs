using Domain.Entities;
using Domain.Repositories;
using Moq;

namespace Tests.Utils.Repositories;

public class PortifolioRepositoryBuilder
{
	private static PortifolioRepositoryBuilder _instance;
	private readonly Mock<IPortifolioRepository> _repository;

	private PortifolioRepositoryBuilder()
	{
		_repository ??= new Mock<IPortifolioRepository>();
	}

	public static PortifolioRepositoryBuilder Instance()
	{
		_instance = new PortifolioRepositoryBuilder();
		return _instance;
	}

	public IPortifolioRepository Build()
	{
		return _repository.Object;
	}

	public PortifolioRepositoryBuilder GetById(Portifolio Portifolio)
	{
		if (!string.IsNullOrWhiteSpace(Portifolio.Id.ToString()))
			_repository.Setup(i => i.GetById(Portifolio.Id)).ReturnsAsync(Portifolio);

		return this;
	}

	public PortifolioRepositoryBuilder Create(Portifolio Portifolio)
	{
		_repository.Setup(x => x.Create(Portifolio));

		return this;
	}
}