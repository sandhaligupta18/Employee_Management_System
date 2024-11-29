using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAccessLayer
{
	public class EmployeeDetails
	{
		[Key]
		public string? Empid { get; set; }
		[Display(Name ="Employee Name")]
		public string? EmpName { get; set; }
		public string? Department { get; set; }
		public string? Designation { get; set; }
		public string? Email { get; set; }
		public string? Gender { get; set; }
		public string? Contact { get; set; }
		public string? Address { get; set; }
		public DateTime HireDate { get; set; }
		public int? Salary { get; set; }
		public string? ProfilePicture { get; set; }



	}
}
