using FluentValidation;
using PortifolioRequest = Application.Communication.Requests.PortifolioRequest;

namespace Application.Services.Portifolio;

public class PortifolioValidator : AbstractValidator<PortifolioRequest>
{
	public PortifolioValidator()
	{
		RuleFor(x => x.UserId).NotEmpty().WithMessage("Id do usuário deve ser enviado");
		RuleFor(x => x.Name).NotEmpty().WithMessage("Nome não pode ser vazio");
		RuleFor(x => x.Description).NotEmpty().WithMessage("Descrição não pode ser vazia");
	}
}