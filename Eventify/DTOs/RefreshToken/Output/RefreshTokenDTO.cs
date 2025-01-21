namespace Eventify.DTOs.RefreshToken.Output
{
    public class RefreshTokenDTO
    {
        public string accessToken { get; set; } = string.Empty;
        public string refreshToken { get; set; } = string.Empty;
    }
}
