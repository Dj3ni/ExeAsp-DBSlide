using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASP_MVC.Models.Section
{
	public class SectionEdit
	{
		[ScaffoldColumn(false)]
		public int Section_Id { get; set; }

		[DisplayName("Section Name")]
		public string Section_Name { get; set; }

		//public Student? Delegate { get; set; } 
	}
}
