using System.Reflection;
using LMS.Identity.API.Entities;
using LMS.Identity.API.Persistance;
using LMS.Identity.API.Repository;
using Microsoft.EntityFrameworkCore;

namespace LMS.Identity.API.DependencyInjection
{
	public static class DependencyInjection
	{
		//Extension method to register services in DI Container.
		public static IServiceCollection AddIdentityService(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<IdentityDbContext>(options =>
				options.UseSqlServer(configuration.GetConnectionString("LMSDbConnectionString")
				?? throw new InvalidOperationException("Connection string 'LMSDbConnectionString' not found.")));

			services.AddScoped<IdentityDbContext>();
			services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
			services.AddEndpointsApiExplorer();

			services.AddControllers();
			services.AddControllers().AddApplicationPart(typeof(LMS.Identity.API.Controllers.IdentityController).Assembly);

			services.AddScoped<IIdentityRepository, IdentityRepository>();


			return services;
		}

		public static async Task<IApplicationBuilder> UseIdentityServices(this IApplicationBuilder app)
		{
			using (var scope = app.ApplicationServices.CreateScope())
			{
				var context = scope.ServiceProvider.GetRequiredService<IdentityDbContext>();

				await CreateSuperAdminAssignRole(context);
			}

			return app;
		}

		// Create the user with Admin Role
		private static async Task CreateSuperAdminAssignRole(IdentityDbContext context)
		{
			var email = "test@test.com";
			if (!context.Users.Any(x => x.Email == email))
			{
				var user = new User(
					firstName: "Ankush",
					lastName: "Dogra",
					email: email,
					password: "Password123",
					phoneNumber: "7006698882",
					role: Role.Admin
				);

				await context.Users.AddAsync(user);
				await context.SaveChangesAsync();
			}
		}
	}
}

