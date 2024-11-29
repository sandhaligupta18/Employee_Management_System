using Microsoft.Extensions.Options;
using DataAccessLayer.ApplicationDb_Context;
using Microsoft.EntityFrameworkCore;
using ModelAccessLayer;
using Microsoft.AspNetCore.Identity;
using BussinessAccessLayer.Abstract;
using BussinessAccessLayer.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDb_Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
	.AddEntityFrameworkStores<AppDb_Context>()
	.AddDefaultTokenProviders();

builder.Services.AddScoped<IAccountServices, AccountServices>();
builder.Services.AddScoped<IEmployeeServices, EmployeeServices>();
builder.Services.AddScoped<IDepartmentServices, DepartmentServices>();
builder.Services.AddScoped<IDesignationServices,DesignationServices>();
builder.Services.AddScoped<IAttendanceServices, AttendanceServices>();
builder.Services.AddScoped<IHolidaysServices, HolidaysServices>();
builder.Services.AddScoped<ILeavesServices, LeavesServices>();
builder.Services.AddScoped<INoticeServices, NoticeServices>();
builder.Services.AddScoped<IPayRollServices, PayrollServices>();
builder.Services.AddScoped<IProjectServices, ProjectServices>();
builder.Services.AddScoped<ITaskServices, TaskServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Task}/{action=AddTask}/{id?}");

app.Run();
