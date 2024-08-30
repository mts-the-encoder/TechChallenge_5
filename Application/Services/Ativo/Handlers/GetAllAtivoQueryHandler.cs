using Application.Services.Ativo.Queries;
using Domain.Repositories;
using MediatR;

namespace Application.Services.Ativo.Handlers;

public class GetAllAtivoQueryHandler : IRequestHandler<GetAllAtivoQuery, IEnumerable<Domain.Entities.Ativo>>
{
	private readonly IAtivoRepository _repository;

	public GetAllAtivoQueryHandler(IAtivoRepository repository)
	{
		_repository = repository;
	}

	public async Task<IEnumerable<Domain.Entities.Ativo>> Handle(GetAllAtivoQuery request, CancellationToken cancellationToken)
	{
		return await _repository.GetAll();
	}
}