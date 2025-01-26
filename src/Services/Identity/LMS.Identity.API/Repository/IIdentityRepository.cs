using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Identity.API.Repository
{
    public interface IIdentityRepository
    {
        Task<string?> LoginUser(string email, string password, CancellationToken cancellationToken);
    }
}