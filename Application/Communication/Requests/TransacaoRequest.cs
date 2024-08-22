namespace Application.Communication.Requests;

public class TransacaoRequest
{
	public Guid PortifolioId { get; set; }
	public Guid AtivoId { get; set; }
	public int Quantity { get; set; }
	public float Price { get; set; }
}