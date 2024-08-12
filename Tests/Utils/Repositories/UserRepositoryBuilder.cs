using Domain.Entities;
using Domain.Repositories;
using Moq;

namespace Tests.Utils.Repositories;

public class UserRepositoryBuilder
{
	private static UserRepositoryBuilder _instance;
	private readonly Mock<IUserRepository> _repository;

	private UserRepositoryBuilder()
	{
		_repository ??= new Mock<IUserRepository>();
	}

	public static UserRepositoryBuilder Instance()
	{
		_instance = new UserRepositoryBuilder();
		return _instance;
	}

	public IUserRepository Build()
	{
		return _repository.Object;
	}

	public UserRepositoryBuilder GetById(User user)
	{
		if (!string.IsNullOrWhiteSpace(user.Id.ToString()))
			_repository.Setup(i => i.GetById(user.Id)).ReturnsAsync(user);

		return this;
	}

	public UserRepositoryBuilder GetByEmailAndPassword(User user)
	{
		_repository.Setup(x => x.GetByEmailAndPassword(user.Email, user.Password))
			.ReturnsAsync(user);

		return this;
	}

	public UserRepositoryBuilder Create(User user)
	{
		_repository.Setup(x => x.Create(user));

		return this;
	}
}