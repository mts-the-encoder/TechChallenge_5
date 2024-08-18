using Domain.Entities;

namespace Domain.Repositories;

public interface IPortifolioRepository
{
	ValueTask Create(Portifolio portifolio);
	Task<bool> ExistsByName(string name);
}