using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Context;

namespace Infrastructure.Repos;

public class PortifolioRepository(AppDbContext ctx) : IPortifolioRepository
{
	private readonly AppDbContext _ctx = ctx;

	public async ValueTask Create(Portifolio portifolio)
	{
		await _ctx.Portifolio.AddAsync(portifolio);
		await _ctx.SaveChangesAsync();
	}
}