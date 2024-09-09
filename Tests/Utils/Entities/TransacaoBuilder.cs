using Bogus;
using Domain.Entities;

namespace Tests.Utils.Entities;

public class TransacaoBuilder
{
	public static Transacao Build(Portifolio portifolio, Ativo ativo)
	{
		var transacao = new Faker<Transacao>()
			.RuleFor(x => x.Id, f => f.Random.Guid())
			.RuleFor(x => x.PortifolioId, _ => portifolio.Id)
			.RuleFor(x => x.AtivoId, _ => ativo.Id)
			.RuleFor(x => x.Price, f => f.Random.Float(6, 600))
			.RuleFor(x => x.Quantity, f => f.Random.Int(2, 50));

		return transacao;
	}
}