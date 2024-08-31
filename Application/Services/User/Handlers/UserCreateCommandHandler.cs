using Application.Exceptions;
using Application.Services.User.Commands;
using AutoMapper;
using Domain.Repositories;
using MediatR;
using Serilog;

namespace Application.Services.User.Handlers;

public class UserCreateCommandHandler : IRequestHandler<UserCreateCommand, Domain.Entities.User>
{
	private readonly IUserRepository _repository;
	private readonly IMapper _mapper;

	public UserCreateCommandHandler(IUserRepository repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task<Domain.Entities.User> Handle(UserCreateCommand request, CancellationToken cancellationToken)
	{
		await Validate(request);

		var user = _mapper.Map<Domain.Entities.User>(request);

		await _repository.Create(user);

		return user;
	}

	private async Task Validate(UserCreateCommand request)
	{
		var validator = new UserValidator();
		var result = await validator.ValidateAsync(request);

		if (!result.IsValid)
		{
			var errorMessages = result.Errors
				.Select(error => error.ErrorMessage).ToList();

			var concatenatedErrors = string.Join("\n", errorMessages);

			Log.ForContext("UserName", request.Email)
				.Error($"{concatenatedErrors}");

			throw new ValidationErrorsException(errorMessages);
		}
	}
}