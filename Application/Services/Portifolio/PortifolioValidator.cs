using Application.Services.Portifolio.Commands;
using FluentValidation;

namespace Application.Services.Portifolio;

public class PortifolioValidator : AbstractValidator<PortifolioCommand>
{
	public PortifolioValidator()
	{
		RuleFor(x => x.UserId).NotEmpty().WithMessage("Id do usuário deve ser enviado");
		RuleFor(x => x.Name).NotEmpty().WithMessage("Nome não pode ser vazio");
		RuleFor(x => x.Description).NotEmpty().WithMessage("Descrição não pode ser vazia");
	}
}