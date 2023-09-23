using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Identity.Core;
using evdekinisatcom.MvcWebApp.DataAccess.Data;
using evdekinisatcom.MvcWebApp.DataAccess.Identity.Models;


namespace evdekinisatcom.MvcWebApp_App.Service.Extensions
{
	public static class StartExtensions
    {
        public static void AddIdentityExtensions(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, AppRole>(
                opt =>
                {
                    opt.Password.RequireNonAlphanumeric = false;
                    opt.Password.RequiredLength = 3;
                    opt.Password.RequireLowercase = false;
                    opt.Password.RequireUppercase = false;
                    opt.Password.RequireDigit = false;


                    opt.User.RequireUniqueEmail = true;
                    opt.Lockout.MaxFailedAccessAttempts = 3; //defaultu 5
                    opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1); //default 5
                }).AddEntityFrameworkStores<AppDbContext>();

            services.ConfigureApplicationCookie(opt =>
            {
                opt.LoginPath = new PathString("/Account/Login");
                opt.LogoutPath = new PathString("/Account/Logout");
                opt.ExpireTimeSpan = TimeSpan.FromMinutes(1);
                opt.SlidingExpiration = true; //10dk dolmadan kullanıcı login olursa süre baştan başlar
                opt.Cookie = new CookieBuilder()
                {
                    Name = "Project1.App.Cookie",

                    HttpOnly = true,
                };
            });
        }
    }
}
