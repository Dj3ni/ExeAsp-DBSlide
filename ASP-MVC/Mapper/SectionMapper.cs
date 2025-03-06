using ASP_MVC.Models.Section;
using BLL.Entities;

namespace ASP_MVC.Mapper
{
	internal static class SectionMapper
	{
		/// <summary>
		/// Convert BLL Section to a SectionDetail object
		/// </summary>
		/// <param name="section">BLL Section</param>
		/// <returns>SectionDetail object</returns>
		/// <exception cref="ArgumentNullException"></exception>
		public static SectionDetails ToDetails(this Section section)
		{
			if(section is null) throw new ArgumentNullException(nameof(section));
			return new SectionDetails()
			{
				Section_Id = section.Section_Id,
				Section_Name = section.Section_Name,
				Delegate_Id = section.Delegate_id,
				//Delegate_Name = section.Delegate_name
			};
		}

		public static SectionListItem ToListItem(this Section section)
		{
			if (section is null) throw new ArgumentNullException(nameof(section));
			return new SectionListItem()
			{
				Section_id = section.Section_Id,
				Section_name = section.Section_Name,
			};
		}


	}
}
