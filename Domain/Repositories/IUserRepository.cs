using Domain.Entities;

namespace Domain.Repositories;

public interface IUserRepository
{
	ValueTask<User> Create(User user);
}