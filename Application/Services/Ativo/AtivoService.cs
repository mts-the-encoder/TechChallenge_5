using Application.Communication.Responses;
using Application.Exceptions;
using Application.Interfaces;
using Application.Services.Ativo.Commands;
using Application.Services.Ativo.Queries;
using AutoMapper;
using FluentValidation;
using MediatR;
using Serilog;

namespace Application.Services.Ativo;

public class AtivoService : IAtivoService
{
	private readonly IMediator _mediator;
	private readonly IMapper _mapper;

	public AtivoService(IMediator mediator, IMapper mapper)
	{
		_mediator = mediator;
		_mapper = mapper;
	}

	public async Task<AtivoResponse> Create(AtivoCommand request)
	{
		await Validate(request);

		var ativo = _mapper.Map<AtivoCreateCommand>(request);

		var response = await _mediator.Send(ativo);

		return _mapper.Map<AtivoResponse>(response);
	}

	public async Task<AtivoResponse> GetById(Guid id)
	{
		var ativo = new GetAtivoByIdQuery(id);

		if (ativo is null) throw new ValidationErrorsException(new List<string> { "Não encontrado" });

		var result = await _mediator.Send(ativo);

		return _mapper.Map<AtivoResponse>(result);
	}

	public async Task<IEnumerable<AtivoResponse>> GetAll()
	{
		var ativos = new GetAllAtivoQuery();

		if (ativos is null) throw new ValidationErrorsException(new List<string> { "Não encontrado" });

		var result = await _mediator.Send(ativos);

		return _mapper.Map<IEnumerable<AtivoResponse>>(result);
	}

	public async Task<AtivoResponse> Update(AtivoUpdateCommand request)
	{
		var response = await _mediator.Send(request);

		return _mapper.Map<AtivoResponse>(response);
	}

	private async Task Validate(AtivoCommand request)
	{
		var validator = new AtivoValidator();
		var result = await validator.ValidateAsync(request);

		if (!result.IsValid)
		{
			var errorMessages = result.Errors
				.Select(error => error.ErrorMessage).ToList().FirstOrDefault();

			var concatenatedErrors = string.Join("\n", errorMessages);

			Log.ForContext("AtivoName", request.Name)
				.Error($"{concatenatedErrors}");

			throw new ValidationException(errorMessages);
		}
	}
}