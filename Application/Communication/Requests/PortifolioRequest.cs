namespace Application.Communication.Requests;

public class PortifolioRequest
{
	public Guid UserId { get; set; }
	public string Name { get; set; }
	public string Description { get; set; }
}