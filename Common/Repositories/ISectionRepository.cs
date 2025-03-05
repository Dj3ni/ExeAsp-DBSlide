using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repositories
{
	public interface ISectionRepository <TSection> : ICRUDRepository<TSection, int>
	{
	}
}
