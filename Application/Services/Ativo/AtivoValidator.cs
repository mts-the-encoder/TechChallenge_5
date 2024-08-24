using Application.Communication.Requests;
using FluentValidation;

namespace Application.Services.Ativo;

public class AtivoValidator : AbstractValidator<AtivoRequest>
{
	public AtivoValidator()
	{
		//RuleFor(x => x.TipoAtivo).NotEmpty().WithMessage("Tipo do ativo deve ser enviado");
		RuleFor(x => x.Name).NotEmpty().WithMessage("Nome não pode ser vazio");
		RuleFor(x => x.Codigo).NotEmpty().WithMessage("Codigo deve ser enviado"); ;
	}
}