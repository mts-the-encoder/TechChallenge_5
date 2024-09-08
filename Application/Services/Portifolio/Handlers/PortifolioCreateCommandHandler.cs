using Application.Exceptions;
using Application.Services.Portifolio.Commands;
using AutoMapper;
using Domain.Repositories;
using MediatR;
using Serilog;

namespace Application.Services.Portifolio.Handlers;

public class PortifolioCreateCommandHandler : IRequestHandler<PortifolioCreateCommand, Domain.Entities.Portifolio>
{
    private readonly IPortifolioRepository _repository;
    private readonly IMapper _mapper;

    public PortifolioCreateCommandHandler(IPortifolioRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Domain.Entities.Portifolio> Handle(PortifolioCreateCommand request, CancellationToken cancellationToken)
    {
	    await Validate(request);

		var portifolio = _mapper.Map<Domain.Entities.Portifolio>(request);

        await _repository.Create(portifolio);

        return portifolio;
    }

    private async Task Validate(PortifolioCreateCommand request)
    {
	    var validator = new PortifolioValidator();
	    var result = await validator.ValidateAsync(request);

	    if (!result.IsValid)
	    {
		    var errorMessages = result.Errors
			    .Select(error => error.ErrorMessage).ToList();

		    var concatenatedErrors = string.Join("\n", errorMessages);

		    Log.ForContext("UserId", request.UserId)
			    .Error($"{concatenatedErrors}");

		    throw new ValidationErrorsException(errorMessages);
	    }
    }
}