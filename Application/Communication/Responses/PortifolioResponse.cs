namespace Application.Communication.Responses;

public class PortifolioResponse
{

	public Guid Id { get; set; }
	public Guid UserId { get; set; }
	public string Name { get; set; }
	public string Description { get; set; }
}