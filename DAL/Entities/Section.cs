using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
	public class Section
	{
		public int Section_Id { get; set; }
		public string? Section_Name { get; set; }
		public int? Delegate_id { get; set; }
	}
}
