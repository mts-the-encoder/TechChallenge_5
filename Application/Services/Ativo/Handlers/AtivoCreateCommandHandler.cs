using Application.Services.Ativo.Commands;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.Services.Ativo.Handlers;

public class AtivoCreateCommandHandler : IRequestHandler<AtivoCreateCommand, Domain.Entities.Ativo>
{
	private readonly IAtivoRepository _repository;
	private readonly IMapper _mapper;

	public AtivoCreateCommandHandler(IAtivoRepository repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task<Domain.Entities.Ativo> Handle(AtivoCreateCommand request, CancellationToken cancellationToken)
	{
		var ativo = _mapper.Map<Domain.Entities.Ativo>(request);

		if (ativo is null) throw new ApplicationException($"Error creating entity");

		await _repository.Create(ativo);

		return ativo;
	}
}