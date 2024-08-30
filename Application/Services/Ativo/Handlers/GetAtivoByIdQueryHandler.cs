using Application.Services.Ativo.Queries;
using Domain.Repositories;
using MediatR;

namespace Application.Services.Ativo.Handlers;

public class GetAtivoByIdQueryHandler : IRequestHandler<GetAtivoByIdQuery, Domain.Entities.Ativo>
{
	private readonly IAtivoRepository _repository;

	public GetAtivoByIdQueryHandler(IAtivoRepository repository)
	{
		_repository = repository;
	}

	public async Task<Domain.Entities.Ativo> Handle(GetAtivoByIdQuery request, CancellationToken cancellationToken)
	{
		return await _repository.GetById(request.Id);
	}
}