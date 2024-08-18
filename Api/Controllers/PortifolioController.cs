using Application.Communication.Requests;
using Application.Communication.Responses;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

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
}