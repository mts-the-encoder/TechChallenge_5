using Application.Communication;
using Bogus;
using Domain.Entities;

namespace Tests.Utils.Requests;

public class PortifolioRequestBuilder
{
	public static PortifolioRequest Build(User user)
	{
		return new Faker<PortifolioRequest>()
			.RuleFor(x => x.Name, f => f.Company.CompanyName())
			.RuleFor(x => x.UserId, _ => user.Id)
			.RuleFor(x => x.Description, f => f.Finance.Currency().Description);
	}
}