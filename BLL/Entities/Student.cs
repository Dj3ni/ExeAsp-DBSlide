using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
	public class Student
	{
		public int Student_id { get; set; }
		public string? First_name { get; set; }
		public string? Last_name { get; set; }
		public DateOnly? Birth_date { get; set; }
		public string? Login { get; set; }
		public int? Year_result { get; set; }
		public string Course_id { get; set; }
		public int? Section_id { get; set; }

		public Student(int student_id, string? first_name, string? last_name, string? login, DateOnly? birth_date, string course_id, int? section_id, int? year_result = null)
		{
			Student_id = student_id;
			First_name = first_name;
			Last_name = last_name;
			Birth_date = birth_date;
			Login = login ?? CreateLogin(first_name, last_name);
			Year_result = year_result;
			Course_id = course_id;
			Section_id = section_id;
		}

		public Student(int student_id, string? first_name, string? last_name, int? yearResult = null, string course_id = "0" )
		{
			Student_id = student_id;
			First_name = first_name;
			Last_name = last_name;
			Year_result = yearResult;
			Course_id = course_id;
		}

		public  string? CreateLogin(string? firstname, string? lastname)
		{
			if (firstname is null || lastname is null) return null;
			return firstname.Substring(1,1) + lastname;
		}
	}
}
