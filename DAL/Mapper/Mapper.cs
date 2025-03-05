using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mapper
{
	internal static class Mapper
	{
		public static Student ToStudent(this IDataReader reader)
		{
			if (reader == null) throw new ArgumentNullException(nameof(reader));
			return new Student()
			{
				Student_id = (int)reader[nameof(Student.Student_id)],
				First_name = (reader[nameof(Student.First_name)] is DBNull)? null : (string)reader[nameof(Student.First_name)],
				Last_name = (reader[nameof(Student.Last_name)] is DBNull) ? null : (string)reader[nameof(Student.Last_name)],
				Birth_date = (reader[nameof(Student.Birth_date)] is DBNull) ? null : DateOnly.FromDateTime((DateTime)reader[nameof(Student.Birth_date)]),
				Login = (reader[nameof(Student.Login)] is DBNull) ? null : (string)reader[nameof(Student.Login)],
				Year_result = (reader[nameof(Student.Year_result)] is DBNull) ? null : (int)reader[nameof(Student.Year_result)],
				Course_id = (string)reader[nameof(Student.Course_id)],
				Section_id = (reader[nameof(Student.Section_id)] is DBNull) ? null : (int)reader[nameof(Student.Section_id)],
			};
		}
	}
}
