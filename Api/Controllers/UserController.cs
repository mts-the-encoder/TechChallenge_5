using Application.Communication.Requests;
using Application.Communication.Responses;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class UserController : TechChallengeController
{
	private readonly IUserService _service;

	public UserController(IUserService service)
	{
		_service = service;
	}

	[HttpPost]
	public async Task<ActionResult<UserResponse>> Create(UserRequest user)
	{
		await _service.Create(user);

		return Created(string.Empty, user);
	}

	[HttpPost("/login")]
	public async Task<ActionResult<LoginResponse>> Login(LoginRequest user)
	{
		var response = await _service.Login(user);

		return Ok(response);
	}

	[HttpGet("{id}")]
	public async Task<ActionResult<UserResponse>> GetById(Guid id)
	{
		var response = await _service.GetById(id);

		return Ok(response);
	}

}