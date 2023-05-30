using Online_Hairdresser.Core.Helpers.JWT;
using Online_Hairdresser.Models.Models.Request.Login;

namespace Online_Hairdresser.Core.IServices
{
    public interface ILoginService
    {
        Task<AccessToken> Login(LoginRequest request);
        Task<AccessToken> RefreshToken(RefreshTokenRequest request);
    }
}
