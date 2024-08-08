using MediatR;

namespace Application.Services.User.Commands;

public class UserCommand : IRequest<Domain.Entities.User>
{
	public string Name { get; set; }
	public string Email { get; set; }
	public string Password { get; set; }
}