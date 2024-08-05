using Infrastructure.Context;

namespace Infrastructure.UnitOfWork;

public class UnitOfWork(AppDbContext context) : IDisposable, IUnitOfWork
{
	private bool _disposed;

	public async Task Commit()
	{
		await context.SaveChangesAsync();
	}

	public void Dispose()
	{
		Dispose(true);
	}

	private void Dispose(bool disposing)
	{
		if (!_disposed && disposing) context.Dispose();

		_disposed = true;
	}
}