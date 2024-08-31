using Application.Communication.Responses;
using Application.Services.Ativo.Commands;

namespace Application.Interfaces;

public interface IAtivoService
{
	Task<AtivoResponse> Create(AtivoCommand request);
	Task<AtivoResponse> GetById(Guid id);
	Task<IEnumerable<AtivoResponse>> GetAll();
}