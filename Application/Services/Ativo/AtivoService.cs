using Application.Communication.Requests;
using Application.Communication.Responses;
using Application.Services.Ativo.Commands;
using AutoMapper;
using FluentValidation;
using MediatR;
using Serilog;

namespace Application.Services.Ativo;

public class AtivoService
{
	private readonly IMediator _mediator;
	private readonly IMapper _mapper;

	public AtivoService(IMediator mediator, IMapper mapper)
	{
		_mediator = mediator;
		_mapper = mapper;
	}

	public async Task<AtivoResponse> Create(AtivoRequest request)
	{
		await Validate(request);

		var ativo = _mapper.Map<AtivoCreateCommand>(request);

		var response = await _mediator.Send(ativo);

		return _mapper.Map<AtivoResponse>(response);
	}

	private async Task Validate(AtivoRequest request)
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