using Microsoft.EntityFrameworkCore;
using Personnel_Records.BLL.Interfaces;
using Personnel_Records.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personnel_Records.DAL.Repositories;
public class EmployeeRepository(AppDbContext dbContext) : IEmployeeRepository
{
	public async Task<int> AddRangeAsync(IEnumerable<Employee> employees)
	{
		await dbContext.Employees.AddRangeAsync(employees);
		return await dbContext.SaveChangesAsync();
	}

	public async Task<IEnumerable<Employee>> GetAllAsync()
	{
		return await dbContext.Employees.ToListAsync();
	}

	public async Task<int> AddAsync(Employee employee)
	{
		dbContext.Employees.Add(employee);
		return await dbContext.SaveChangesAsync();
	}

	public async Task<Employee?> GetByIdAsync(string payrolNumber)
	{
		return await dbContext.Employees.FirstOrDefaultAsync(e => e.PayrollNumber == payrolNumber);
	}

	public async Task<int> UpdateAsync(Employee employee)
	{
		dbContext.Entry(employee).State = EntityState.Modified;
		return await dbContext.SaveChangesAsync();
	}

	public async Task<int> DeleteAsync(string payrolNumber)
	{
		var employee = await GetByIdAsync(payrolNumber);
		if (employee != null)
		{
			dbContext.Employees.Remove(employee);
			return await dbContext.SaveChangesAsync();
		}
		// Indicates no changes were made.
		return 0;
	}
}
