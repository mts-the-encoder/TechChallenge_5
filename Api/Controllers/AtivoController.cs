using Api.Middleware;
using Application.Communication.Requests;
using Application.Communication.Responses;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ServiceFilter(typeof(AuthenticatedUserAttribute))]
public class AtivoController : TechChallengeController
{
	private readonly IAtivoService _service;

	public AtivoController(IAtivoService service)
	{
		_service = service;
	}

	[HttpPost]
	public async Task<ActionResult<AtivoResponse>> Create(AtivoRequest portifolio)
	{
		await _service.Create(portifolio);

		return Created(string.Empty, portifolio);
	}

	[HttpGet("{id}")]
	public async Task<ActionResult<AtivoResponse>> GetById(Guid id)
	{
		var response = await _service.GetById(id);

		return Ok(response);
	}

	[HttpGet("ativos")]
	public async Task<ActionResult<IEnumerable<AtivoResponse>>> GetAll()
	{
		var response = await _service.GetAll();

		return Ok(response);
	}
}