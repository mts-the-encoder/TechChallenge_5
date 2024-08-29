using FluentAssertions;
using Tests.Utils.Entities;

namespace Tests.Domain.Tests;

public class UserTest
{
	[Fact]
	public void Validate_Success()
	{
		var user = UserBuilder.Build();

		user.Should().NotBeNull();
		user.Name.Should().NotBeNullOrWhiteSpace();
		user.Id.Should().Subject.HasValue.Should().BeTrue();
	}

	[Fact]
	public void Validate_Failure()
	{
		var user = UserBuilder.Build();

		user.Name = string.Empty;

		user.Name.Length.Should().BeLessThanOrEqualTo(0);
		user.Name.Should().BeNullOrWhiteSpace();
	}
}