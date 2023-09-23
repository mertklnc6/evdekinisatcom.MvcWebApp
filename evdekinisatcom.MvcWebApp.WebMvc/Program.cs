using Microsoft.EntityFrameworkCore;
using System.Reflection;
using evdekinisatcom.MvcWebApp.DataAccess.Data;
using evdekinisatcom.MvcWebApp.DataAccess.Repositories;
using evdekinisatcom.MvcWebApp_App.Entity.Interfaces;
using evdekinisatcom.MvcWebApp.DataAccess.Identity;
using evdekinisatcom.MvcWebApp_App.Service.Extensions;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnStr")));

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());



builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddIdentityExtensions();



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

app.UseAuthentication();    //kimlik denetimi
app.UseAuthorization();     //yetkilendirme

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
