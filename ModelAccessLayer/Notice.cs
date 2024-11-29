using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAccessLayer
{
	public class Notice
	{
		[Key]
		public int? id {  get; set; }
		public string? Title {  get; set; }
		public string? Description { get; set; }
		public DateTime? CreatedDate { get; set; }

	}
}
