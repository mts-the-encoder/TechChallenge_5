using Application.Communication.Requests;
using Application.Communication.Responses;

namespace Application.Interfaces;

public interface ITransacaoService
{
	Task<TransacaoResponse> Create(TransacaoRequest request);
	Task<TransacaoResponse> GetById(Guid id);
	Task<IEnumerable<TransacaoResponse>> GetAll(Guid id);
}