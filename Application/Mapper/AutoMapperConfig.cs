using Application.Communication.Requests;
using Application.Communication.Responses;
using Application.Services.Ativo.Commands;
using Application.Services.Portifolio.Commands;
using Application.Services.Transacao.Commands;
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

		//Portifolio
		CreateMap<PortifolioResponse, Portifolio>().ReverseMap();
		CreateMap<PortifolioResponse, PortifolioCreateCommand>().ReverseMap();
		CreateMap<PortifolioRequest, PortifolioCreateCommand>().ReverseMap();
		CreateMap<PortifolioRequest, Portifolio>().ReverseMap();
		CreateMap<PortifolioCreateCommand, Portifolio>().ReverseMap();

		//Ativo
		CreateMap<AtivoResponse, Ativo>().ReverseMap();
		CreateMap<AtivoResponse, AtivoCreateCommand>().ReverseMap();
		CreateMap<AtivoRequest, AtivoCreateCommand>().ReverseMap();
		CreateMap<AtivoRequest, Ativo>().ReverseMap();
		CreateMap<AtivoCreateCommand, Ativo>().ReverseMap();

		//Transacao
		CreateMap<TransacaoResponse, Transacao>().ReverseMap();
		CreateMap<TransacaoResponse, TransacaoCreateCommand>().ReverseMap();
		CreateMap<TransacaoRequest, TransacaoCreateCommand>().ReverseMap();
		CreateMap<TransacaoRequest, Transacao>().ReverseMap();
		CreateMap<TransacaoCreateCommand, Transacao>().ReverseMap();
	}
}