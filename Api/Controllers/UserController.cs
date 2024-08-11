﻿using Application.Dto;
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
	public async Task<ActionResult<UserDto>> Create(UserDto user)
	{
		await _service.Create(user);

		return Created(string.Empty, user);
	}

	[HttpGet("{id}")]
	public async Task<ActionResult<UserDto>> GetById(Guid id)
	{
		var response = await _service.GetById(id);

		return Ok(response);
	}

}