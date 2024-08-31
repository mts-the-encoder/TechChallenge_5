using Application.Communication.Responses;
using Application.Services.Portifolio.Commands;

namespace Application.Interfaces;

public interface IPortifolioService
{
	Task<PortifolioResponse> Create(PortifolioCommand request);

	Task<PortifolioResponse> GetById(Guid id);
	Task<IEnumerable<PortifolioResponse>> GetAll(Guid id);
}