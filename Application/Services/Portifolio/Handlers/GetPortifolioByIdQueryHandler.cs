using Application.Services.Portifolio.Queries;
using Domain.Repositories;
using MediatR;

namespace Application.Services.Portifolio.Handlers;

public class GetPortifolioByIdQueryHandler : IRequestHandler<GetPortifolioByIdQuery, Domain.Entities.Portifolio>
{
	private readonly IPortifolioRepository _repository;

	public GetPortifolioByIdQueryHandler(IPortifolioRepository repository)
	{
		_repository = repository;
	}

	public async Task<Domain.Entities.Portifolio> Handle(GetPortifolioByIdQuery request, CancellationToken cancellationToken)
	{
		return await _repository.GetById(request.Id);
	}
}