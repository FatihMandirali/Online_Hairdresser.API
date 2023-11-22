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
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Home Service...
        /// </summary>
        /// <returns></returns>
        [HttpGet("List")]
        public async Task<BaseResponse<object>> GetOnboardingList()
        {
            await Task.Delay(10000);
            return new BaseResponse<object>();
        }
    }
}
