using BLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mapper
{
	internal static class SectionMapper
	{
		/// <summary>
		/// Convert DAL Section to BLL Section
		/// </summary>
		/// <param name="section">DAL Section</param>
		/// <returns>BLL Section</returns>
		/// <exception cref="ArgumentNullException"></exception>
		public static Section ToBLL(this DAL.Entities.Section section)
		{
			if(section is null) throw new ArgumentNullException(nameof(section));
			return new Section(
				section.Section_Id,
				section.Section_Name,
				section.Delegate_id
				);
		}

		/// <summary>
		/// Convert BLL Section to DAL Section
		/// </summary>
		/// <param name="section">BLL Section</param>
		/// <returns>DAL Section</returns>
		/// <exception cref="ArgumentNullException"></exception>
		public static DAL.Entities.Section ToDAL(this Section section)
		{
			if(section is null) throw new ArgumentNullException( nameof(section));
			return new DAL.Entities.Section()
			{
				Section_Id = section.Section_Id,
				Section_Name = section.Section_Name,
				Delegate_id = section.Delegate_id
			};
		}

	}
}
