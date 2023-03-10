using Microsoft.AspNetCore.Identity;

namespace Jobs.Api.Common.Services;

public interface ITokenService
{
    string GenerateToken(IdentityUser user);
}