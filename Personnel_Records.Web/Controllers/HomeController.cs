using Microsoft.AspNetCore.Mvc;
using Personnel_Records.BLL.Interfaces;
using Personnel_Records.BLL.Models;
using Personnel_Records.Web.Models;
using System.Diagnostics;
using System.Globalization;

namespace Personnel_Records_Web.Controllers;
public class HomeController(IEmployeeService employeeService) : Controller
{
	[HttpGet]
	public async Task<IActionResult> Index()
	{
		var employees = await employeeService.GetAllSortedBySurnameAsync();
		return View(employees);
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Index(IFormFile postedFile)
	{
		int result = await employeeService.AddEmployeesByFileAsync(postedFile);
		if (result == 0)
		{
			return RedirectToAction("ImportError");
		}
		return RedirectToAction("Index");
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
