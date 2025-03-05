using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASP_MVC.Models.Student
{
	public class StudentCreate
	{
		[DisplayName("First Name")]
		public string? First_name { get; set; }

		[DisplayName("Last Name")]
		public string? Last_name { get; set; }

		[DisplayName("Birth Date")]
		[DataType(DataType.Date)]
		public DateOnly? Birth_date { get; set; }

	}
}

