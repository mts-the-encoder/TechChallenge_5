using MediatR;

namespace Application.Services.Transacao.Queries;

public class GetTransacaoByIdQuery : IRequest<Domain.Entities.Transacao>
{
	public Guid Id { get; set; }

	public GetTransacaoByIdQuery(Guid id) { Id = id; }
}