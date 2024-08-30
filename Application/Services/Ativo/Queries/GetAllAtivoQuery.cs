using MediatR;

namespace Application.Services.Ativo.Queries;

public class GetAllAtivoQuery : IRequest<IEnumerable<Domain.Entities.Ativo>>
{
	public GetAllAtivoQuery() { }
}