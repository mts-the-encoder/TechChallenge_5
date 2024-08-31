using Application.Services.Portifolio.Commands;
using Bogus;
using Domain.Entities;

namespace Tests.Utils.Requests;

public class PortifolioRequestBuilder
{
	public static PortifolioCommand Build(User user)
	{
		return new Faker<PortifolioCommand>()
			.RuleFor(x => x.Name, f => f.Company.CompanyName())
			.RuleFor(x => x.UserId, _ => user.Id)
			.RuleFor(x => x.Description, f => f.Finance.Currency().Description);
	}
}