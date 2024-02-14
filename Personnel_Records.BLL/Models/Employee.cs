using System.ComponentModel.DataAnnotations;
using CsvHelper.Configuration.Attributes;

namespace Personnel_Records.BLL.Models;
public class Employee
{
	[Required]
	[Name("Personnel_Records.Payroll_Number")]
	public string PayrollNumber { get; set; }

	[Required]
	[Name("Personnel_Records.Forenames")]
	public string Forenames { get; set; }

	[Required]
	[Name("Personnel_Records.Surname")]
	public string Surname { get; set; }

	[Required]
	[Name("Personnel_Records.Date_of_Birth")]
	public DateTime DateOfBirth { get; set; }

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
	public string Address2 { get; set; }

	[Required]
	[Name("Personnel_Records.Postcode")]
	public string Postcode { get; set; }

	[Required]
	[Name("Personnel_Records.EMail_Home")]
	public string EmailHome { get; set; }

	[Required]
	[Name("Personnel_Records.Start_Date")]
	public DateTime StartDate { get; set; }
}
