using BLL.Entities;
using BLL.Mapper;
using Common.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
	public class StudentService : IStudentRepository<Student>
	{
		//Service injection
		private readonly IStudentRepository<DAL.Entities.Student> _studentService;

		public StudentService(IStudentRepository<DAL.Entities.Student> studentService)
		{
			_studentService = studentService;
		}

		public IEnumerable<Student> GetAll()
		{
			IEnumerable<Student> student = _studentService.GetAll().Select(dal=>dal.ToBLL());
			return student;
		}

		public Student GetById(int id)
		{
			Student student = _studentService.GetById(id).ToBLL();
			return student;
		}

		public int Insert(Student student)
		{
			return _studentService.Insert(student.ToDAL());
		}

		public void Update(int id, Student student)
		{
			_studentService.Update(id, student.ToDAL());
		}


		public void Delete(int id)
		{
			_studentService.Delete(id);
		}
	}
}
