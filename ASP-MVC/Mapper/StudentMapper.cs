using ASP_MVC.Models.Student;
using BLL.Entities;

namespace ASP_MVC.Mapper
{
	internal static class StudentMapper
	{
		/// <summary>
		/// BLL Student  To StudentListItem
		/// </summary>
		/// <param name="student">BLL Student</param>
		/// <returns>StudentListItem</returns>
		/// <exception cref="ArgumentNullException"></exception>
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

		/// <summary>
		/// BLL Student To StudentDetails
		/// </summary>
		/// <param name="student">BLL Student</param>
		/// <returns>StudentDetail</returns>
		/// <exception cref="ArgumentNullException"></exception>
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

		/// <summary>
		/// Convert data from createForm To BLL Student
		/// </summary>
		/// <param name="student">StudentCreateForm</param>
		/// <returns>BLL Student</returns>
		/// <exception cref="ArgumentNullException"></exception>
		public static Student ToBLL(this StudentCreate student)
		{
			if(student is null) throw new ArgumentNullException(nameof (student));
			return new Student(
				-1,
				student.First_name,
				student.Last_name,
				null,
				student.Birth_date,
				"0",
				null,
				null
			);
		}


		/// <summary>
		/// Convert Data From StudentUpdateForm to Bll Student
		/// </summary>
		/// <param name="student">StudentUpdateForm</param>
		/// <returns>Bll Student</returns>
		/// <exception cref="ArgumentNullException"></exception>
		public static Student ToBLL(this StudentUpdate student)
		{
			if (student is null) throw new ArgumentNullException(nameof(student));
			return new Student(
				student.Student_id,
				student.First_name,
				student.Last_name,
				student.Login,
				student.Birth_date,
				student.Course_id,
				student.Section_id,
				student.Year_result
				
			);
		}

		public static StudentUpdate ToEditForm(this Student student)
		{
			if( student is null) throw new ArgumentNullException( nameof(student));
			return new StudentUpdate
			{
				Student_id = student.Student_id,
				First_name = student.First_name,
				Last_name = student.Last_name,
				Birth_date = student.Birth_date,
				Year_result = student.Year_result,
				Section_id = student.Section_id,
				Course_id = student.Course_id,
				Login = student.Login
			};
		}


	}
}
