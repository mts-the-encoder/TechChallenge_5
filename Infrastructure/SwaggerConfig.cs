using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Infrastructure;

public static class SwaggerConfig
{
	public static IServiceCollection AddInfrastructureSwagger(this IServiceCollection services)
	{
		services.AddSwaggerGen(option =>
		{
			option.SwaggerDoc("v1", new OpenApiInfo { Title = "Tech Challenge 5", Version = "v1" });
			option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
			{
				Name = "Authorization",
				Type = SecuritySchemeType.Http,
				Scheme = "Bearer",
				In = ParameterLocation.Header,
				Description = "JWT Authorization header with o Bearer scheme. Example: \"Authorization: Bearer {token}\""
			});
			option.AddSecurityRequirement(new OpenApiSecurityRequirement
			{
				{
					new OpenApiSecurityScheme
					{
						Reference = new OpenApiReference
						{
							Type = ReferenceType.SecurityScheme,
							Id = "Bearer"
						}
					},
					Array.Empty<string>()
				}
			});
		});

		return services;
	}
}