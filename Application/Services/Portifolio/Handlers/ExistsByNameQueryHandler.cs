using Application.Services.Portifolio.Queries;
using Domain.Repositories;
using MediatR;

namespace Application.Services.Portifolio.Handlers;

public class ExistsByNameQueryHandler : IRequestHandler<ExistsByNameQuery, bool>
{
	private readonly IPortifolioRepository _repository;

	public ExistsByNameQueryHandler(IPortifolioRepository repository)
	{
		_repository = repository;
	}

	public async Task<bool> Handle(ExistsByNameQuery request, CancellationToken cancellationToken)
	{
		return await _repository.ExistsByName(request.Name);
	}
}