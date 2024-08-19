using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Context;

namespace Infrastructure.Repos;

public class AtivoRepository : IAtivoRepository
{
	private readonly AppDbContext _ctx;

	public AtivoRepository(AppDbContext ctx)
	{
		_ctx = ctx;
	}

	public async ValueTask Create(Ativo ativo)
	{
		await _ctx.Ativo.AddAsync(ativo);
		await _ctx.SaveChangesAsync();
	}
}