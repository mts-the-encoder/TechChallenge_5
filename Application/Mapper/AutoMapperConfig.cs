using Application.Communication.Requests;
using Application.Communication.Responses;
using Application.Services.User.Commands;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapper;

public class AutoMapperConfig : Profile
{
	public AutoMapperConfig()
	{
		//User
		CreateMap<UserResponse, User>().ReverseMap();
		CreateMap<UserResponse, UserCreateCommand>().ReverseMap();
		CreateMap<UserRequest, UserCreateCommand>().ReverseMap();
		CreateMap<UserRequest, User>().ReverseMap();
		CreateMap<UserCreateCommand, User>().ReverseMap();
	}
}