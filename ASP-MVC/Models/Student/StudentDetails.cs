using System.ComponentModel.DataAnnotations;

namespace ASP_MVC.Models.Student
{
	public class StudentDetails
	{
		[ScaffoldColumn(false)]
		public int Student_id { get; set; }
		public string? First_name { get; set; }
		public string? Last_name { get; set; }

		[DataType(DataType.Date)]
		public DateOnly? Birth_date { get; set; }
		public string? Login { get; set; }
		public int? Year_result { get; set; }
		public string Course_id { get; set; }
		public int? Section_id { get; set; }
	}
}
