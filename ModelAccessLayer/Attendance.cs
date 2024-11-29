using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAccessLayer
{
	public class Attendance
	{
		[Key]
		public string? Empid {  get; set; }
		[Display(Name ="Employee Name")]
		public string? EmpName { get; set; }
		public DateTime? SignIn {  get; set; }
		public DateTime? SignOut { get; set; }
		[Display(Name ="Working Hours")]
		public decimal? WorkingHours { get; set; }


	}
}
