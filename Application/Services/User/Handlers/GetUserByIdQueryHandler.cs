using Application.Services.User.Queries;
using Domain.Repositories;
using MediatR;

namespace Application.Services.User.Handlers;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, Domain.Entities.User>
{
	private readonly IUserRepository _repository;
	public GetUserByIdQueryHandler(IUserRepository repository)
	{
		_repository = repository;
	}

	public async Task<Domain.Entities.User?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
	{
		return await _repository.GetById(request.Id);
	}

}