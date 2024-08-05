using Domain.Entities;

namespace Domain.Repositories;

public interface IUserRepository
{
	ValueTask Create(User user);
}