using CsvHelper.Configuration;

namespace Personnel_Records.BLL.Interfaces;
public interface ICsvService
{
    List<T> ParseCsv<T>(StreamReader streamReader, Action<CsvConfiguration> configureCsv = null) where T : class;
}