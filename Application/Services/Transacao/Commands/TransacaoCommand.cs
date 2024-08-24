using MediatR;

namespace Application.Services.Transacao.Commands;

public class TransacaoCommand : IRequest<Domain.Entities.Transacao>
{
	public Guid PortifolioId { get; set; }
	public Guid AtivoId { get; set; }
	public int Quantity { get; set; }
	public float Price { get; set; }
}