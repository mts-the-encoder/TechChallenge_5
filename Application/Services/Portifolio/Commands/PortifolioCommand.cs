using MediatR;

namespace Application.Services.Portifolio.Commands;

public class PortifolioCommand : IRequest<Domain.Entities.Portifolio>
{
	public Guid UserId { get; set; }
	public string Name { get; set; }
	public string Description { get; set; }
}