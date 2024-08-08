using System.Reflection;
using Infrastructure.Context;
using Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
	public static IServiceCollection AddDI(this IServiceCollection services, IConfiguration configuration)
	{
		AddRepositories(services);
		AddServices(services);
		AddContext(services, configuration);
		AddUnitOfWork(services);
		AddMediatr(services);

		return services;
	}

	private static void AddContext(IServiceCollection services, IConfiguration configuration)
	{
		services.AddDbContext<AppDbContext>(options =>
			options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
	}

	private static void AddUnitOfWork(IServiceCollection services)
	{
		services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
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

	private static void AddServices(IServiceCollection services)
	{
		var types = Assembly.GetExecutingAssembly().GetTypes()
			.Where(x => x.GetInterfaces().Any(i => i.Name.EndsWith("Service")));

		foreach (var type in types)
		{
			var interfaces = type.GetInterfaces();
			foreach (var inter in interfaces)
				services.AddScoped(inter, type);
		}
	}

	private static void AddMediatr(IServiceCollection services)
	{
		var myHandlers = AppDomain.CurrentDomain.Load("Application");
		services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(myHandlers));
	}
}