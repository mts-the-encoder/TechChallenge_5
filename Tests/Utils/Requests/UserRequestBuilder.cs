using Application.Communication.Requests;
using Bogus;

namespace Tests.Utils.Requests;

public class UserRequestBuilder
{
	public static UserRequest Build()
	{
		return new Faker<UserRequest>()
			.RuleFor(x => x.Name, f => f.Person.FullName)
			.RuleFor(x => x.Email, f => f.Person.Email)
			.RuleFor(x => x.Password, f => f.Internet.Password());
	}
}