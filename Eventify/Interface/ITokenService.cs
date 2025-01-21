using Eventify.Models;
using System.Security.Claims;
namespace Eventify.Interface
{
    public interface ITokenService
    {

        string CreateToken(User user, string role);
        RefreshToken GenerateRefreshToken(User user);
    }
}
