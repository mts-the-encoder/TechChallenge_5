using Api.Middleware;
using Application.Communication.Requests;
using Application.Communication.Responses;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ServiceFilter(typeof(AuthenticatedUserAttribute))]
public class TransacaoController : TechChallengeController
{
	private readonly ITransacaoService _service;

	public TransacaoController(ITransacaoService service)
	{
		_service = service;
	}

	[HttpPost]
	public async Task<ActionResult<TransacaoResponse>> Create(TransacaoRequest transacao)
	{
		await _service.Create(transacao);

		return Created(string.Empty, transacao);
	}
}