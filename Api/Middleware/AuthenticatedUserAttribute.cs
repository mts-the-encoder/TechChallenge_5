using Application.Communication.Responses;
using Application.Services.Token;
using Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Api.Middleware;

public class AuthenticatedUserAttribute : AuthorizeAttribute, IAsyncAuthorizationFilter
{
	private readonly TokenService _tokenService;
	private readonly IUserRepository _repository;

	public AuthenticatedUserAttribute(TokenService tokenService, IUserRepository repository)
	{
		_tokenService = tokenService;
		_repository = repository;
	}

	public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
	{
		try
		{
			var token = TokenOnRequest(context);

			var email = _tokenService.GetEmail(token);

			var user = await _repository.GetByEmail(email);

			if (user is null)
				throw new SystemException();
		}
		catch (SecurityTokenExpiredException)
		{
			ExpiredToken(context);
		}
		catch
		{
			UserForbidden(context);
		}

	}

	private string TokenOnRequest(AuthorizationFilterContext context)
	{
		var authorization = context.HttpContext.Request.Headers["Authorization"].ToString();

		if (string.IsNullOrWhiteSpace(authorization))
			throw new SystemException();

		return authorization["Bearer".Length..].Trim();
	}

	private static void ExpiredToken(AuthorizationFilterContext context)
	{
		context.Result = new UnauthorizedObjectResult(new ErrorResponse("Token Expirado"));
	}

	private static void UserForbidden(AuthorizationFilterContext context)
	{
		context.Result = new UnauthorizedObjectResult(new ErrorResponse("Usuário sem permissão"));
	}
}