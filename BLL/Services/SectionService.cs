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

		public SectionService(ISectionRepository<DAL.Entities.Section> sectionService)
		{
			_sectionService = sectionService;
		}

		public IEnumerable<Section> GetAll()
		{
			return _sectionService.GetAll().Select(dal=>dal.ToBLL());
		}

		public Section GetById(int id)
		{
			return _sectionService.GetById(id).ToBLL();
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
