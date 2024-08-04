using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure.Repos;

public class UserRepository : IUserRepository
{
	public ValueTask<User> Create(User user)
	{
		throw new NotImplementedException();
	}
}