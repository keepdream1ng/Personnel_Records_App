using Microsoft.AspNetCore.Mvc;
using Personnel_Records.BLL.Models;
using Personnel_Records.BLL.Services;
using Personnel_Records.Web.Models;
using System.Diagnostics;
using System.Globalization;

namespace Personnel_Records_Web.Controllers;
public class HomeController : Controller
{
	private readonly ICsvService _csvService;

	public HomeController(ICsvService csvService)
	{
		_csvService = csvService;
	}

	[HttpGet]
	public IActionResult Index()
	{
		return View();
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public IActionResult Index(IFormFile postedFile)
	{
		// Checking if user uploaded a file
		if (postedFile is null || postedFile.Length == 0)
		{
			return RedirectToAction("ImportError");
		}

		List<Employee> employees = new();
		// Reading data from the uploaded file
		using (var streamReader = new StreamReader(postedFile.OpenReadStream()))
		{
			List<Employee> emp = _csvService.ParseCsv<Employee>(streamReader);
			employees.AddRange(emp);
		}
		return View(employees);
	}

	[HttpGet]
	public IActionResult ImportError()
	{
		return View();
	}

	[HttpGet]
	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
	public IActionResult Error()
	{
		return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
	}
}
