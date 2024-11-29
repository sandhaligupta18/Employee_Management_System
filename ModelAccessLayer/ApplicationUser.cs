using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAccessLayer
{
	public class ApplicationUser:IdentityUser
	{
		[NotNull]
		public string? Empid {  get; set; }	
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public string? RegisterAs { get; set; }


	}
}
