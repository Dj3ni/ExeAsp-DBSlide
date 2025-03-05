using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASP_MVC.Models.Student
{
	public class StudentUpdate
	{
		[ScaffoldColumn(false)]
		public int Student_id { get; set; }

		[ScaffoldColumn(false)]
		public string Login {  get; set; }

		[DisplayName("First Name")]
		public string? First_name { get; set; }

		[DisplayName("Last Name")]
		public string? Last_name { get; set; }

		[DisplayName("Birth Date")]
		[DataType(DataType.Date)]
		public DateOnly? Birth_date { get; set; }

		[DisplayName("Year Result /20")]
		public int? Year_result { get; set; }

		[ScaffoldColumn(false)]
		public string Course_id { get; set; }
		[ScaffoldColumn(false)]
		public int? Section_id { get; set; }
	}
}
