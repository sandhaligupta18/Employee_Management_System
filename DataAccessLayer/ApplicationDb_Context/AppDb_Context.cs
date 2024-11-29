using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ModelAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ApplicationDb_Context
{
	public class AppDb_Context:IdentityDbContext<ApplicationUser,IdentityRole, string>
	{
      
		public AppDb_Context(DbContextOptions options):base(options) { }


		public DbSet<Attendance> Attendances { get; set; }
		public DbSet<Departments> Department { get; set; }
		public DbSet<Designation> Designation { get; set; }
		public DbSet<EmployeeDetails> EmployeeDetail { get; set; }
		public DbSet<Holidays> Holiday { get; set; }
		public DbSet<Leaves> Leave { get; set; }
		public DbSet<Notice> Notice { get; set; }
		public DbSet<Payroll> Payroll { get; set; }
		public DbSet<Projects> Project { get; set; }
		public DbSet<Tasks>	Task { get; set; }
	}
}
