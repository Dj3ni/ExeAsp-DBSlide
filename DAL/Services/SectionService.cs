using Common.Repositories;
using DAL.Entities;
using DAL.Mapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
	public class SectionService : BaseService, ISectionRepository<Section>
	{
		public SectionService(IConfiguration config) : base(config, "DB-Slide"){ }

		
		public IEnumerable<Section> GetAll()
		{
			using(SqlConnection connection = new SqlConnection(_connectionString))
			{
				using(SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "Select * from Section" ;
					command.CommandType = CommandType.Text;
					connection.Open();
					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							yield return reader.ToSection();
						}
					}
				}
			}
		}

		public Section GetById(int id)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "Select * from Section where section_id = @section_id";
					command.CommandType = CommandType.Text;
					command.Parameters.AddWithValue("section_id", id);
					connection.Open();

					using(SqlDataReader reader = command.ExecuteReader())
					{
						if (reader.Read())
						{
							return reader.ToSection();
						}
						throw new ArgumentOutOfRangeException(nameof(id));
					}
				}
			}
		}

		public int Insert(Section section)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "Insert Into Section (section_id,section_name, delegate_id) output Inserted.section_id Values(@section_id,@section_name, @delegate_id)";
					command.CommandType = CommandType.Text;
					command.Parameters.AddWithValue(nameof(Section.Section_Id), section.Section_Id);
					command.Parameters.AddWithValue(nameof(Section.Section_Name), section.Section_Name);
					command.Parameters.AddWithValue(nameof(Section.Delegate_id), (section.Delegate_id is null) ? DBNull.Value : section.Delegate_id);

					connection.Open();
					return (int)command.ExecuteScalar();
				}
			}
		}

		public void Update(int id, Section section)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				using (SqlCommand command = connection.CreateCommand())
				{
					command.CommandText = "Update Section Set section_id = @section_id, section_name = @section_name, delegate_id = @delegate_id where section_id = @section_id" ;
					command.CommandType = CommandType.Text;
					command.Parameters.AddWithValue(nameof(Section.Section_Id), id);
					command.Parameters.AddWithValue(nameof(Section.Section_Name), (section.Section_Name is null)? DBNull.Value : section.Section_Name);
					command.Parameters.AddWithValue(nameof(Section.Delegate_id), (section.Delegate_id is null)? DBNull.Value : section.Delegate_id);
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
					command.CommandText = "Delete From Section Where section_id = @section_id" ;
					command.CommandType = CommandType.Text;
					command.Parameters.AddWithValue(nameof (Section.Section_Id), id);
					connection.Open();
					command.ExecuteNonQuery();
				}
			}
		}
	}
}
