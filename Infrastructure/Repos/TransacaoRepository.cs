using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repos;

public class TransacaoRepository : ITransacaoRepository
{
	private readonly AppDbContext _ctx;

	public TransacaoRepository(AppDbContext ctx)
	{
		_ctx = ctx;
	}

	public async ValueTask Create(Transacao transacao)
	{
		await _ctx.Transacao.AddAsync(transacao);
		await _ctx.SaveChangesAsync();
	}

	public async ValueTask<Transacao> GetById(Guid id)
	{
		return await _ctx.Transacao
			.AsNoTracking()
			.SingleOrDefaultAsync(x => x.Id.Equals(id));
	}

	public async ValueTask<IEnumerable<Transacao>> GetAll(Guid id)
	{
		return await _ctx.Transacao
			.AsNoTracking()
			.Where(x => x.PortifolioId.Equals(id))
			.ToListAsync();
	}
}