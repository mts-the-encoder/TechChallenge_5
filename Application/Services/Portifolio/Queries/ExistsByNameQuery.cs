using MediatR;

namespace Application.Services.Portifolio.Queries;

public class ExistsByNameQuery : IRequest<bool>
{
	public string Name { get; set; }

	public ExistsByNameQuery(string name) { Name = name; }

}