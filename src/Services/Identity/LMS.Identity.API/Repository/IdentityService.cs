using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LMS.Identity.API.Entities;
using LMS.Identity.API.Interfaces;
using LMS.Identity.API.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace LMS.Identity.API.Repository 
{
	public class IdentityService : IIdentity 
	{
		private readonly IdentityDbContext _context;
		private readonly IConfiguration _configuration;


		public IdentityService(IdentityDbContext context, IConfiguration configuration)
		{
			_context = context;
			_configuration = configuration;
		}

		public async Task<User?> GetByIdAsync(int id)
		{
			return await _context.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
		}

		public async Task<string> AddUser(User user)
		{
			var users = await GetAllUsersAsync(CancellationToken.None);

			if(users.Exists(s => s.Email == user.Email))
			{
				return "User with this email already exists";
			};
			var addedUser = _context.Users.Add(user);
			await _context.SaveChangesAsync();
			return "";
			//return addedUser.Id;
		}

		public async Task<List<User>> GetAllUsersAsync(CancellationToken cancellationToken)
		{
			return await _context.Users.ToListAsync(cancellationToken);
		}

		// public async Task<string> Login(LoginRequest loginRequest)
		// {
		// 	try
		// 	{
		// 		if(string.IsNullOrEmpty(loginRequest.Email) || string.IsNullOrEmpty(loginRequest.Password))
		// 		{
		// 			throw new Exception("Credentials are not valid");
		// 		}

		// 		var user = await _context.Users
		// 			.FirstOrDefaultAsync(s => s.Email == loginRequest.Email && s.Password == loginRequest.Password);

		// 		if(user == null)
		// 		{
		// 			throw new Exception("User is not valid");
		// 		}

		// 		var claims = new List<Claim>
		// 		{
		// 			new Claim(JwtRegisteredClaimNames.Sub, _configuration.GetSection("Jwt:Subject").Value ?? string.Empty),
		// 			new Claim("Id", user.Id.ToString()),
		// 			new Claim("UserName", user.Name)
		// 		};

		// 		var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:Key").Value ?? string.Empty));
		// 		var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

		// 		var token = new JwtSecurityToken(
		// 			_configuration.GetSection("Jwt:Subject").Value,
		// 			_configuration.GetSection("Jwt:Key").Value,
		// 			claims,
		// 			expires: DateTime.UtcNow.AddMinutes(60),
		// 			signingCredentials: signIn
		// 		);

		// 		var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
		// 		return jwtToken;
		// 	}
		// 	catch(Exception ex)
		// 	{
		// 		return ex.Message;
		// 	}
		// }

		//public async Task DeleteAsync(Guid id)
		//{
		//	var ans = await _context.Users.Where(x => x.Id == id).FirstOrDefaultAsync();

		//	if(ans is not null)
		//	{
		//		_context.Users.Remove(ans);
		//		await _context.SaveChangesAsync();
		//	}
		//	else
		//	{
		//		throw new Exception("Not Found");
		//	}
		//}

		public async Task<User> UpdateAsync(User user)
		{
			_context.Users.Update(user);
			await _context.SaveChangesAsync();
			return user;
		}
	}
}
