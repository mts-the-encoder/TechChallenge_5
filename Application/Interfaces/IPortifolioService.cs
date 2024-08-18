using Application.Communication.Requests;
using Application.Communication.Responses;

namespace Application.Interfaces;

public interface IPortifolioService
{
	Task<PortifolioResponse> Create(PortifolioRequest request);
}