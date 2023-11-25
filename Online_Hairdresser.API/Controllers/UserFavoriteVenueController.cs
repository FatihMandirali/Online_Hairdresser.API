using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Online_Hairdresser.Core.IServices;
using Online_Hairdresser.Models.Enums;
using Online_Hairdresser.Models.Models.BaseModel;
using Online_Hairdresser.Models.Models.Request.Venue;

namespace Online_Hairdresser.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "User")]
public class UserFavoriteVenueController:BaseController
{
    private readonly IUserFavoriteVenueService _userFavoriteVenueService;

    public UserFavoriteVenueController(IUserFavoriteVenueService userFavoriteVenueService)
    {
        _userFavoriteVenueService = userFavoriteVenueService;
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
        
    [HttpGet("GetUserFavoriteVenueIdList")]
    public async Task<BaseResponse<List<int>>> GetUserFavoriteVenueList()
    {
        var userId = CurrentUserId;
        var response = await _userFavoriteVenueService.GetUserFavoriteVenue(userId);
        return new BaseResponse<List<int>>(ProcessStatusEnum.Success, null, response);
    }
}