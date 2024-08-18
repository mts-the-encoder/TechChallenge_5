using Application.Communication.Requests;
using Application.Communication.Responses;
using Application.Interfaces;
using Application.Services.Portifolio.Commands;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Serilog;

namespace Application.Services.Portifolio;

public class PortifolioService : IPortifolioService
{
	private readonly IMediator _mediator;
	private readonly IMapper _mapper;

	public PortifolioService(IMediator mediator, IMapper mapper)
	{
		_mediator = mediator;
		_mapper = mapper;
	}

	public async Task<PortifolioResponse> Create(PortifolioRequest request)
	{
		await Validate(request);

		var portifolio = _mapper.Map<PortifolioCreateCommand>(request);

		var response = await _mediator.Send(portifolio);

		return _mapper.Map<PortifolioResponse>(response);
	}

	private async Task Validate(PortifolioRequest request)
	{
		var validator = new PortifolioValidator();
		var result = await validator.ValidateAsync(request);

		var existsPortifolio = await _mediator.Send(request.Name);

		if (existsPortifolio is null)
			result.Errors.Add(new ValidationFailure("name", "Esse nome já existe"));

		if (!result.IsValid)
		{
			var errorMessages = result.Errors
				.Select(error => error.ErrorMessage).ToList().FirstOrDefault();

			var concatenatedErrors = string.Join("\n", errorMessages);

			Log.ForContext("Name", request.Name)
				.Error($"{concatenatedErrors}");

			throw new ValidationException(errorMessages);
		}
	}
}