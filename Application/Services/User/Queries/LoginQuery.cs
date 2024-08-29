using Application.Communication.Responses;
using MediatR;

namespace Application.Services.User.Queries;

public class LoginQuery : IRequest<LoginResponse>
{
	public string Email { get; set; }
	public string Password { get; set; }

	public LoginQuery(string email, string password) { Email = email; Password = password; }
}