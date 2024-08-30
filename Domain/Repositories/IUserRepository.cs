using Domain.Entities;

namespace Domain.Repositories;

public interface IUserRepository
{
	ValueTask Create(User user);
	ValueTask<User> GetById(Guid id);
	ValueTask<User> GetByEmailAndPassword(string email, string password);
	Task<bool> ExistsByEmail(string email);
	Task<User> Login(string email, string password);
	Task<User> GetByEmail(string email);
}