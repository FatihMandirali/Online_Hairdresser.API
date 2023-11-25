using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Online_Hairdresser.API.Localize;
using Online_Hairdresser.Core.Attributes;
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

        public OnboardingController(IOnBoardingService onboardingService)
        {
            _onboardingService = onboardingService;
        }

        /// <summary>
        /// OnBoarding List Service...
        /// </summary>
        /// <returns></returns>
        [HttpGet("List")]
        //[Cached]
        public async Task<BaseResponse<List<OnboardingResponse>>> GetOnboardingList()
        {
            var baseUri = $"{Request.Scheme}://{Request.Host}/";
            var response = await _onboardingService.OnBoardingList(baseUri);
            return new BaseResponse<List<OnboardingResponse>>(ProcessStatusEnum.Success, null, response);
        }
    }
}
