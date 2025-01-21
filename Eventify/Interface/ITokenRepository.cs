using Eventify.Models;

namespace Eventify.Interface
{
    public interface ITokenRepository
    {
        Task<RefreshToken> GetUserRefreshToken(User user);
        Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken);
        Task<RefreshToken> RemoveRefreshToken(RefreshToken refreshToken);
        Task<RefreshToken> GetRefreshTokenValue(string refreshTokenValue);
    }
}
