using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASP_MVC.Models.Section
{
	public class SectionListItem
	{
		//[ScaffoldColumn(false)]
		public int Section_id {  get; set; }

		[DisplayName("Section Name")]
		public string? Section_name { get; set; }
	}
}
