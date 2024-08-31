using Application.Communication.Responses;
using Application.Services.User.Commands;
using Application.Services.User.Queries;

namespace Application.Interfaces;

public interface IUserService
{
	Task<UserResponse> Create(UserCommand request);
	Task<UserResponse> GetById(Guid id);
	Task<LoginResponse> Login(LoginQuery request);
}