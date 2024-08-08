namespace Domain.Entities;

public class EntityBase
{
	public Guid Id { get; set; } = Guid.NewGuid();
	public string Name { get; set; }
}