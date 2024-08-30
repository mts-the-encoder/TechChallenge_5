using Application.Communication.Requests;
using Application.Communication.Responses;
using Application.Exceptions;
using Application.Interfaces;
using Application.Services.Portifolio.Queries;
using Application.Services.Transacao.Commands;
using Application.Services.Transacao.Queries;
using AutoMapper;
using FluentValidation;
using MediatR;
using Serilog;

namespace Application.Services.Transacao;

public class TransacaoService : ITransacaoService
{
	private readonly IMediator _mediator;
	private readonly IMapper _mapper;

	public TransacaoService(IMediator mediator, IMapper mapper)
	{
		_mediator = mediator;
		_mapper = mapper;
	}

	public async Task<TransacaoResponse> Create(TransacaoRequest request)
	{
		await Validate(request);

		var transacao = _mapper.Map<TransacaoCreateCommand>(request);

		var response = await _mediator.Send(transacao);

		return _mapper.Map<TransacaoResponse>(response);
	}

	public async Task<TransacaoResponse> GetById(Guid id)
	{
		var transacao = new GetTransacaoByIdQuery(id);

		if (transacao is null) throw new ValidationErrorsException(new List<string> { "Não encontrado" });

		var result = await _mediator.Send(transacao);

		return _mapper.Map<TransacaoResponse>(result);
	}

	public async Task<IEnumerable<TransacaoResponse>> GetAll(Guid id)
	{
		var transacoes = new GetAllTransacaoQuery(id);

		if (transacoes is null) throw new ValidationErrorsException(new List<string> { "Não encontrado" });

		var result = await _mediator.Send(transacoes);

		return _mapper.Map<IEnumerable<TransacaoResponse>>(result);
	}

	private async Task Validate(TransacaoRequest request)
	{
		var validator = new TransacaoValidator();
		var result = await validator.ValidateAsync(request);

		if (!result.IsValid)
		{
			var errorMessages = result.Errors
				.Select(error => error.ErrorMessage).ToList().FirstOrDefault();

			var concatenatedErrors = string.Join("\n", errorMessages);

			Log.ForContext("Transacao", request.AtivoId)
				.Error($"{concatenatedErrors}");

			throw new ValidationException(errorMessages);
		}
	}
}