using LMS.Identity.API.Entities;

namespace LMS.Identity.API.Interfaces
{
    public interface IIdentity {
        Task<string> AddUser(User user);

        Task<List<User>> GetAllUsersAsync(CancellationToken cancellationToken = default);

        // Task<string> Login(LoginRequest loginRequest);

        Task<User?> GetByIdAsync(int id);

       // Task DeleteAsync(Guid id);

        Task<User> UpdateAsync(User user);
    }
}