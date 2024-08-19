using Domain.Enums;
using MediatR;

namespace Application.Services.Ativo.Commands;

public class AtivoCommand : IRequest<Domain.Entities.Ativo>
{
	public string Name { get; set; }
	public TipoAtivo TipoAtivo { get; set; }
	public string Codigo { get; set; }
}