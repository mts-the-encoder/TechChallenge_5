using Domain.Entities;

namespace Domain.Repositories;

public interface IAtivoRepository
{
	ValueTask Create(Ativo ativo);
	ValueTask<IEnumerable<Ativo>> GetAll(Guid id);
	ValueTask<Ativo> GetById(Guid id);
}