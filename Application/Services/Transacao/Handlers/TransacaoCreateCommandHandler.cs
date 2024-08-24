using Application.Services.Transacao.Commands;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.Services.Transacao.Handlers;

public class TransacaoCreateCommandHandler : IRequestHandler<TransacaoCreateCommand, Domain.Entities.Transacao>
{
	private readonly ITransacaoRepository _repository;
	private readonly IMapper _mapper;

	public TransacaoCreateCommandHandler(ITransacaoRepository repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task<Domain.Entities.Transacao> Handle(TransacaoCreateCommand request, CancellationToken cancellationToken)
	{
		var transacao = _mapper.Map<Domain.Entities.Transacao>(request);

		if (transacao is null) throw new ApplicationException($"Error creating entity");

		await _repository.Create(transacao);

		return transacao;
	}
}