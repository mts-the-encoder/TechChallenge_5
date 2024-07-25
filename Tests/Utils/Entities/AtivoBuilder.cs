using Bogus;
using Domain.Entities;
using Domain.Enums;

namespace Tests.Utils.Entities;

public class AtivoBuilder
{
	public static Ativo Build()
	{
		return new Faker<Ativo>()
			.RuleFor(x => x.Id, f => f.Random.Guid())
			.RuleFor(x => x.Name, f => f.Finance.Account())
			.RuleFor(x => x.TipoAtivo, f => f.PickRandom<TipoAtivo>())
			.RuleFor(x => x.Codigo, f => f.Finance.Currency().Code);
	}
}