using Personnel_Records.BLL.Interfaces;
using Personnel_Records.BLL.Services;
using Personnel_Records.DAL;
using Personnel_Records.DAL.Repositories;
namespace Personnel_Records.Web;

public class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		// Add services to the container.
		string connection = builder.Configuration.GetConnectionString("DefaultConnection")!;
		builder.Services.AddDataAccessLevelServices(connection);
		builder.Services.AddControllersWithViews();
		builder.Services.AddTransient<ICsvService, CsvService>();
		builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
		builder.Services.AddTransient<IEmployeeService, EmployeeService>();

		var app = builder.Build();

		// Configure the HTTP request pipeline.
		if (!app.Environment.IsDevelopment())
		{
			app.UseExceptionHandler("/Home/Error");
			app.UseHsts();
		}

		app.Services.MigrateDatabase();
		app.UseHttpsRedirection();
		app.UseStaticFiles();

		app.UseRouting();

		app.UseAuthorization();

		app.MapControllerRoute(
			name: "default",
			pattern: "{controller=Home}/{action=Index}/{id?}");

		app.Run();
	}
}
