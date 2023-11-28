using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Online_Hairdresser.API.Localize;
using Online_Hairdresser.Core.Helpers.JWT;
using Online_Hairdresser.Core.IServices;
using Online_Hairdresser.Models.Enums;
using Online_Hairdresser.Models.Models.BaseModel;
using Online_Hairdresser.Models.Models.Request.Login;

namespace Online_Hairdresser.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : BaseController
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }
        /// <summary>
        /// Panel Login service
        /// </summary>
        /// <param name="postLogin"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<BaseResponse<AccessToken>> PostLogin([FromBody] LoginRequest postLogin)
        {
            var response = await _loginService.Login(postLogin);
            return new BaseResponse<AccessToken>(ProcessStatusEnum.Success, null, response);
        }
        
        /// <summary>
        /// General Login service
        /// </summary>
        /// <param name="postLogin"></param>
        /// <returns></returns>
        [HttpPost("GeneralLogin")]
        public async Task<BaseResponse<AccessToken>> GeneralLogin()
        {
            var response = await _loginService.GeneralLogin();
            return new BaseResponse<AccessToken>(ProcessStatusEnum.Success, null, response);
        }
        
        [HttpPost("RefreshToken")]
        public async Task<BaseResponse<AccessToken>> RefreshToken([FromBody] RefreshTokenRequest refreshToken)
        {
            var response = await _loginService.RefreshToken(refreshToken);
            return new BaseResponse<AccessToken>(ProcessStatusEnum.Success, null, response);
        }
        
        [HttpPost("GeneralRefreshToken")]
        public async Task<BaseResponse<AccessToken>> GeneralRefreshToken([FromBody] RefreshTokenRequest refreshToken)
        {
            var response = await _loginService.GeneralRefreshToken(refreshToken);
            return new BaseResponse<AccessToken>(ProcessStatusEnum.Success, null, response);
        }

    }
}
