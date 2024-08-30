using Api.Middleware;
using Application.Communication.Requests;
using Application.Communication.Responses;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ServiceFilter(typeof(AuthenticatedUserAttribute))]
public class PortifolioController : TechChallengeController
{
	private readonly IPortifolioService _service;

	public PortifolioController(IPortifolioService service)
	{
		_service = service;
	}

	[HttpPost]
	public async Task<ActionResult<PortifolioResponse>> Create(PortifolioRequest portifolio)
	{
		await _service.Create(portifolio);

		return Created(string.Empty, portifolio);
	}

	[HttpGet("{id}")]
	public async Task<ActionResult<PortifolioResponse>> GetByIdAsync(Guid id)
	{
		var response = await _service.GetById(id);

		return Ok(response);
	}

	[HttpGet("portifolios/{id}")]
	public async Task<ActionResult<IEnumerable<PortifolioResponse>>> GetAllAsync(Guid id)
	{
		var response = await _service.GetAll(id);

		return Ok(response);
	}
}