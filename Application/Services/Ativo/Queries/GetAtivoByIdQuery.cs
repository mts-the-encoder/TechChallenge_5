using MediatR;

namespace Application.Services.Ativo.Queries;

public class GetAtivoByIdQuery : IRequest<Domain.Entities.Ativo>
{
	public Guid Id { get; set; }

	public GetAtivoByIdQuery(Guid id) { Id = id; }
}