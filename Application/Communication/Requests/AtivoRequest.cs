using Domain.Enums;

namespace Application.Communication.Requests;

public class AtivoRequest
{
	public string Name { get; set; }
	public TipoAtivo TipoAtivo { get; set; }
	public string Codigo { get; set; }
}