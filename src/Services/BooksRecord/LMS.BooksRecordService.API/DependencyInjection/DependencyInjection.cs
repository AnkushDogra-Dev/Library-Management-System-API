using System.Reflection;
using LMS.BooksRecordService.API.Mappings;
using LMS.BooksRecordService.API.Persistance;
using LMS.BooksRecordService.API.Repository;
using Microsoft.EntityFrameworkCore;

namespace LMS.BooksRecordService.API.DependencyInjection
{
	public static class DependencyInjection
	{
		//Extension method to register services in DI Container.
		public static IServiceCollection AddBooksService(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddSingleton<IConfiguration>(configuration);

			services.AddDbContext<BooksDbContext>(options =>
				options.UseSqlServer(configuration.GetConnectionString("LMSDbConnectionString")
				?? throw new InvalidOperationException("Connection string 'LMSDbConnectionString' not found.")));

			services.AddScoped<BooksDbContext>();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

			services.AddAutoMapper(typeof(MappingProfile));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IBooksRepository, BooksRepository>();


			services.AddEndpointsApiExplorer();
			services.AddControllers();
			services.AddControllers().AddApplicationPart(typeof(LMS.BooksRecordService.API.Controllers.BooksController).Assembly);

			return services;
		}

		public static async Task<IApplicationBuilder> UseBooksService(this IApplicationBuilder app)
		{
			app.UseHttpsRedirection();
			return app;
		}
	}
}
//}

