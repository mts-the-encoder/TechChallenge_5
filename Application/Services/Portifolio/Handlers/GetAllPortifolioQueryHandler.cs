using Application.Services.Portifolio.Queries;
using Domain.Repositories;
using MediatR;

namespace Application.Services.Portifolio.Handlers;

public class GetAllPortifolioQueryHandler : IRequestHandler<GetAllPortifolioQuery, IEnumerable<Domain.Entities.Portifolio>>
{
	private readonly IPortifolioRepository _repository;

	public GetAllPortifolioQueryHandler(IPortifolioRepository repository)
	{
		_repository = repository;
	}

	public async Task<IEnumerable<Domain.Entities.Portifolio>> Handle(GetAllPortifolioQuery request, CancellationToken cancellationToken)
	{
		return await _repository.GetAll(request.Id);
	}
}