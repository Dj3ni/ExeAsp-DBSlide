using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
	public class Section
	{
	
		public int Section_Id { get; set; }
		public string? Section_Name { get; set; }
		public int? Delegate_id { get; set; }

		public string? Delegate_Name { get; set; }

		public Section(int section_Id, string? section_Name, int? delegate_id)
		{
			Section_Id = section_Id;
			Section_Name = section_Name;
			Delegate_id = delegate_id;
		}

	}
}
