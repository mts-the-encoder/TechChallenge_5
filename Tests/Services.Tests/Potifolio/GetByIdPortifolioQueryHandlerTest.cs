using Application.Services.Portifolio.Commands;
using Application.Services.Portifolio.Handlers;
using Application.Services.Portifolio.Queries;
using FluentAssertions;
using Tests.Utils.Entities;
using Tests.Utils.Mapper;
using Tests.Utils.Repositories;

namespace Tests.Services.Tests.Potifolio;

public class GetByIdPortifolioQueryHandlerTest
{
	[Fact]
	public async Task Validate_Success()
	{
		var user = UserBuilder.Build();
		var portifolio = PortifolioBuilder.Build(user);

		var command = new PortifolioCreateCommand()
		{
			UserId = user.Id,
			Name = portifolio.Name,
			Description = portifolio.Description
		};

		var repo = PortifolioRepositoryBuilder.Instance().Build();
		var mapper = MapperBuilder.Instance();

		var handler = new PortifolioCreateCommandHandler(repo, mapper);

		var result = await handler.Handle(command, default);

		var query = new GetPortifolioByIdQuery(result.Id);
		var getHandler = new GetPortifolioByIdQueryHandler(repo);

		var action = async () => { await getHandler.Handle(query, default); };

		await action.Should().NotThrowAsync();
	}
}