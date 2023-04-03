using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace CoreBlog.Models
{
	public class Cities
	{
		public string Sehir { get; set; }
		public IList<SelectListItem> Sehirler { get; set; }
	}
}
