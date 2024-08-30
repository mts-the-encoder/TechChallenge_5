using Application.Communication.Requests;
using Application.Communication.Responses;
using Domain.Entities;

namespace Application.Interfaces;

public interface IUserService
{
	Task<UserResponse> Create(UserRequest request);
	Task<UserResponse> GetById(Guid id);
	Task<LoginResponse> Login(LoginRequest request);
}