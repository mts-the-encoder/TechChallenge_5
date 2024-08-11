using Application.Communication.Requests;
using Application.Communication.Responses;
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

	public async Task<UserResponse> Create(UserRequest request)
	{
		var product = _mapper.Map<UserCreateCommand>(request);

		var response = await _mediator.Send(product);

		return _mapper.Map<UserResponse>(response);
	}

	public async Task<UserResponse> GetById(Guid id)
	{
		var user = new GetUserByIdQuery(id);

		if (user is null) throw new ApplicationException("$Entity could not be loaded.");

		var result = await _mediator.Send(user);

		return _mapper.Map<UserResponse>(result);
	}
}