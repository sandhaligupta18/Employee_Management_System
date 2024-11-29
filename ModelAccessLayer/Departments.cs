using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAccessLayer
{
	public class Departments
	{
		[Key]
		public int? id {  get; set; }
		[Display(Name = "Department Name ")]
		public string? DepartmentName {  get; set; }
	}
}
