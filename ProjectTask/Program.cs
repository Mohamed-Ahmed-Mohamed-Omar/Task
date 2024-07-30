using Hangfire;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectTask.Data;
using ProjectTask.Helpers;
using ProjectTask.Models.Mail;
using ProjectTask.Services.Interface;
using ProjectTask.Services.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// ConnectionStrings

builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("Defult"))
    );

// Auto Mapper
builder.Services.AddAutoMapper(m => m.AddProfile(new AutoMapperProfile()));

// Dependency Injection

builder.Services.AddTransient<IDepartmentRepo, DepartmentRepo>();

builder.Services.AddTransient<IFileRepo, FileRepo>();

builder.Services.AddTransient<ISubDepartmentRepo, SubDepartmentRepo>();

builder.Services.AddTransient<IMailRepo, MailRepo>();

// Adding Config For Required Email

builder.Services.Configure<IdentityOptions>(options => options.SignIn.RequireConfirmedEmail = true);

builder.Services.Configure<MailSetting>(builder.Configuration.GetSection("MailSetting"));

//Hangfire

builder.Services.AddHangfire(config => config.UseSqlServerStorage(builder.Configuration.GetConnectionString("Defult")));
builder.Services.AddHangfireServer();


builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseHangfireDashboard("/hangfire");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
