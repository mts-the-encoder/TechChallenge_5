using MediatR;

namespace Application.Services.User.Queries;

public class ExistsByEmailQuery : IRequest<bool>
{
	public string Email { get; set; }

	public ExistsByEmailQuery(string email) { Email = email; }
}