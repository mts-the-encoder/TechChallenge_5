using Application.Communication.Requests;
using Application.Communication.Responses;

namespace Application.Interfaces;

public interface IAtivoService
{
	Task<AtivoResponse> Create(AtivoRequest request);
}