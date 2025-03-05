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

		public int Insert(Student entity)
		{
			throw new NotImplementedException();
		}

		public void Update(int id, Student entity)
		{
			throw new NotImplementedException();
		}

		public void Delete(int id)
		{
			throw new NotImplementedException();
		}
	}
}
