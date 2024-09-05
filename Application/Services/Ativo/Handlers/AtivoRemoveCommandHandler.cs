using Application.Exceptions;
using Application.Services.Ativo.Commands;
using Domain.Repositories;
using MediatR;

namespace Application.Services.Ativo.Handlers;

public class AtivoRemoveCommandHandler : IRequestHandler<AtivoRemoveCommand, Domain.Entities.Ativo>
{
	private readonly IAtivoRepository _repository;

	public AtivoRemoveCommandHandler(IAtivoRepository repository)
	{
		_repository = repository;
	}

	public async Task<Domain.Entities.Ativo> Handle(AtivoRemoveCommand request, CancellationToken cancellationToken)
	{
		var ativo = await _repository.GetById(request.Id);

		if (ativo is null) throw new ValidationErrorsException(new List<string> { "Não encontrado" });

		var result = await _repository.RemoveAsync(ativo);
		return result;
	}
}