using Application.Communication.Responses;
using Application.Services.Transacao.Commands;

namespace Application.Interfaces;

public interface ITransacaoService
{
	Task<TransacaoResponse> Create(TransacaoCommand request);
	Task<TransacaoResponse> GetById(Guid id);
	Task<IEnumerable<TransacaoResponse>> GetAll(Guid id);
}