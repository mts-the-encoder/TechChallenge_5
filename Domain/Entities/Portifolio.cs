namespace Domain.Entities;

public class Portifolio : EntityBase
{
	public Guid UserId { get; set; }
	public string Description { get; set; }
}