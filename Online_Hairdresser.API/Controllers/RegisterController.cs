using FM.Project.BaseLibrary.BaseResponseModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Localization;
using Online_Hairdresser.API.Localize;
using Online_Hairdresser.Core.IServices;
using Online_Hairdresser.Models.Models.Request.UserRegister;
using Online_Hairdresser.Models.Models.Response.Onboarding;

namespace Online_Hairdresser.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RegisterController:BaseController
{
    private readonly IStringLocalizer<Resource> _localizer;
    private readonly IRegisterService _registerService;
    private readonly ILogger<RegisterController> _logger;

    public RegisterController(IStringLocalizer<Resource> localizer, ILogger<RegisterController> logger, IRegisterService registerService)
    {
        _localizer = localizer;
        _logger = logger;
        _registerService = registerService;
    }
    
    [HttpPost("RegisterUser")]
    public async Task<FMBaseResponse<object>> RegisterUser([FromBody] UserRegisterRequest userRegisterRequest)
    {
        var response = await _registerService.RegisterUser(userRegisterRequest);
        if (!string.IsNullOrEmpty(response))
        {
            _logger.LogError($"register error {userRegisterRequest.Email}");
            return new FMBaseResponse<object>(FMProcessStatusEnum.InternalServerError, new FMFriendlyMessage("",_localizer[response]), null);
        }
        return new FMBaseResponse<object>(FMProcessStatusEnum.Success, null, null);
    }
}