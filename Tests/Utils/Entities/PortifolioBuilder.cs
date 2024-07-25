using Bogus;
using Domain.Entities;

namespace Tests.Utils.Entities;

public class PortifolioBuilder
{
	public static Portifolio Build(User user)
	{
		return new Faker<Portifolio>()
			.RuleFor(x => x.Id, _ => user.Id)
			.RuleFor(x => x.Name, f => f.Company.CompanyName())
			.RuleFor(x => x.UserId, _ => user.Id)
			.RuleFor(x => x.Description, f => f.Finance.Currency().Description);
	}
}

