namespace Application.Services.Transacao.Commands;

public class TransacaoCommand
{
	public Guid PortifolioId { get; set; }
	public Guid AtivoId { get; set; }
	public int Quantity { get; set; }
	public float Price { get; set; }
}