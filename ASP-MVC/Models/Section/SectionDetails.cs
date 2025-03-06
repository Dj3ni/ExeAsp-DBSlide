using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASP_MVC.Models.Section
{
	public class SectionDetails
	{
		[ScaffoldColumn(false)]
		public int Section_Id { get; set; }

		[DisplayName("Name")]
		public string? Section_Name { get; set; }

		[DisplayName("Delegate")]
		public int? Delegate_Id { get; set; }

		//public string? Delegate_Name { get;set; }
	}
}
