using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Context;

namespace Infrastructure.Repos;

public class UserRepository(AppDbContext context) : IUserRepository
{
	public async ValueTask Create(User user)
	{
		await context.User.AddAsync(user);
		await context.SaveChangesAsync();
	}
}