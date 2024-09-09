using Application.Services.User.Commands;
using Application.Services.User.Handlers;
using Application.Services.User.Queries;
using FluentAssertions;
using Tests.Utils.Entities;
using Tests.Utils.Mapper;
using Tests.Utils.Repositories;

namespace Tests.Services.Tests.User;

public class GetByIdUserQueryHandlerTest
{
	[Fact]
	public async Task Validate_Success()
	{
		var user = UserBuilder.Build();

		var command = new UserCreateCommand
		{
			Name = user.Name,
			Email = user.Email,
			Password = user.Password
		};

		var repo = UserRepositoryBuilder.Instance().Build();
		var mapper = MapperBuilder.Instance();

		var handler = new UserCreateCommandHandler(repo, mapper);
		var result = await handler.Handle(command, default);

		var query = new GetUserByIdQuery(result.Id);
		var getHandler = new GetUserByIdQueryHandler(repo);

		var action = async () => { await getHandler.Handle(query, default); };

		await action.Should().NotThrowAsync();
	}
}