using Application.Communication.Requests;
using FluentValidation;

namespace Application.Services.User;

public class UserValidator : AbstractValidator<UserRequest>
{
	public UserValidator()
	{
		RuleFor(x => x.Name).NotEmpty().WithMessage("Email já está registrado");
		RuleFor(x => x.Email).NotEmpty().WithMessage("Email não pode ser vazio");
		RuleFor(x => x.Password).NotEmpty().MinimumLength(6).WithMessage("Senha deve ter 6 caracteres"); ;

		When(x => !string.IsNullOrWhiteSpace(x.Email), () =>
		{
			RuleFor(x => x.Email).EmailAddress().WithMessage("Email inválido");
		});
	}
}