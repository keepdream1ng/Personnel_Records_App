using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Personnel_Records.BLL.Interfaces;
using Personnel_Records.BLL.Models;

namespace Personnel_Records.BLL.Services;
public class EmployeeService(
	IEmployeeRepository repository,
	ICsvService csvService,
	ILogger<EmployeeService> logger
	) : IEmployeeService
{
	public async Task<int> AddEmployeesByFileAsync(IFormFile postedFile)
	{
		if (postedFile is null || postedFile.Length == 0)
		{
			return 0;
		}

		try
		{
			List<Employee> employees = new();
			// Reading data from the uploaded file
			using (var streamReader = new StreamReader(postedFile.OpenReadStream()))
			{
				employees.AddRange(csvService.ParseCsv<Employee>(streamReader));
			}
			return await repository.AddRangeAsync(employees);
		}
		catch (Exception ex)
		{
			logger.LogError("Failed to to add from file {PostedFile} with exception {Exception}", postedFile.FileName, ex);
			return 0;
		}
	}

	public async Task<IEnumerable<Employee>> GetAllSortedBySurnameAsync()
	{
		// Im cutting corners since no pagination requirements.
		IEnumerable<Employee> emmployees = await repository.GetAllAsync();
		emmployees.OrderBy(e => e.Surname);
		return emmployees;
	}

	public async Task<Employee?> FindByPayrollAsync(string payrollNumber)
	{
		return await repository.GetByIdAsync(payrollNumber);
	}

	public async Task<bool> UpdateAsync(Employee employee)
	{
		int result = await repository.UpdateAsync(employee);
		return (result > 0);
	}

	public async Task<bool> DeleteAsync(string payrollNumber)
	{
		int result = await repository.DeleteAsync(payrollNumber);
		return (result > 0);
	}
}
