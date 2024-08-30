using MediatR;

namespace Application.Services.Portifolio.Queries;

public class GetPortifolioByIdQuery : IRequest<Domain.Entities.Portifolio>
{
	public Guid Id { get; set; }

	public GetPortifolioByIdQuery(Guid id) { Id = id; }
}