using Domain.Entities;
using FluentAssertions;
using FluentValidation;
using Tests.Utils.Entities;

namespace Tests.Domain.Tests;

public class TransacaoTest
{
	[Fact]
	public void Validate_Failure()
	{
		var user = UserBuilder.Build();
		var portifolio = PortifolioBuilder.Build(user);
		var ativo = AtivoBuilder.Build();

		ativo.Id = Guid.Empty;

		var transacao = () => TransacaoBuilder.Build(portifolio, ativo);

		transacao.Should().Throw<NullReferenceException>();
	}
}