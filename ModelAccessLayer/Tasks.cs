using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAccessLayer
{
	public class Tasks
	{
		[Key]
		public string? Empid {  get; set; }
		public string? AssignedEmpName { get; set; }
		public string? ProjectName {  get; set; }
		public string? ProjectId { get; set; }
		public string? TaskTittle { get; set; }
		public string? Description { get; set; }
		public DateTime? StartDate { get; set; }	
		public DateTime? EndDate { get; set; }
		public string? Status { get; set; }


	}
}
