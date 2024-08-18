using Application.Communication.Requests;
using Application.Communication.Responses;
using Application.Interfaces;
using Application.Services.User.Commands;
using Application.Services.User.Queries;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Serilog;

namespace Application.Services.User;

public class UserService : IUserService
{
	private readonly IMediator _mediator;
	private readonly IMapper _mapper;

	public UserService(IMediator mediator, IMapper mapper)
	{
		_mediator = mediator;
		_mapper = mapper;
	}

	public async Task<UserResponse> Create(UserRequest request)
	{
		await Validate(request);

		var user = _mapper.Map<UserCreateCommand>(request);

		var response = await _mediator.Send(user);

		return _mapper.Map<UserResponse>(response);
	}

	public async Task<UserResponse> GetById(Guid id)
	{
		var user = new GetUserByIdQuery(id);

		if (user is null) throw new ApplicationException("$Entity could not be loaded.");

		var result = await _mediator.Send(user);

		return _mapper.Map<UserResponse>(result);
	}

	private async Task Validate(UserRequest request)
	{
		var validator = new UserValidator();
		var result = await validator.ValidateAsync(request);

		var existsUser = await _mediator.Send(request.Email);

		if (existsUser is null)
			result.Errors.Add(new ValidationFailure("email", "Email já está registrado"));

		if (!result.IsValid)
		{
			var errorMessages = result.Errors
				.Select(error => error.ErrorMessage).ToList().FirstOrDefault();

			var concatenatedErrors = string.Join("\n", errorMessages);

			Log.ForContext("UserName", request.Email)
				.Error($"{concatenatedErrors}");

			throw new ValidationException(errorMessages);
		}
	}
}