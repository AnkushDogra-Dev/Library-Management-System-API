using LMS.Identity.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace LMS.Identity.API.Persistance {
	public class IdentityDbContext(DbContextOptions<IdentityDbContext> options) : DbContext(options)
	{
		private const string _IdSchema = "id";

		public DbSet<User> Users { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.HasDefaultSchema(_IdSchema);
		}
	}
}
	