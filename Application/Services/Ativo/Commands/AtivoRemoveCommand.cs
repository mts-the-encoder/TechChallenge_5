namespace Application.Services.Ativo.Commands;

public class AtivoRemoveCommand : AtivoCommand
{
	public Guid Id { get; set; }

	public AtivoRemoveCommand(Guid id)
	{
		Id = id;
	}
}