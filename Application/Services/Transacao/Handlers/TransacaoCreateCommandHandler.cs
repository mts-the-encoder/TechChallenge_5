using Application.Exceptions;
using Application.Services.Transacao.Commands;
using Application.Services.User.Commands;
using Application.Services.User;
using AutoMapper;
using Domain.Repositories;
using MediatR;
using Serilog;

namespace Application.Services.Transacao.Handlers;

public class TransacaoCreateCommandHandler : IRequestHandler<TransacaoCreateCommand, Domain.Entities.Transacao>
{
	private readonly ITransacaoRepository _repository;
	private readonly IMapper _mapper;

	public TransacaoCreateCommandHandler(ITransacaoRepository repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task<Domain.Entities.Transacao> Handle(TransacaoCreateCommand request, CancellationToken cancellationToken)
	{
		await Validate(request);

		var transacao = _mapper.Map<Domain.Entities.Transacao>(request);

		await _repository.Create(transacao);

		return transacao;
	}

	private async Task Validate(TransacaoCreateCommand request)
	{
		var validator = new TransacaoValidator();
		var result = await validator.ValidateAsync(request);

		if (!result.IsValid)
		{
			var errorMessages = result.Errors
				.Select(error => error.ErrorMessage).ToList();

			var concatenatedErrors = string.Join("\n", errorMessages);

			Log.ForContext("Portifolio", request.PortifolioId)
				.Error($"{concatenatedErrors}");

			throw new ValidationErrorsException(errorMessages);
		}
	}
}