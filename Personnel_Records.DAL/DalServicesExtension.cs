using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Personnel_Records.DAL;
public static class DalServicesExtension
{
	public static void AddDataAccessLevelServices(this IServiceCollection services, string connection)
	{
		services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connection));
	}	

	public static void MigrateDatabase(this IServiceProvider servicesProvider)
	{
		using (var scope = servicesProvider.CreateScope())
		{
			var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
			dbContext.Database.Migrate();
		}
	}	
}
