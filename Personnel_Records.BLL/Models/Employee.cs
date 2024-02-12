using System.ComponentModel.DataAnnotations;
using CsvHelper.Configuration.Attributes;

namespace Personnel_Records.BLL.Models;
public class Employee
{
	[Required]
	[Name("Personnel_Records.Payroll_Number")]
	public string Payroll_Number { get; set; }

	[Required]
	[Name("Personnel_Records.Forenames")]
	public string Forenames { get; set; }

	[Required]
	[Name("Personnel_Records.Surname")]
	public string Surname { get; set; }

	[Required]
	[Name("Personnel_Records.Date_of_Birth")]
	public DateTime Date_of_Birth { get; set; }

	[Required]
	[Name("Personnel_Records.Telephone")]
	public string Telephone { get; set; }

	[Required]
	[Name("Personnel_Records.Mobile")]
	public string Mobile { get; set; }

	[Required]
	[Name("Personnel_Records.Address")]
	public string Address { get; set; }

	[Required]
	[Name("Personnel_Records.Address_2")]
	public string Address_2 { get; set; }

	[Required]
	[Name("Personnel_Records.Postcode")]
	public string Postcode { get; set; }

	[Required]
	[Name("Personnel_Records.EMail_Home")]
	public string Email_Home { get; set; }

	[Required]
	[Name("Personnel_Records.Start_Date")]
	public DateTime Start_Date { get; set; }
}
