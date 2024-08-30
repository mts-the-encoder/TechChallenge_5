using Application.Services.Transacao.Queries;
using Domain.Repositories;
using MediatR;

namespace Application.Services.Transacao.Handlers;

public class GetTransacaoByIdQueryHandler : IRequestHandler<GetTransacaoByIdQuery, Domain.Entities.Transacao>
{
	private readonly ITransacaoRepository _repository;

	public GetTransacaoByIdQueryHandler(ITransacaoRepository repository)
	{
		_repository = repository;
	}

	public async Task<Domain.Entities.Transacao> Handle(GetTransacaoByIdQuery request, CancellationToken cancellationToken)
	{
		return await _repository.GetById(request.Id);
	}
}