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
	public class SectionService : ISectionRepository<Section>
	{
		private readonly ISectionRepository<DAL.Entities.Section> _sectionService;
		private readonly IStudentRepository<DAL.Entities.Student> _studentService;

		public SectionService(
			ISectionRepository<DAL.Entities.Section> sectionService,
			IStudentRepository<DAL.Entities.Student> studentService)
		{
			_sectionService = sectionService;
			_studentService = studentService;
		}

		public IEnumerable<Section> GetAll()
		{
			return _sectionService.GetAll().Select(dal=>dal.ToBLL());
		}

		public Section GetById(int id)
		{
			Section section = _sectionService.GetById(id).ToBLL();
			if (section.Delegate_id is null) section.Delegate_Name = "Ghost";
			else
			{
				Student student = _studentService.GetById((int)section.Delegate_id).ToBLL();
				section.Delegate_Name = $"{student.First_name} {student.Last_name}";
			}
			return section;
		}

		public int Insert(Section section)
		{
			return _sectionService.Insert(section.ToDAL());
		}

		public void Update(int id, Section section)
		{
			_sectionService.Update(id, section.ToDAL());
		}

		public void Delete(int id)
		{
			_sectionService.Delete(id);
		}
	}
}
