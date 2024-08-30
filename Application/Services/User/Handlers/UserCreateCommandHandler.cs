using Application.Services.User.Commands;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.Services.User.Handlers;

internal class UserCreateCommandHandler : IRequestHandler<UserCreateCommand, Domain.Entities.User>
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
		var user = _mapper.Map<Domain.Entities.User>(request);

		await _repository.Create(user);

		return user;
	}
}