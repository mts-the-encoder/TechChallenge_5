using Application.Communication.Responses;
using Application.Services.Token;
using Application.Services.User.Queries;
using Domain.Repositories;
using MediatR;

namespace Application.Services.User.Handlers;

public class LoginQueryHandler : IRequestHandler<LoginQuery, LoginResponse>
{
	private readonly TokenService _tokenService;
	private readonly IUserRepository _repository;

	public LoginQueryHandler(IUserRepository repository, TokenService tokenService)
	{
		_repository = repository;
		_tokenService = tokenService;
	}

	public async Task<LoginResponse> Handle(LoginQuery request, CancellationToken cancellationToken)
	{
		var user = await _repository.Login(request.Email, request.Password);

		return new LoginResponse()
		{
			Name = user.Name,
			Token = _tokenService.GenerateToken(user.Email)
		};
	}
}