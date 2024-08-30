using Application.Communication.Requests;
using Application.Communication.Responses;

namespace Application.Interfaces;

public interface IAtivoService
{
	Task<AtivoResponse> Create(AtivoRequest request);
	Task<AtivoResponse> GetById(Guid id);
	Task<IEnumerable<AtivoResponse>> GetAll();
}