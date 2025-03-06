using System.ComponentModel;

namespace ASP_MVC.Models.Section
{
	public class SectionCreate
	{

		[DisplayName("Section Id")]
		public int Section_id { get; set; }

		[DisplayName("Section Name")]
		public string? Section_Name { get; set; }
	
	}
}
