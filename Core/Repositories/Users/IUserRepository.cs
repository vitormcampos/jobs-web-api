using Microsoft.AspNetCore.Identity;

namespace Jobs.Core.Repositories.Users;

public interface IUserRepository : ICrudRepository<IdentityUser, string>
{
    Task<IdentityUser> Create(IdentityUser user, string password);
    Task<IdentityUser> ChangePassword(IdentityUser user, string currentPassword, string newPassword);
}