using evdekinisatcom.MvcWebApp.DataAccess.Repositories;
using evdekinisatcom.MvcWebApp.DataAccess.UnitOfWorks;
using evdekinisatcom.MvcWebApp.Entity.Repositories;
using evdekinisatcom.MvcWebApp.Entity.UnitOfWorks;
using evdekinisatcom.MvcWebApp_App.Service.Mapping;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evdekinisatcom.MvcWebApp.Service.Extensions
{
	public static class DependencyExtensions
	{
		public static void AddExtensions(this IServiceCollection services)
		{
			services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
			services.AddScoped<IUnitOfWork, UnitOfWork>();
			



			services.AddAutoMapper(typeof(MappingProfile));
		}
	}
}
