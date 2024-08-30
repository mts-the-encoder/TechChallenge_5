using Application.Communication.Requests;
using Application.Communication.Responses;
using Application.Interfaces;
using Application.Services.Transacao.Commands;
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

	public Task<TransacaoResponse> GetById(Guid id)
	{
		throw new NotImplementedException();
	}

	public Task<IEnumerable<TransacaoResponse>> GetAll(Guid id)
	{
		throw new NotImplementedException();
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