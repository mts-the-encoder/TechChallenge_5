using Application.Dto;

namespace Application.Interfaces;

public interface IUserService
{
	Task<UserDto> Create(UserDto productDto);
}