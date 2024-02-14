using Personnel_Records.BLL.Models;

namespace Personnel_Records.BLL.Interfaces;
public interface IEmployeeRepository
{
	Task<int> AddAsync(Employee employee);
	Task<int> AddRangeAsync(IEnumerable<Employee> employees);
	Task<int> DeleteAsync(string payrolNumber);
	Task<IEnumerable<Employee>> GetAllAsync();
	Task<Employee?> GetByIdAsync(string payrolNumber);
	Task<int> UpdateAsync(Employee employee);
}