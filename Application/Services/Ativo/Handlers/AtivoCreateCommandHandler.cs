using Application.Exceptions;
using Application.Services.Ativo.Commands;
using Application.Services.Transacao.Commands;
using Application.Services.Transacao;
using AutoMapper;
using Domain.Repositories;
using MediatR;
using Serilog;

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
		await Validate(request);

		var ativo = _mapper.Map<Domain.Entities.Ativo>(request);

		await _repository.Create(ativo);

		return ativo;
	}

	private async Task Validate(AtivoCreateCommand request)
	{
		var validator = new AtivoValidator();
		var result = await validator.ValidateAsync(request);

		if (!result.IsValid)
		{
			var errorMessages = result.Errors
				.Select(error => error.ErrorMessage).ToList();

			var concatenatedErrors = string.Join("\n", errorMessages);

			Log.ForContext("Ativo", request.Codigo)
				.Error($"{concatenatedErrors}");

			throw new ValidationErrorsException(errorMessages);
		}
	}
}