using Microsoft.EntityFrameworkCore;
using Online_Hairdresser.Core.Helpers.JWT;
using Online_Hairdresser.Core.IServices;
using Online_Hairdresser.Models.Exceptions;
using Online_Hairdresser.Models.Models.Request.Login;
using BC = BCrypt.Net.BCrypt;

namespace Online_Hairdresser.Core.Services
{
    public class LoginService : ILoginService
    {
        private readonly ITokenHelper _tokenHelper;
        private readonly IUserService _userService;
        private readonly IRefreshTokenService _refreshTokenService;

        public LoginService(ITokenHelper tokenHelper, IUserService userService, IRefreshTokenService refreshTokenService)
        {
            _tokenHelper = tokenHelper;
            _userService = userService;
            _refreshTokenService = refreshTokenService;
        }

        public async Task<AccessToken> Login(LoginRequest request)
        {
            var user = await _userService.FindUserByEmailRole(request.Email);
            if (user == null)
                throw new ErrorException("login_error");
            var isValidPassword = BC.Verify(request.Password,user.Password);
            if(!isValidPassword)
                throw new ErrorException("login_error");

            var token = _tokenHelper.CreateToken(user.Role, user.Id);
            await _refreshTokenService.Create(new RefreshTokenMongoRequest
            {
                RefreshExpDate = token.RefreshExpirationDate,
                RefreshToken = token.RefreshToken??"",
                UserId = user.Id
            });
            return token;
        }
        public async Task<AccessToken> RefreshToken(RefreshTokenRequest request)
        {
            var principal = _tokenHelper.GetPrincipalFromExpiredToken(request.Token);
            if (principal == null)
                throw new ErrorException("bad_request");
            
            var userId = Convert.ToInt32(principal.Claims.First(c => c.Type == "Id").Value);

            var refreshToken = await _refreshTokenService.GetAsync(request.RefreshToken);
            if(refreshToken is null)
                throw new ErrorException("not_found");

            var user = await _userService.FindBy(x => x.Id == userId).AsNoTracking().FirstOrDefaultAsync();
            if (user is null)
                throw new ErrorException("not_found");
            
            var token = _tokenHelper.CreateToken(user.Role, user.Id);
            await _refreshTokenService.Create(new RefreshTokenMongoRequest
            {
                RefreshExpDate = token.RefreshExpirationDate,
                RefreshToken = token.RefreshToken??"",
                UserId = user.Id
            });
            return token;
        }
    }
}
