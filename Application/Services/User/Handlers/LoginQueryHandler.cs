using Application.Communication.Responses;
using Application.Exceptions;
using Application.Services.Token;
using Application.Services.User.Queries;
using Domain.Repositories;
using MediatR;
using Serilog;

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

		if (user is not null)
		{
			return new LoginResponse()
			{
				Name = user.Name,
				Token = _tokenService.GenerateToken(user.Email)
			};
		}

		Log.ForContext("UserName", request.Email)
			.Error($"{"Login inválido"}");
		throw new InvalidLoginException();
	}
}