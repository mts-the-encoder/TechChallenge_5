using Domain.Entities;

namespace Domain.Repositories;

public interface IAtivoRepository
{
	ValueTask Create(Ativo ativo);
}