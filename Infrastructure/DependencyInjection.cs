using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Application.Interfaces;
using Application.Services.Ativo;
using Application.Services.User;
using Application.Services.Portifolio;
using Application.Services.Transacao;
using Application.Services.Token;

namespace Infrastructure;

public static class DependencyInjection
{
	public static IServiceCollection AddDI(this IServiceCollection services, IConfiguration configuration)
	{
		AddRepositories(services);
		AddServices(services);
		AddContext(services, configuration);
		AddTokenJwt(services, configuration);
		AddMediatr(services);

		return services;
	}

	private static void AddContext(IServiceCollection services, IConfiguration configuration)
	{
		services.AddDbContext<AppDbContext>(options =>
			options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
	}

	private static void AddRepositories(IServiceCollection services)
	{
		var types = Assembly.GetExecutingAssembly().GetTypes()
			.Where(x => x.GetInterfaces().Any(i => i.Name.EndsWith("Repository")));

		foreach (var type in types)
		{
			var interfaces = type.GetInterfaces();
			foreach (var inter in interfaces)
				services.AddScoped(inter, type);
		}
	}

	private static void AddTokenJwt(IServiceCollection services, IConfiguration configuration)
	{
		var sectionLifeTime = configuration.GetValue<string>("Configurations:Jwt:LifeTimeInMinutes");
		var sectionToken = configuration.GetValue<string>("Configurations:Jwt:TokenKey");

		services.AddScoped(opt => new TokenService(int.Parse(sectionLifeTime), sectionToken));
	}

	private static void AddServices(IServiceCollection services)
	{
		services.AddScoped<IUserService, UserService>();
		services.AddScoped<IPortifolioService, PortifolioService>();
		services.AddScoped<IAtivoService, AtivoService>();
		services.AddScoped<ITransacaoService, TransacaoService>();
	}

	private static void AddMediatr(IServiceCollection services)
	{
		var myHandlers = AppDomain.CurrentDomain.Load("Application");
		services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(myHandlers));
	}
}