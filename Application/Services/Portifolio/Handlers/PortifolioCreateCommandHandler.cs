using Application.Services.Portifolio.Commands;
using AutoMapper;
using Domain.Repositories;
using MediatR;

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
        var portifolio = _mapper.Map<Domain.Entities.Portifolio>(request);

        if (portifolio is null) throw new ApplicationException($"Error creating entity");

        await _repository.Create(portifolio);

        return portifolio;
    }
}