using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASP_MVC.Models.Section
{
	public class SectionEdit
	{
		[DisplayName("Section ID")]
		public int Section_Id { get; set; }

		[DisplayName("Section Name")]
		public string? Section_Name { get; set; }

		[ScaffoldColumn(false)]
		public int? Delegate_Id { get; set; }

		[DisplayName("Delegate Name")]
		public string? Delegate_Name { get; set; } 
	}
}
