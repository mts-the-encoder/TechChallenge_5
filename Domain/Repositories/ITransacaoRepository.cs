using Domain.Entities;

namespace Domain.Repositories;

public interface ITransacaoRepository
{
	ValueTask Create(Transacao transacao);
	ValueTask<Transacao> GetById(Guid id);
	ValueTask<IEnumerable<Transacao>> GetAll(Guid id);
}