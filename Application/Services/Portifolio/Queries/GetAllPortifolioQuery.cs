using MediatR;

namespace Application.Services.Portifolio.Queries;

public class GetAllPortifolioQuery : IRequest<IEnumerable<Domain.Entities.Portifolio>>
{
	public Guid Id { get; set; }

	public GetAllPortifolioQuery(Guid id) { Id = id; }
}