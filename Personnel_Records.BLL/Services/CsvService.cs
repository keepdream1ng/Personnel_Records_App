using CsvHelper;
using CsvHelper.Configuration;
using Personnel_Records.BLL.Interfaces;
using Personnel_Records.BLL.Utility;
using System.Globalization;

namespace Personnel_Records.BLL.Services;
public class CsvService : ICsvService
{
	public List<T> ParseCsv<T>(StreamReader streamReader, Action<CsvConfiguration> configureCsv = null) where T : class
	{
		var config = new CsvConfiguration(CultureInfo.InvariantCulture);
		// In case custom configuration if provided.
		configureCsv?.Invoke(config);

		using (var csvReader = new CsvReader(streamReader, config))
		{
			csvReader.Context.TypeConverterCache.AddConverter<DateTime>(new CustomDateTimeConverter());
			var records = csvReader.GetRecords<T>().ToList();
			return records;
		}
	}
}