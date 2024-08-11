using Application.Dto;
using Application.Services.User.Commands;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapper;

public class AutoMapperConfig : Profile
{
	public AutoMapperConfig()
	{
		//User
		CreateMap<UserDto, UserCreateCommand>().ReverseMap();
		CreateMap<UserDto, User>().ReverseMap();
		CreateMap<UserCreateCommand, User>().ReverseMap();
	}
}