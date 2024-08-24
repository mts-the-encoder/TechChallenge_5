using Application.Communication.Requests;
using FluentValidation;

namespace Application.Services.Transacao;

public class TransacaoValidator : AbstractValidator<TransacaoRequest>
{
	public TransacaoValidator()
	{
		RuleFor(x => x.PortifolioId).NotEmpty().WithMessage("Id do portifólio não pode ser vazio");
		RuleFor(x => x.AtivoId).NotEmpty().WithMessage("Id do ativo não pode ser vazio");
		RuleFor(x => x.Quantity).NotEmpty().GreaterThanOrEqualTo(1).WithMessage("Quantidade deve ser maior que 0");
		RuleFor(x => x.Price).NotEmpty().GreaterThanOrEqualTo(5).WithMessage("O preço mais baixo é R$ 5"); ;
	}
}