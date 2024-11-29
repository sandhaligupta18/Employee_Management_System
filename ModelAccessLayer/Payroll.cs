using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAccessLayer
{
	public class Payroll
	{
		[Key]
		public string? Empid {  get; set; }
		public string? EmpName { get; set; }
		public int? Salary {  get; set; }
		[Display(Name ="Working hrs")]
		public int? WorkingHours { get; set; }
		public string? Month { get; set; }
		public int? Loan { get; set; }
		public int? Deduction { get; set; }
		public int? TotalPaid { get; set; }
		public int? Pending { get; set; }
		public string? Status {  get; set; }
		public DateTime? PayDate { get; set; }
		public string? PaidType { get; set; }
	}
}
