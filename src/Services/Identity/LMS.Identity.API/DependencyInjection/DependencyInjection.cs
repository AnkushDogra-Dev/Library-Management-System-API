using System.Reflection;
using System.Text;
using LMS.Identity.API.Entities;
using LMS.Identity.API.Persistance;
using LMS.Identity.API.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace LMS.Identity.API.DependencyInjection
{
	public static class DependencyInjection
	{
		//Extension method to register services in DI Container.
		public static IServiceCollection AddIdentityService(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddSingleton<IConfiguration>(configuration);

			services.AddDbContext<IdentityDbContext>(options =>
				options.UseSqlServer(configuration.GetConnectionString("LMSDbConnectionString")
				?? throw new InvalidOperationException("Connection string 'LMSDbConnectionString' not found.")));

			services.AddScoped<IdentityDbContext>();
			services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
			services.AddEndpointsApiExplorer();


			services.AddControllers();
			services.AddControllers().AddApplicationPart(typeof(LMS.Identity.API.Controllers.IdentityController).Assembly);

			services.AddScoped<IIdentityRepository, IdentityRepository>();

			services.AddAuthorizationBuilder()
			.AddPolicy(nameof(Role.Librarian), policy => policy.RequireRole(nameof(Role.Admin), nameof(Role.Librarian)))
			.AddPolicy(nameof(Role.Admin), policy => policy.RequireRole(nameof(Role.Admin)));

			services.AddAuthentication(options =>
						{
							options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
							options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
						})
						.AddJwtBearer(options =>
						{
							options.TokenValidationParameters = new TokenValidationParameters
							{
								ValidateIssuer = true,
								ValidateAudience = true,
								ValidateLifetime = true,
								ValidateIssuerSigningKey = true,
								ValidIssuer = configuration["Jwt:Issuer"],
								ValidAudience = configuration["Jwt:Audience"],
								IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"] ?? "ZGV2ZWxvcG1lbnRlc3QxMjM0NTY3ODkwYWJjZGVmZw=="))
							};
						});


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

