using Personal.Domain.Models;

namespace Personal.Domain.Services.Jwt
{
    public interface IJwtBuilder
    {
        string GenerateJwtToken(string email, ApplicationIdentityUser user);
    }
}