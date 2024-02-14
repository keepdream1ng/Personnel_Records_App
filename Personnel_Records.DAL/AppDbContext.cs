using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Personnel_Records.BLL.Models;

namespace Personnel_Records.DAL;
public class AppDbContext : DbContext
{
	public DbSet<Employee> Employees => Set<Employee>();

	public AppDbContext():base() { }
	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
	{
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlServer();
	}
}
