using Application.Communication.Responses;
using Application.Exceptions;
using Application.Interfaces;
using Application.Services.Portifolio.Commands;
using Application.Services.Portifolio.Queries;
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

	public async Task<PortifolioResponse> GetById(Guid id)
	{
		var portifolio = new GetPortifolioByIdQuery(id);

		if (portifolio is null) throw new ValidationErrorsException(new List<string> { "Não encontrado" });

		var result = await _mediator.Send(portifolio);

		return _mapper.Map<PortifolioResponse>(result);
	}

	public async Task<IEnumerable<PortifolioResponse>> GetAll(Guid id)
	{
		var portifolios = new GetAllPortifolioQuery(id);

		if (portifolios is null) throw new ValidationErrorsException(new List<string> { "Não encontrado" });

		var result = await _mediator.Send(portifolios);

		return _mapper.Map<IEnumerable<PortifolioResponse>>(result);
	}

	public async Task<PortifolioResponse> Create(PortifolioCommand request)
	{
		await Validate(request);

		var portifolio = _mapper.Map<PortifolioCreateCommand>(request);

		var response = await _mediator.Send(portifolio);

		return _mapper.Map<PortifolioResponse>(response);
	}

	private async Task Validate(PortifolioCommand request)
	{
		var validator = new PortifolioValidator();
		var result = await validator.ValidateAsync(request);

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