using Application.Communication.Responses;
using Application.Services.Ativo.Commands;
using Application.Services.Portifolio.Commands;
using Application.Services.Transacao.Commands;
using Application.Services.User.Commands;
using Application.Services.User.Queries;
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
		CreateMap<UserCommand, UserCreateCommand>().ReverseMap();
		CreateMap<UserCreateCommand, User>().ReverseMap();
		CreateMap<UserCommand, User>();
		CreateMap<LoginResponse, User>().ReverseMap();
		CreateMap<LoginQuery, User>().ReverseMap();

		//Portifolio
		CreateMap<PortifolioCommand, PortifolioCreateCommand>().ReverseMap();
		CreateMap<PortifolioCommand, Portifolio>().ReverseMap();
		CreateMap<PortifolioResponse, Portifolio>().ReverseMap();
		CreateMap<PortifolioResponse, PortifolioCreateCommand>().ReverseMap();
		CreateMap<PortifolioCreateCommand, Portifolio>().ReverseMap();

		//Ativo
		CreateMap<AtivoCommand, AtivoCreateCommand>().ReverseMap();
		CreateMap<AtivoCommand, Ativo>().ReverseMap();
		CreateMap<AtivoResponse, Ativo>().ReverseMap();
		CreateMap<AtivoResponse, AtivoCreateCommand>().ReverseMap();
		CreateMap<AtivoCommand, AtivoUpdateCommand>().ReverseMap();
		CreateMap<Ativo, AtivoUpdateCommand>().ReverseMap();
		CreateMap<AtivoCreateCommand, Ativo>().ReverseMap();

		//Transacao
		CreateMap<TransacaoCommand, TransacaoCreateCommand>().ReverseMap();
		CreateMap<TransacaoCommand, Transacao>().ReverseMap();
		CreateMap<TransacaoResponse, Transacao>().ReverseMap();
		CreateMap<TransacaoResponse, TransacaoCreateCommand>().ReverseMap();
		CreateMap<TransacaoCreateCommand, Transacao>().ReverseMap();
	}
}
