using Application.Services.Transacao.Queries;
using Domain.Repositories;
using MediatR;

namespace Application.Services.Transacao.Handlers;

public class GetAllTransacaoQueryHandler : IRequestHandler<GetAllTransacaoQuery, IEnumerable<Domain.Entities.Transacao>>
{
	private readonly ITransacaoRepository _repository;

	public GetAllTransacaoQueryHandler(ITransacaoRepository repository)
	{
		_repository = repository;
	}

	public async Task<IEnumerable<Domain.Entities.Transacao>> Handle(GetAllTransacaoQuery request, CancellationToken cancellationToken)
	{
		return await _repository.GetAll(request.Id);
	}
}