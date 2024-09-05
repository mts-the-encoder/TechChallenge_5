using Domain.Entities;

namespace Domain.Repositories;

public interface IAtivoRepository
{
	ValueTask Create(Ativo ativo);
	ValueTask<IEnumerable<Ativo>> GetAll();
	ValueTask<Ativo> GetById(Guid id);
	ValueTask<Ativo> UpdateAsync(Ativo ativo);
	ValueTask<Ativo> RemoveAsync(Ativo ativo);
}