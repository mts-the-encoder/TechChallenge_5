using Bogus;
using Domain.Entities;

namespace Tests.Utils.Entities;

public class UserBuilder
{
	public static User Build()
	{
		return new Faker<User>()
			.RuleFor(x => x.Id, f => f.Random.Guid())
			.RuleFor(x => x.Name, f => f.Person.FullName)
			.RuleFor(x => x.Email, f => f.Person.Email)
			.RuleFor(x => x.Password, f => f.Internet.Password());
	}
}