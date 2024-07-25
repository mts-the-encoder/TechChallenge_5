using Domain.Enums;

namespace Domain.Entities;

public class Ativo : EntityBase
{
	public TipoAtivo TipoAtivo { get; set; }
	public string Codigo { get; set; }
}