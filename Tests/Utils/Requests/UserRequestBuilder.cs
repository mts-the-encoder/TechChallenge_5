using Application.Services.User.Commands;
using Bogus;

namespace Tests.Utils.Requests;

public class UserRequestBuilder
{
	public static UserCommand Build()
	{
		return new Faker<UserCommand>()
			.RuleFor(x => x.Name, f => f.Person.FullName)
			.RuleFor(x => x.Email, f => f.Person.Email)
			.RuleFor(x => x.Password, f => f.Internet.Password());
	}
}