using CsvHelper.Configuration;

namespace Personnel_Records.BLL.Services;
public interface ICsvService
{
	List<T> ParseCsv<T>(StreamReader streamReader, Action<CsvConfiguration> configureCsv = null) where T : class;
}