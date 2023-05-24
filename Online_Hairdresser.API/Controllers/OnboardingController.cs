using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Online_Hairdresser.API.Localize;
using Online_Hairdresser.Core.IServices;
using Online_Hairdresser.Models.Enums;
using Online_Hairdresser.Models.Models.BaseModel;
using Online_Hairdresser.Models.Models.Response.Onboarding;

namespace Online_Hairdresser.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OnboardingController : BaseController
    {
        private readonly IOnBoardingService _onboardingService;
        private readonly IStringLocalizer<Resource> _localizer;
        private readonly ILogger<OnboardingController> _logger;

        public OnboardingController(IOnBoardingService onboardingService, IStringLocalizer<Resource> localizer, ILogger<OnboardingController> logger)
        {
            _onboardingService = onboardingService;
            _localizer = localizer;
            _logger = logger;
        }

        /// <summary>
        /// OnBoarding List Service...
        /// </summary>
        /// <returns></returns>
        [HttpGet("List")]
        //[Cached]
        public async Task<BaseResponse<List<OnboardingResponse>>> GetOnboardingList()
        {
            _logger.LogInformation("onboarding servicess");
            _logger.LogError("onboarding servicess errrorrr");
            var response = await _onboardingService.OnBoardingList();
            return new BaseResponse<List<OnboardingResponse>>(ProcessStatusEnum.Success, null, response);
        }
    }
}
