using Microsoft.AspNetCore.Mvc;
using Online_Hairdresser.Core.IServices;
using Online_Hairdresser.Models.Models.BaseModel;
using Online_Hairdresser.Models.Models.Request.Public;
using Online_Hairdresser.Models.Models.Request.UserRegister;

namespace Online_Hairdresser.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PublicController:BaseController
{
    private readonly IPublicService _publicService;

    public PublicController(IPublicService publicService)
    {
        _publicService = publicService;
    }

    [HttpPost("CheckUpdate")]
    public async Task<BaseResponse<object>> RegisterUser([FromBody] CheckUpdateRequest checkUpdateRequest)
    {
        _publicService.CheckUpdate(checkUpdateRequest);
        return new BaseResponse<object>();//
    }
}