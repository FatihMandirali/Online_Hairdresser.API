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
        private readonly IUserFavoriteVenueService _userFavoriteVenueService;
        public HomeController(IVenueService venueService, IUserFavoriteVenueService userFavoriteVenueService)
        {
            _venueService = venueService;
            _userFavoriteVenueService = userFavoriteVenueService;
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
        
        [HttpPost("CreateUserFavoriteVenue")]
        public async Task<BaseResponse<object>> CreateUserFavoriteVenue([FromBody] UserFavoriteVenueRequest request)
        {
            var userId = CurrentUserId;
            await _userFavoriteVenueService.CreateUserFavoriteVenue(request,userId);
            return new BaseResponse<object>();
        }
        
        [HttpDelete("DeleteUserFavoriteVenue")]
        public async Task<BaseResponse<object>> DeleteUserFavoriteVenue([FromBody] UserFavoriteVenueRequest request)
        {
            var userId = CurrentUserId;
            await _userFavoriteVenueService.DeleteUserFavoriteVenue(request,userId);
            return new BaseResponse<object>();
        }
        
        [HttpGet("GetUserFavoriteVenueList")]
        public async Task<BaseResponse<List<int>>> GetUserFavoriteVenueList()
        {
            var userId = CurrentUserId;
            var response = await _userFavoriteVenueService.GetUserFavoriteVenue(userId);
            return new BaseResponse<List<int>>(ProcessStatusEnum.Success, null, response);
        }
        
        //todo: servisleri ayrı genel tablodan yönet
        //todo: controllerları ayır
        
    }
}
