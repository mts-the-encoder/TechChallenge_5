using MediatR;

namespace Application.Services.Transacao.Queries;

public class GetAllTransacaoQuery : IRequest<IEnumerable<Domain.Entities.Transacao>>
{
	public Guid Id { get; set; }

	public GetAllTransacaoQuery(Guid id) { Id = id; }
}