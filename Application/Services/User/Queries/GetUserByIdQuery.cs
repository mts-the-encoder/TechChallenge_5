using MediatR;

namespace Application.Services.User.Queries;

public class GetUserByIdQuery : IRequest<Domain.Entities.User>
{
	public Guid Id { get; set; }

	public GetUserByIdQuery(Guid id) { Id = id; }
}