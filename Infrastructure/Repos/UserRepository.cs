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
}