using Application.Exceptions;
using Application.Services.Ativo.Commands;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.Services.Ativo.Handlers;

public class AtivoUpdateCommandHandler : IRequestHandler<AtivoUpdateCommand, Domain.Entities.Ativo>
{
	private readonly IAtivoRepository _repository;
	private readonly IMapper _mapper;

	public AtivoUpdateCommandHandler(IAtivoRepository repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task<Domain.Entities.Ativo> Handle(AtivoUpdateCommand request, CancellationToken cancellationToken)
	{
		var ativo = await _repository.GetById(request.Id);

		if (ativo is null) throw new ValidationErrorsException(new List<string> { "Não encontrado" });

		ativo = _mapper.Map<Domain.Entities.Ativo>(request);
		return await _repository.UpdateAsync(ativo);
	}
}