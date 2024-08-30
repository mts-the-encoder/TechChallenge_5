using Domain.Entities;

namespace Domain.Repositories;

public interface IPortifolioRepository
{
	ValueTask Create(Portifolio portifolio);
	Task<bool> ExistsByName(string name);
	ValueTask<IEnumerable<Portifolio>> GetAll(Guid id);
	ValueTask<Portifolio> GetById(Guid id);
}