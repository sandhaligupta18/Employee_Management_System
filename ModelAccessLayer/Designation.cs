using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAccessLayer
{
	public class Designation
	{
		[Key]
		public int? id {  get; set; }
		[Display(Name ="Designation Name")]
		public string? DesignationName {  get; set; }

	}
}
