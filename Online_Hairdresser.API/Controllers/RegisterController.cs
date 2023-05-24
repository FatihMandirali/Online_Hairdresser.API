using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Online_Hairdresser.API.Localize;
using Online_Hairdresser.Core.IServices;
using Online_Hairdresser.Models.Models.BaseModel;
using Online_Hairdresser.Models.Models.Request.UserRegister;

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
    public async Task<BaseResponse<object>> RegisterUser([FromBody] UserRegisterRequest userRegisterRequest)
    {
        await _registerService.RegisterUser(userRegisterRequest);
        return new BaseResponse<object>();
    }
}