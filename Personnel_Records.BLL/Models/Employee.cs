using System.ComponentModel.DataAnnotations;

namespace Personnel_Records.BLL.Models;
public class Employee
{
	[Required]
	public string Payroll_Number { get; set; }

	[Required]
	public string Forenames { get; set; }

	[Required]
	public string Surname { get; set; }

	[Required]
	public DateTime Date_of_Birth { get; set; }

	[Required]
	public string Telephone { get; set; }

	[Required]
	public string Mobile { get; set; }

	[Required]
	public string Address { get; set; }

	[Required]
	public string Address_2 { get; set; }

	[Required]
	public string Postcode { get; set; }

	[Required]
	public string Email_Home { get; set; }

	[Required]
	public DateTime Start_Date { get; set; }
}
