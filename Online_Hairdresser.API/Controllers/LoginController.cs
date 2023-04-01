using FM.Project.BaseLibrary.BaseResponseModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Online_Hairdresser.API.Localize;
using Online_Hairdresser.Core.IServices;
using Online_Hairdresser.Models.Enums;
using Online_Hairdresser.Models.Models.BaseModel;
using Online_Hairdresser.Models.Models.Response.Login;

namespace Online_Hairdresser.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : BaseController
    {
        private readonly IStringLocalizer<Resource> _localizer;
        private readonly ILogger<LoginController> _logger;
        private readonly ILoginService _loginService;

        public LoginController(IStringLocalizer<Resource> localizer, ILoginService loginService, ILogger<LoginController> logger)
        {
            _localizer = localizer;
            _loginService = loginService;
            _logger = logger;
        }
        /// <summary>
        /// Panel Login service
        /// </summary>
        /// <param name="postLogin"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<FMBaseResponse<object>> PostLogin([FromBody] LoginRequest postLogin)
        {
            _logger.LogError("login hata");
            var response = await _loginService.Login(postLogin);
            if(response.Item1 is null)
                return new FMBaseResponse<object>(FMProcessStatusEnum.InternalServerError, new FMFriendlyMessage("",_localizer[response.Item2]), null);

            return new FMBaseResponse<object>(FMProcessStatusEnum.Success, null, response.Item1);
        }

    }
}
