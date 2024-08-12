using Domain.Entities;

namespace Domain.Repositories;

public interface IUserRepository
{
	ValueTask Create(User user);
	ValueTask<User> GetById(Guid id);
	ValueTask<User> GetByEmailAndPassword(string email, string password);
}