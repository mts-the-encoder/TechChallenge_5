using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Context;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions options) : base(options) { }

	public AppDbContext() { }

	public DbSet<User> User { get; set; }
	public DbSet<Ativo> Ativo { get; set; }
	public DbSet<Portifolio> Portifolio { get; set; }
	public DbSet<Transacao> Transacao { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		var connectionString = "";
		optionsBuilder.UseSqlServer(connectionString);
		base.OnConfiguring(optionsBuilder);
	}

	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);
		builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
	}
}