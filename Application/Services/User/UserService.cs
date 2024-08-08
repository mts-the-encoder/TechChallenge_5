using Application.Dto;
using Application.Interfaces;
using Application.Services.User.Commands;
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

	public async Task<UserDto> Create(UserDto productDto)
	{
		var product = _mapper.Map<UserCreateCommand>(productDto);

		var response = await _mediator.Send(product);

		return _mapper.Map<UserDto>(response);
	}
}