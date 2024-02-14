using Microsoft.AspNetCore.Http;
using Personnel_Records.BLL.Models;

namespace Personnel_Records.BLL.Interfaces;
public interface IEmployeeService
{
    Task<int> AddEmployeesByFileAsync(IFormFile postedFile);
    Task<bool> DeleteAsync(string payrollNumber);
    Task<Employee?> FindByPayrollAsync(string payrollNumber);
    Task<IEnumerable<Employee>> GetAllSortedBySurnameAsync();
    Task<bool> UpdateAsync(Employee employee);
}