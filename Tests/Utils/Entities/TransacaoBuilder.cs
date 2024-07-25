using Bogus;
using Domain.Entities;

namespace Tests.Utils.Entities;

public class TransacaoBuilder
{
	public static Transacao Build(Portifolio portifolio, Ativo ativo)
	{
		return new Faker<Transacao>()
			.RuleFor(x => x.Id, _ => portifolio.Id)
			.RuleFor(x => x.PortifolioId, _ => portifolio.Id)
			.RuleFor(x => x.AtivoId, _ => ativo.Id)
			.RuleFor(x => x.Price, f => f.Random.Float())
			.RuleFor(x => x.Quantity, f => f.Random.Int())
			.RuleFor(x => x.TransactionDate, f => f.DateTimeReference);
	}
}