using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repos;

public class PortifolioRepository(AppDbContext ctx) : IPortifolioRepository
{
	public async ValueTask Create(Portifolio portifolio)
	{
		await ctx.Portifolio.AddAsync(portifolio);
		await ctx.SaveChangesAsync();
	}

	public async Task<bool> ExistsByName(string name)
	{
		return await ctx.Portifolio.AsNoTracking()
			.AnyAsync(x => x.Name.Equals(name));
	}
}