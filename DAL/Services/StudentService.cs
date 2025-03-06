using DAL.Mapper;
using Common.Repositories;
using DAL.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL.Services
{
	public class StudentService : BaseService, IStudentRepository<Student>
	{
		public StudentService(IConfiguration config) : base(config, "DB-Slide"){ }

		
		public IEnumerable<Student> GetAll()
		{
			using(SqlConnection connection = new SqlConnection(_connectionString))
			{
				using(SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "Select * from Student Order By Year_Result DESC";
					command.CommandType = System.Data.CommandType.Text;
					connection.Open();
					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							yield return reader.ToStudent();
						}
					}
				}
			}
		}

		public Student GetById(int id)
		{
			using(SqlConnection connection = new SqlConnection(_connectionString))
			{
				using(SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "Select * from Student where student_id = @student_id";
					command.CommandType = CommandType.Text;
					command.Parameters.AddWithValue("student_id", id);
					connection.Open();
					using (SqlDataReader reader = command.ExecuteReader())
					{
						if (reader.Read())
						{
							return reader.ToStudent();
						}
						throw new ArgumentOutOfRangeException(nameof(reader));
					}
				}
			}
		}

		public int Insert(Student student)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "Insert INTO Student (first_name,last_name,birth_date,login,section_id,year_result,course_id) output Inserted.student_id Values (@first_name,@last_name,@birth_date,@login,@section_id,@year_result,@course_id)";
					command.CommandType = System.Data.CommandType.Text;
					//Parameters
					command.Parameters.AddWithValue("first_name", (student.First_name is null)? DBNull.Value : student.First_name);
					command.Parameters.AddWithValue("last_name", (student.Last_name is null)? DBNull.Value : student.Last_name);
					command.Parameters.AddWithValue("birth_date", (student.Birth_date is null)? DBNull.Value : student.Birth_date);
					command.Parameters.AddWithValue("login", (student.Login is null)? DBNull.Value : student.Login);
					command.Parameters.AddWithValue("section_id", (student.Section_id is null)? DBNull.Value : student.Section_id);
					command.Parameters.AddWithValue("year_result", (student.Year_result is null)? DBNull.Value : student.Year_result);
					command.Parameters.AddWithValue("course_id", student.Course_id);

					connection.Open();
					return (int)command.ExecuteScalar();
					

				}
			}
		}

		public void Update(int id, Student student)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = 
						"Update Student SET first_name = @first_name,last_name = @last_name, birth_date = @birth_date, login = @login, section_id = @section_id, year_result = @year_result, course_id = @course_id Where student_id = @student_id";
					command.CommandType = System.Data.CommandType.Text;
					//Parameters
					command.Parameters.AddWithValue("student_id", id);
					command.Parameters.AddWithValue("first_name", (student.First_name is null) ? DBNull.Value : student.First_name);
					command.Parameters.AddWithValue("last_name", (student.Last_name is null) ? DBNull.Value : student.Last_name);
					command.Parameters.AddWithValue("birth_date", (student.Birth_date is null) ? DBNull.Value : student.Birth_date);
					command.Parameters.AddWithValue("login", (student.Login is null) ? DBNull.Value : student.Login);
					command.Parameters.AddWithValue("section_id", (student.Section_id is null) ? DBNull.Value : student.Section_id);
					command.Parameters.AddWithValue("year_result", (student.Year_result is null) ? DBNull.Value : student.Year_result);
					command.Parameters.AddWithValue("course_id", student.Course_id);

					connection.Open();
					command.ExecuteNonQuery();

				}
			}
		}

		public void Delete(int id)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "Delete From Student Where student_id = @student_id";
					command.CommandType = System.Data.CommandType.Text;
					//Parameters
					command.Parameters.AddWithValue("student_id", id);

					connection.Open();
					command.ExecuteNonQuery();

				}
			}
		}
	}
	
}
