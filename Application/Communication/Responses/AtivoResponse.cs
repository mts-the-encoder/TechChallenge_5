using Domain.Enums;

namespace Application.Communication.Responses;

public class AtivoResponse
{
	public Guid Id { get; set; }
	public string Name { get; set; }
	public TipoAtivo TipoAtivo { get; set; }
	public string Codigo { get; set; }
}