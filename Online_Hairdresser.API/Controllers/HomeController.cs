using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Online_Hairdresser.API.Localize;
using Online_Hairdresser.Core.Attributes;
using Online_Hairdresser.Core.IServices;
using Online_Hairdresser.Models.Enums;
using Online_Hairdresser.Models.Models.BaseModel;
using Online_Hairdresser.Models.Models.Request.Venue;
using Online_Hairdresser.Models.Models.Response.Onboarding;
using Online_Hairdresser.Models.Models.Response.Venue;

namespace Online_Hairdresser.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : BaseController
    {
        private readonly IVenueService _venueService;
        public HomeController(IVenueService venueService)
        {
            _venueService = venueService;
        }

        /// <summary>
        /// Home Service...
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetVenueList")]
        public async Task<BaseResponse<PaginatedList<VenueResponse>>> GetVenueList([FromQuery] VenueListRequest request)
        {
            var baseUri = $"{Request.Scheme}://{Request.Host}/";
            var response = await _venueService.GetVenueList(request,baseUri);
            return new BaseResponse<PaginatedList<VenueResponse>>(ProcessStatusEnum.Success, null, response);
        }
    }
}
