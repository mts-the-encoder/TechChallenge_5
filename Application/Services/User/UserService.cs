using Application.Communication.Responses;
using Application.Exceptions;
using Application.Interfaces;
using Application.Services.User.Commands;
using Application.Services.User.Queries;
using AutoMapper;
using MediatR;

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

	public async Task<UserResponse> Create(UserCommand request)
	{
		//await Validate(request);

		var user = _mapper.Map<UserCreateCommand>(request);

		var response = await _mediator.Send(user);

		return _mapper.Map<UserResponse>(response);
	}

	public async Task<UserResponse> GetById(Guid id)
	{
		var user = new GetUserByIdQuery(id);

		if (user is null) throw new ValidationErrorsException(new List<string> { "Não encontrado" });

		var result = await _mediator.Send(user);

		return _mapper.Map<UserResponse>(result);
	}

	public async Task<LoginResponse> Login(LoginQuery request)
	{
		var user = new LoginQuery(request.Email, request.Password);

		if (user is null) throw new InvalidLoginException();

		var result = await _mediator.Send(user);

		return result;
	}
}