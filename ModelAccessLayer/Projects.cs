using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAccessLayer
{
	public class Projects
	{
		[Key]
		public int? Projectid { get; set; }
		public string? ProjectName { get; set; }
		public string? Status { get; set; }
		public DateTime? StartDate { get; set; }
		public DateTime? EndDate { get;set; }


	}
}
