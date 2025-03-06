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

		/// <summary>
		/// Convert BLL Section to a SectionListItem object
		/// </summary>
		/// <param name="section">BLL Section</param>
		/// <returns>SectionListItem</returns>
		/// <exception cref="ArgumentNullException"></exception>
		public static SectionListItem ToListItem(this Section section)
		{
			if (section is null) throw new ArgumentNullException(nameof(section));
			return new SectionListItem()
			{
				Section_id = section.Section_Id,
				Section_name = section.Section_Name,
			};
		}

		/// <summary>
		/// Convert Data from SectionCreate form to a BLL Section
		/// </summary>
		/// <param name="form">SectionCreate</param>
		/// <returns>BLL Section</returns>
		/// <exception cref="ArgumentNullException"></exception>
		public static Section ToBLL(this SectionCreate form)
		{
			if(form is null) throw new ArgumentNullException(nameof(form));
			return new Section(
				form.Section_id,
				form.Section_Name,
				null
				);
		}

		/// <summary>
		/// Convert Section BLL To SectionEdit form data
		/// </summary>
		/// <param name="section">BLL Section</param>
		/// <returns>SectionEdit</returns>
		/// <exception cref="ArgumentNullException"></exception>
		public static SectionEdit ToEdit(this Section section)
		{
			if( section is null) throw new ArgumentNullException( nameof(section));
			return new SectionEdit()
			{
				Section_Id = section.Section_Id,
				Section_Name = section.Section_Name
			};
		}

		public static Section ToBLL(this SectionEdit form)
		{
			if( form is null) throw new ArgumentNullException(nameof (form));
			return new Section(
				form.Section_Id,
				form.Section_Name,
				form.Delegate_Id
				);
		}


		/// <summary>
		/// Convert BLL Section to SectionDelete form data
		/// </summary>
		/// <param name="section">BLL Section</param>
		/// <returns>SectionDelete</returns>
		/// <exception cref="ArgumentNullException"></exception>
		public static SectionDelete ToDeleteForm(this Section section)
		{
			if( section is null) throw new ArgumentNullException( nameof(section));
			return new SectionDelete()
			{
				Section_Id = section.Section_Id,
				Section_Name = section.Section_Name
			};
		}



	}
}
