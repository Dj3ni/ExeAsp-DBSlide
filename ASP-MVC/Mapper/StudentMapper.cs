using ASP_MVC.Models.Student;
using BLL.Entities;

namespace ASP_MVC.Mapper
{
	internal static class StudentMapper
	{
		public static StudentListItem ToListItem(this Student student)
		{
			if(student is null) throw new ArgumentNullException(nameof(student));
			return new StudentListItem()
			{
				Student_id = student.Student_id,
				First_Name = student.First_name,
				Last_Name = student.Last_name,	
				Year_Result = student.Year_result,

			};
		}

		public static StudentDetails ToStudentDetails(this Student student)
		{
			if(student is null) throw new ArgumentNullException( nameof(student));
			return new StudentDetails()
			{
				Student_id = student.Student_id,
				First_name = student.First_name,
				Last_name = student.Last_name,
				Birth_date = student.Birth_date,
				Login = student.Login,
				Section_id = student.Section_id,
				Course_id = student.Course_id,
				Year_result = student.Year_result,
			};
		}
	}
}
