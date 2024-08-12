using Application.Mapper;
using AutoMapper;

namespace Tests.Utils.Mapper;

public class MapperBuilder
{
	public static IMapper Instance()
	{

		var config = new MapperConfiguration(cfg =>
		{
			cfg.AddProfile(new AutoMapperConfig());
		});

		return config.CreateMapper();
	}
}