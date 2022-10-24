using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Online_Hairdresser.API.Localize;
using Online_Hairdresser.Core.IServices.AdminPanel;
using Online_Hairdresser.Models.Enums;
using Online_Hairdresser.Models.Models.BaseModel;
using Online_Hairdresser.Models.Models.Response.Login;

namespace Online_Hairdresser.API.Controllers.AdminPanel
{
    [Route("{culture:culture}/api/[controller]")]
    [ApiController]
    public class LoginController : BaseController
    {
        private readonly IStringLocalizer<Resource> _localizer;
        private readonly ILoginService _loginService;

        public LoginController(IStringLocalizer<Resource> localizer, ILoginService loginService)
        {
            _localizer = localizer;
            _loginService = loginService;
        }
        /// <summary>
        /// Panel Login service
        /// </summary>
        /// <param name="postLogin"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<BaseResponse<object>> PostLogin([FromBody] LoginRequest postLogin)
        {
            var response = await _loginService.Login(postLogin);
            return new BaseResponse<object>(ProcessStatusEnum.Success, null, response.Item1);
        }

    }
}
