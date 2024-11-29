using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAccessLayer
{
	public class Leaves
	{
		[Key]
		public string? Empid {  get; set; }
		public string? EmpName { get; set; }
		[Display(Name ="Leave Type")]
		public string? LeaveType {  get; set; }
		[Display(Name ="Number of Days")]
		public int? NoofDays { get; set; }
		public DateTime? ApplyDate { get; set; }
		public DateTime? StartDate { get; set; }
		public DateTime? EndDate { get;set; }
		public string? LeaveStatus {  get; set; }

	}
}
