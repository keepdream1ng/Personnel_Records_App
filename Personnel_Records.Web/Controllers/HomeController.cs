using Microsoft.AspNetCore.Mvc;
using Personnel_Records.BLL.Models;
using Personnel_Records.Web.Models;
using System.Diagnostics;
using System.Globalization;

namespace Personnel_Records_Web.Controllers;
public class HomeController : Controller
{
	public HomeController()
	{
	}

	[HttpGet]
	public IActionResult Index()
	{
		return View();
	}

	[HttpPost]
	public IActionResult Index(IFormFile postedFile)
	{
		try
		{
			// Checking if user uploaded a file
			if (postedFile != null && postedFile.Length > 0)
			{
				List<Employee> employees = new();
				// Reading data from the uploaded file
				using (var streamReader = new StreamReader(postedFile.OpenReadStream()))
				{
					// Skipping header line
					streamReader.ReadLine();

					// Processing file content
					while (!streamReader.EndOfStream)
					{
						var line = streamReader.ReadLine();
						if (!string.IsNullOrEmpty(line))
						{
							var cells = line.Split(',');

							// Assuming your Employee class structure here
							var emp = new Employee
							{
								Payroll_Number = cells[0],
								Forenames = cells[1],
								Surname = cells[2],
								Date_of_Birth = DateTime.ParseExact(cells[3], "d/M/yyyy", CultureInfo.InvariantCulture),
								Telephone = cells[4],
								Mobile = cells[5],
								Address = cells[6],
								Address_2 = cells[7],
								Postcode = cells[8],
								Email_Home = cells[9],
								Start_Date = DateTime.ParseExact(cells[10], "dd/MM/yyyy", CultureInfo.InvariantCulture)
							};
							employees.Add(emp);
						}
					}
				}

				return View(employees);
			}

			// If user uploads an empty file
			return RedirectToAction("ImportError");
		}
		catch (Exception ex)
		{
			return BadRequest($"{ex.Message} \nTry again with correct file and format!!!");
		}
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
