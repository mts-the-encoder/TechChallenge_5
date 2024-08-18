using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repos;

public class UserRepository(AppDbContext context) : IUserRepository
{
	public async ValueTask Create(User user)
	{
		await context.User.AddAsync(user);
		await context.SaveChangesAsync();
	}

	public async ValueTask<User> GetById(Guid id)
	{
		return await context.User
			.AsNoTracking()
			.FirstOrDefaultAsync(x => x.Id.Equals(id));
	}

	public async ValueTask<User> GetByEmailAndPassword(string email, string password)
	{
		return await context.User
			.AsNoTracking()
			.SingleOrDefaultAsync(x => x.Email.Equals(email) && x.Password.Equals(password));
	}

	public async Task<bool> ExistsByEmail(string email)
	{
		return await context.User.AsNoTracking()
			.AnyAsync(x => x.Email.Equals(email));
	}
}