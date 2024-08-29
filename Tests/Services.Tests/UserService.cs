using Application.Services.User.Commands;
using Tests.Utils.Entities;
using Tests.Utils.Mapper;

namespace Tests.Services.Tests;

public class UserService
{
	[Fact]
	public async Task CreateUser()
	{
		var handler = new UserCreateCommand();
		var user = UserBuilder.Build();

		var request = new UserCreateCommand
		{
			Name = user.Name,
			Email = user.Email,
			Password = user.Password
		};

		//handler.
		//var result = await handler.Handle(request, CancellationToken.None);

		//// Assert
		//Assert.Equal(1, result.Status);
		//result.Status.Should().BeTrue();
	}

	//private static Application.Services.User.UserService CreateUserService()
	//{
	//	var mapper = MapperBuilder.Instance();

	//	//return new Application.Services.User.UserService(, mapper);
	//}
}