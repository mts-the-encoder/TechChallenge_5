using Domain.Entities;
using FluentAssertions;
using Tests.Utils.Entities;

namespace Tests.Domain.Tests;

public class PortifolioTest
{
	[Fact]
	public void Validate_Success()
	{
		var user = UserBuilder.Build();
		var portifolio = PortifolioBuilder.Build(user);

		portifolio.Should().NotBeNull();
		portifolio.Should().BeAssignableTo<Portifolio>();
		portifolio.Name.Should().NotBeNullOrWhiteSpace();
		portifolio.Description.Length.Should().BeGreaterThanOrEqualTo(2);
	}

	[Fact]
	public void Validate_Failure()
	{
		var user = UserBuilder.Build();
		var portifolio = PortifolioBuilder.Build(user);

		portifolio.Id = Guid.Empty;
		portifolio.UserId = Guid.Empty;

		portifolio.Id.Should().Subject?.Should().BeEmpty();
		portifolio.UserId.Should().BeEmpty();
	}
}