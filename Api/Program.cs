using Api.Filters;
using Api.Middleware;
using Application.Mapper;
using Infrastructure;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Dependency Injection
builder.Services.AddDI(builder.Configuration);
builder.Services.AddInfrastructureSwagger();
builder.Services.AddScoped<AuthenticatedUserAttribute>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

builder.Services.AddMvc(opt => opt.Filters.Add(typeof(ExceptionsFilter)));

builder.Services.AddScoped(provider => new AutoMapper.MapperConfiguration(cfg =>
{
	cfg.AddProfile(new AutoMapperConfig());
}).CreateMapper());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

Log.Logger = new LoggerConfiguration()
	.WriteTo.Console()
	.CreateLogger();

//app.UseHttpLogging();

app.UseMiddleware<SerilogRequestLogger>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
