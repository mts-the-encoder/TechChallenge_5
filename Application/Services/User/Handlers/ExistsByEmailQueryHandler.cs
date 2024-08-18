using Application.Services.User.Queries;
using Domain.Repositories;
using MediatR;

namespace Application.Services.User.Handlers;

public class ExistsByEmailQueryHandler : IRequestHandler<ExistsByEmailQuery, bool>
{
	private readonly IUserRepository _repository;
	public ExistsByEmailQueryHandler(IUserRepository repository)
	{
		_repository = repository;
	}

	public async Task<bool> Handle(ExistsByEmailQuery request, CancellationToken cancellationToken)
	{
		return await _repository.ExistsByEmail(request.Email);
	}
}
