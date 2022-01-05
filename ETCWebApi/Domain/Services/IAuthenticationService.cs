using System.Threading.Tasks;
using ETCWebApi.Domain.Services.Communication;

namespace ETCWebApi.Domain.Services
{
    public interface IAuthenticationService
    {
         Task<TokenResponse> CreateAccessTokenAsync(string email, string password);
         Task<TokenResponse> RefreshTokenAsync(string refreshToken, string userEmail);
         void RevokeRefreshToken(string refreshToken);
    }
}