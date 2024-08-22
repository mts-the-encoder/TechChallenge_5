namespace Application.Communication.Responses;

public class TransacaoResponse
{
	public Guid Id { get; set; }
	public Guid PortifolioId { get; set; }
	public Guid AtivoId { get; set; }
	public int Quantity { get; set; }
	public float Price { get; set; }
	public DateTime TransactionDate { get; set; } 
}