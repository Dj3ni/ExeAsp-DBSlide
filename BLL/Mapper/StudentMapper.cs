using BLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mapper
{
	internal static class StudentMapper
	{
		public static Student ToBLL(this DAL.Entities.Student student)
		{
			if(student is null) throw new ArgumentNullException(nameof(student));
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
	}
}
