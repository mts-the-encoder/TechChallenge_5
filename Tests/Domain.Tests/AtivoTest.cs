using Domain.Entities;
using FluentAssertions;
using Tests.Utils.Entities;

namespace Tests.Domain.Tests;

public class AtivoTest
{
	[Fact]
	public void Validate_Success()
	{
		var ativo = AtivoBuilder.Build();

		ativo.Should().NotBeNull();
		ativo.Should().BeAssignableTo<Ativo>();
		ativo.Name.Should().NotBeNullOrWhiteSpace();
	}

	[Fact]
	public void Validate_Failure()
	{
		var ativo = AtivoBuilder.Build();

		ativo.Id = Guid.Empty;

		ativo.Id.Should().Subject?.Should().BeEmpty();
	}
}