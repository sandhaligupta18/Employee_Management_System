using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAccessLayer
{
	public class ApplicationUserModel
	{
		[NotNull]
		public string? Empid { get; set; }
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public string? Email { get; set; }
		public string? RegisterAs { get; set; }
		public string? Password { get; set; }
		public string? ConfirmPassword { get; set; }


	}
}
