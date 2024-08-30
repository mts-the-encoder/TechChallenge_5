using Application.Communication.Requests;
using Application.Communication.Responses;

namespace Application.Interfaces;

public interface IPortifolioService
{
	Task<PortifolioResponse> Create(PortifolioRequest request);

	Task<PortifolioResponse> GetById(Guid id);
	Task<IEnumerable<PortifolioResponse>> GetAll(Guid id);
}