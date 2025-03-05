using System.ComponentModel.DataAnnotations;

namespace ASP_MVC.Models.Student
{
	public class StudentListItem
	{
		[ScaffoldColumn(false)]
		public int Student_id { get; set; }
		
		public string? First_Name { get; set; }
		public string? Last_Name { get;set; }

		public int? Year_Result { get; set; }

	}
}
