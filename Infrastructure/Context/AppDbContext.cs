using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Context;

public class AppDbContext : DbContext
{
	private readonly IConfiguration _configuration;
	public AppDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
	{
		_configuration = configuration;
	}

	public AppDbContext(IConfiguration configuration)
	{
		_configuration = configuration;
	}

	public DbSet<User> User { get; set; }
	public DbSet<Ativo> Ativo { get; set; }
	public DbSet<Portifolio> Portifolio { get; set; }
	public DbSet<Transacao> Transacao { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		var connectionString = _configuration.GetConnectionString("DefaultConnection");
		optionsBuilder.UseSqlServer(connectionString);
		optionsBuilder.EnableSensitiveDataLogging();
		base.OnConfiguring(optionsBuilder);
	}

	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);
		builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
	}
}