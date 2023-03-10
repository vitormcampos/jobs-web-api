using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Jobs.Core.Repositories.Users;

public class UserRepository : IUserRepository
{
    private readonly UserManager<IdentityUser> _userManager;

    public UserRepository(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }
    
    public async Task<bool> ExistsById(string id)
    {
        var user = await _userManager.Users.AnyAsync(u => u.Id == id);
        return user;
    }

    public async Task<IdentityUser?> FindById(string id)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == id);
        return user;
    }

    public async Task<ICollection<IdentityUser>> FindAll()
    {
        var users = await _userManager.Users.ToListAsync();
        return users;
    }

    Task<IdentityUser> ICrudRepository<IdentityUser, string>.Create(IdentityUser model)
    {
        throw new NotImplementedException();
    }

    public async Task<IdentityUser> Create(IdentityUser model, string password)
    {
        var result = await _userManager.CreateAsync(model, password);
        if (!result.Succeeded) return null;
        
        var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
        return user;
    }

    public async Task<IdentityUser> ChangePassword(IdentityUser user, string currentPassword, string newPassword)
    {
        var result = await _userManager.ChangePasswordAsync(
            user,
            currentPassword,
            newPassword
        );
        
        if (!result.Succeeded) return null;
        
        user = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == user.Email);
        return user;
    }

    public async Task<IdentityUser> Update(IdentityUser model)
    {
        var result = await _userManager.UpdateAsync(model);
        if (!result.Succeeded) return null;
        
        var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
        return user;
    }

    public async Task DeleteById(string id)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == id);
        await _userManager.DeleteAsync(user);
    }
}