using System.Reflection;
using LMS.BorrowersRecord.API.Entities;
using LMS.BorrowersRecord.API.Persistance;
using LMS.BorrowersRecord.API.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace LMS.BorrowersRecord.API.DependencyInjection {
	public static class DependencyInjection {
		public static IServiceCollection AddBorrowersService(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddSingleton<IConfiguration>(configuration);

			services.AddDbContext<BorrowerDbContext>(options =>
				options.UseSqlServer(configuration.GetConnectionString("LMSDbConnectionString")
				?? throw new InvalidOperationException("Connection string 'LMSDbConnectionString' not found.")));

			services.AddScoped<BorrowerDbContext>();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

			services.AddEndpointsApiExplorer();

			//services.AddSingleton<IHostedService, DbInitializerService>();
			services.AddControllers().AddApplicationPart(typeof(LMS.BorrowersRecord.API.Controllers.BorrowersController).Assembly);
			services.AddScoped<IBorrowerRepository,BorrowerRepository>();
			return services;
		}

		public static async Task<IApplicationBuilder> UseBorrowersService(this IApplicationBuilder app)
		{
			return app;
		}
		}
	}
//}

