using Application.Communication.Requests;
using Application.Communication.Responses;

namespace Application.Interfaces;

public interface IUserService
{
	Task<UserResponse> Create(UserRequest request);
	Task<UserResponse> GetById(Guid id);
}