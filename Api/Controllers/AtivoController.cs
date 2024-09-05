using Api.Middleware;
using Application.Communication.Responses;
using Application.Interfaces;
using Application.Services.Ativo.Commands;
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
	public async Task<ActionResult<AtivoResponse>> Create(AtivoCommand portifolio)
	{
		await _service.Create(portifolio);

		return Created(string.Empty, portifolio);
	}

	[HttpPut]
	public async Task<ActionResult<AtivoResponse>> Update(AtivoUpdateCommand id)
	{
		var response = await _service.Update(id);

		return Ok(response);
	}

	[HttpDelete("{id}")]
	public async Task<ActionResult> Delete(Guid id)
	{
		await _service.Delete(id);

		return Ok();
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