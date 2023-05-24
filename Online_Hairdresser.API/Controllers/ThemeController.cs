using Microsoft.AspNetCore.Mvc;
using Online_Hairdresser.Core.IServices;
using Online_Hairdresser.Models.Enums;
using Online_Hairdresser.Models.Models.BaseModel;
using Online_Hairdresser.Models.Models.Response.Theme;

namespace Online_Hairdresser.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ThemeController: BaseController
{
    private readonly IThemeService _themeService;
    private readonly ILogger<ThemeController> _logger;

    public ThemeController(IThemeService themeService, ILogger<ThemeController> logger)
    {
        _themeService = themeService;
        _logger = logger;
    }
    
    [HttpGet("List")]
    //[Cached]
    public async Task<BaseResponse<List<ThemeResponse>>> GetOnboardingList()
    {
        _logger.LogInformation("onboarding servicess");
        _logger.LogError("onboarding servicess errrorrr");
        var response = await _themeService.GetThemeList();
        return new BaseResponse<List<ThemeResponse>>(ProcessStatusEnum.Success, null, response);
    }
}